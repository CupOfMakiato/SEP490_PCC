using AutoMapper;
using Microsoft.AspNetCore.Http;
using Server.Application.Abstractions.Shared;
using Server.Application.Abstractions.ThirdPartyService.CloudinaryService;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.Category;
using Server.Application.DTOs.Tag;
using Server.Application.Interfaces;
using Server.Application.Mappers.BlogExtensions;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly ITagService _tagService;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;

        public BlogService(IUnitOfWork unitOfWork, IMapper mapper, IBlogRepository blogRepository,
            ICloudinaryService cloudinaryService, ITagService tagService, IClaimsService claimsService)
        {
            _blogRepository = blogRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _tagService = tagService;
            _claimsService = claimsService;
        }
        // temporary use
        public async Task<Result<List<ViewBlogDTO>>> ViewAllBlogs()
        {
            var blogs = await _unitOfWork.BlogRepository.GetAllBlogs();

            var result = _mapper.Map<List<ViewBlogDTO>>(blogs);

            foreach (var blogDTO in result)
            {
                blogDTO.BookmarkCount = await _unitOfWork.BookmarkRepository.CountBookmarksByBlogId(blogDTO.Id);
                blogDTO.LikeCount = await _unitOfWork.LikeRepository.CountLikesByBlogId(blogDTO.Id);
            }

            

            return new Result<List<ViewBlogDTO>>
            {
                Error = 0,
                Message = "View all blogs successfully",
                Data = result
            };
        }
        public async Task<Result<ViewBlogDTO>> ViewBlogById(Guid blogId)
        {
            var blog = await _unitOfWork.BlogRepository.GetBlogById(blogId);

            // Check if blog exists
            if (blog == null)
            {
                return new Result<ViewBlogDTO>
                {
                    Error = 1,
                    Message = "Blog not found",
                    Data = null
                };
            }

            var result = _mapper.Map<ViewBlogDTO>(blog);

            result.BookmarkCount = await _unitOfWork.BookmarkRepository.CountBookmarksByBlogId(result.Id);
            result.LikeCount = await _unitOfWork.LikeRepository.CountLikesByBlogId(result.Id);

            return new Result<ViewBlogDTO>
            {
                Error = 0,
                Message = "View blog successfully",
                Data = result
            };
        }

        public async Task<Result<object>> DeleteBlog(Guid blogId)
        {
            var existingBlog = await _unitOfWork.BlogRepository.GetBlogById(blogId);
            if (existingBlog == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Blog not found",
                    Data = null
                };
            }

            _unitOfWork.BlogRepository.SoftRemove(existingBlog);

            // Save the changes
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Blog deleted successfully" : "Failed to delete blog",
                Data = null
            };
        }
        public async Task<Result<object>> UploadBlog(AddBlogDTO addBlogDTO)
        {
            // 1. Check if user exists
            var user = await _unitOfWork.UserRepository.GetByIdAsync(addBlogDTO.UserId);
            if (user == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not exist!",
                    Data = null
                };
            }

            // Create blog
            var blog = addBlogDTO.ToBlog(); 
            blog.Id = Guid.NewGuid();
            blog.CreationDate = DateTime.UtcNow;
            blog.BlogTags = new List<BlogTag>();
            blog.Media = new List<Media>();

            // Upload Images (0 to 4 allowed)
            if (addBlogDTO.Images != null && addBlogDTO.Images.Any())
            {
                if (addBlogDTO.Images.Count > 4)
                {
                    return new Result<object>
                    {
                        Error = 1,
                        Message = "You can upload a maximum of 4 images per blog.",
                        Data = null
                    };
                }

                foreach (var image in addBlogDTO.Images)
                {
                    var response = await _cloudinaryService.UploadBlogImage(image.FileName, image, blog);
                    if (response != null)
                    {
                        blog.Media.Add(new Media
                        {
                            BlogId = blog.Id,
                            FileName = image.FileName, 
                            FileUrl = response.FileUrl,
                            FilePublicId = response.PublicFileId,
                            FileType = image.ContentType 
                        });
                    }
                }
            }


            // Handle Tags
            var distinctTags = addBlogDTO.Tags?.Distinct(StringComparer.OrdinalIgnoreCase).ToList() ?? new List<string>();
            foreach (var tagName in distinctTags)
            {
                var tag = await _unitOfWork.TagRepository.GetTagByName(tagName);

                if (tag == null)
                {
                    var addTagDTO = new AddTagDTO
                    {
                        UserId = addBlogDTO.UserId,
                        Name = tagName
                    };

                    var tagResult = await _tagService.AddNewTag(addTagDTO);
                    if (tagResult.Error != 0)
                    {
                        return new Result<object>
                        {
                            Error = 1,
                            Message = $"Failed to create tag: {tagName}",
                            Data = null
                        };
                    }

                    tag = await _unitOfWork.TagRepository.GetTagByName(tagName);
                    if (tag == null)
                    {
                        return new Result<object>
                        {
                            Error = 1,
                            Message = $"Tag '{tagName}' was not found after creation.",
                            Data = null
                        };
                    }
                }

                blog.BlogTags.Add(new BlogTag
                {
                    BlogId = blog.Id,
                    TagId = tag.Id
                });
            }

            // Save Blog
            await _unitOfWork.BlogRepository.AddAsync(blog);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Blog uploaded successfully" : "Failed to upload blog",
                Data = blog
            };
        }

        public async Task<Result<object>> ApproveBlog(Guid blogId, Guid approvedByUserId)
        {
            var blog = await _unitOfWork.BlogRepository.GetBlogById(blogId);
            if (blog == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Blog not found.",
                    Data = null
                };
            }

            // check if pending
            if (blog.Status != BlogStatus.Pending)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Only blogs with 'Pending' status can be approved.",
                    Data = null
                };
            }

            // update to approved
            blog.Status = BlogStatus.Approved;
            blog.ModificationBy = approvedByUserId;
            blog.ModificationDate = DateTime.UtcNow;

            _unitOfWork.BlogRepository.Update(blog);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Blog approved successfully" : "Failed to approve blog",
                Data = blog
            };
        }
        public async Task<Result<object>> RejectBlog(Guid blogId, Guid rejectedByUserId, string rejectionReason = null)
        {
            var blog = await _unitOfWork.BlogRepository.GetByIdAsync(blogId);
            if (blog == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Blog not found.",
                    Data = null
                };
            }

            // check if pending
            if (blog.Status != BlogStatus.Pending)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Only blogs with 'Pending' status can be rejected.",
                    Data = null
                };
            }

            blog.Status = BlogStatus.Rejected;
            blog.ModificationBy = rejectedByUserId;
            blog.ModificationDate = DateTime.UtcNow;

            if (!string.IsNullOrWhiteSpace(rejectionReason))
            {
                blog.RejectionReason = rejectionReason; 
            }

            _unitOfWork.BlogRepository.Update(blog);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Blog rejected successfully" : "Failed to reject blog",
                Data = blog
            };
        }


        public async Task<Result<object>> EditBlog(EditBlogDTO editBlogDTO)
        {
            var blog = await _unitOfWork.BlogRepository.GetBlogById(editBlogDTO.Id);
            if (blog == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Blog not found",
                    Data = null
                };
            }

            blog.Title = editBlogDTO.Title;
            blog.Body = editBlogDTO.Body;
            blog.Status = editBlogDTO.Status;

            if (editBlogDTO.Images == null)
            {
                // Remove all existing images when Images is null
                if (blog.Media != null && blog.Media.Any())
                {
                    foreach (var existingMedia in blog.Media.ToList())
                    {
                        if (!string.IsNullOrEmpty(existingMedia.FilePublicId))
                        {
                            await _cloudinaryService.DeleteFileAsync(existingMedia.FilePublicId);
                        }
                    }
                    // Clear existing media from blog
                    blog.Media.Clear();
                }
            }
            else
            {
                // Images field is provided as a list (empty or with items)
                if (blog.Media != null && blog.Media.Any())
                {
                    foreach (var existingMedia in blog.Media.ToList())
                    {
                        if (!string.IsNullOrEmpty(existingMedia.FilePublicId))
                        {
                            await _cloudinaryService.DeleteFileAsync(existingMedia.FilePublicId);
                        }
                    }
                    blog.Media.Clear();
                }
                if (editBlogDTO.Images.Any()) // has image
                {
                    if (editBlogDTO.Images.Count > 4)
                    {
                        return new Result<object>
                        {
                            Error = 1,
                            Message = "You can upload a maximum of 4 images per blog.",
                            Data = null
                        };
                    }

                    foreach (var image in editBlogDTO.Images)
                    {
                        var response = await _cloudinaryService.UploadBlogImage(image.FileName, image, blog);
                        if (response != null)
                        {
                            blog.Media.Add(new Media
                            {
                                BlogId = blog.Id,
                                FileName = image.FileName,
                                FileUrl = response.FileUrl,
                                FilePublicId = response.PublicFileId,
                                FileType = image.ContentType
                            });
                        }
                    }
                }
            }

            // Handle Tags Update
            if (editBlogDTO.Tags != null)
            {
                // Remove existing blog-tag relationships
                if (blog.BlogTags != null && blog.BlogTags.Any())
                {
                    blog.BlogTags.Clear();
                }

                // Add new tags
                var distinctTags = editBlogDTO.Tags.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
                foreach (var tagName in distinctTags)
                {
                    var tag = await _unitOfWork.TagRepository.GetTagByName(tagName);

                    if (tag == null)
                    {
                        // Create new tag if it doesn't exist
                        var addTagDTO = new AddTagDTO
                        {
                            UserId = _claimsService.GetCurrentUserId, // Get from claims service instead
                            Name = tagName
                        };

                        var tagResult = await _tagService.AddNewTag(addTagDTO);
                        if (tagResult.Error != 0)
                        {
                            return new Result<object>
                            {
                                Error = 1,
                                Message = $"Failed to create tag: {tagName}",
                                Data = null
                            };
                        }

                        tag = await _unitOfWork.TagRepository.GetTagByName(tagName);
                        if (tag == null)
                        {
                            return new Result<object>
                            {
                                Error = 1,
                                Message = $"Tag '{tagName}' was not found after creation.",
                                Data = null
                            };
                        }
                    }

                    blog.BlogTags.Add(new BlogTag
                    {
                        BlogId = blog.Id,
                        TagId = tag.Id
                    });
                }
            }

            // Save changes
            _unitOfWork.BlogRepository.Update(blog); 
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Blog updated successfully" : "Failed to update blog",
                Data = blog
            };
        }
        
    }
}
