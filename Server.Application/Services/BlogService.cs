﻿using AutoMapper;
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

        public BlogService(IUnitOfWork unitOfWork, IMapper mapper, IBlogRepository blogRepository,
            ICloudinaryService cloudinaryService, ITagService tagService)
        {
            _blogRepository = blogRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _tagService = tagService;
        }
        // temporary use
        public async Task<Result<List<ViewBlogDTO>>> ViewAllBlogs()
        {
            var result = _mapper.Map<List<ViewBlogDTO>>(await _unitOfWork.blogRepository.GetAllBlogs());

            return new Result<List<ViewBlogDTO>>
            {
                Error = 0,
                Message = "View all blogs successfully",
                Data = result
            };
        }
        public async Task<Result<ViewBlogDTO>> ViewBlogById(Guid blogId)
        {
            var result = _mapper.Map<ViewBlogDTO>(await _unitOfWork.blogRepository.GetBlogById(blogId));
            return new Result<ViewBlogDTO>
            {
                Error = 0,
                Message = "View blog successfully",
                Data = result
            };
        }
        public async Task<Result<object>> UploadBlog(AddBlogDTO addBlogDTO)
        {
            // 1. Check if user exists
            var user = await _unitOfWork.userRepository.GetByIdAsync(addBlogDTO.UserId);
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
                var tag = await _unitOfWork.tagRepository.GetTagByName(tagName);

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

                    tag = await _unitOfWork.tagRepository.GetTagByName(tagName);
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
            await _unitOfWork.blogRepository.AddAsync(blog);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Blog uploaded successfully" : "Failed to upload blog",
                Data = blog
            };
        }

    }
}
