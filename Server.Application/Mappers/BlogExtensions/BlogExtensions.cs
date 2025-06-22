using Server.Application.Abstractions.RequestAndResponse.Blog;
using Server.Application.DTOs.Blog;
using Server.Domain.Entities;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Mappers.BlogExtensions
{
    public static class BlogExtensions
    {
        public static Blog ToBlog(this AddBlogDTO AddBlogDTO)
        {
            return new Blog
            {
                Id = AddBlogDTO.Id,
                Title = AddBlogDTO.Title,
                Body = AddBlogDTO.Body,
                CategoryId = AddBlogDTO.CategoryName != null ? Guid.Parse(AddBlogDTO.CategoryName) : Guid.Empty,
                Status = AddBlogDTO.Status,
                BlogTags = new List<BlogTag>(),
                Media = new List<Media>(),
                CreatedBy = AddBlogDTO.UserId
            };
        }

        public static AddBlogDTO ToUploadBlogDTO(this UploadNewBlogRequest UploadNewBlogRequest)
        {
            return new AddBlogDTO
            {
                Id = (Guid)UploadNewBlogRequest.Id,
                UserId = UploadNewBlogRequest.UserId,
                Title = UploadNewBlogRequest.Title,
                Body = UploadNewBlogRequest.Body,
                CategoryName = UploadNewBlogRequest.CategoryName, 
                Status = BlogStatus.Pending,
                Tags = UploadNewBlogRequest.Tags ?? new List<string>(),
                Images = UploadNewBlogRequest.Images

            };
        }
        public static EditBlogDTO ToEditBlogDTO(this EditBlogRequest editBlogRequest)
        {
            return new EditBlogDTO
            {
                Id = editBlogRequest.Id,
                Title = editBlogRequest.Title,
                Body = editBlogRequest.Body,
                Status = BlogStatus.Edited,
                Tags = editBlogRequest.Tags ?? new List<string>(),
                Images = editBlogRequest.Images
            };
        }
    }
}
