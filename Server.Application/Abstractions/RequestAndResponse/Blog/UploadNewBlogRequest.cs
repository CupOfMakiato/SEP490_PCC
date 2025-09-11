using FluentValidation;
using Microsoft.AspNetCore.Http;
using Server.Application.DTOs.Blog;
using Server.Domain.Entities;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Abstractions.RequestAndResponse.Blog
{
    public class UploadNewBlogRequest
    {
        public Guid? Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new List<string>(); // Add tags field
        public List<IFormFile>? Images { get; set; }
    }
}
