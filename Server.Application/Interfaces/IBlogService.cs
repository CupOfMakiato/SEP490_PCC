using Microsoft.AspNetCore.Http;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface IBlogService
    {
        // view
        Task<Result<List<ViewBlogDTO>>> ViewAllBlogs();
        Task<Result<ViewBlogDTO>> ViewBlogById(Guid blogId);
        // add
        Task<Result<object>> UploadBlog(AddBlogDTO addBlogDTO);

        // upload file attachment
        //Task<Result<object>> UploadFileAttachment(Guid blogId, IFormFile file);
    }
}
