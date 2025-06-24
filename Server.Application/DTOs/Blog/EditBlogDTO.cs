using Microsoft.AspNetCore.Http;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Blog
{
    public class EditBlogDTO
    {
        public Guid Id { get; set; }
        public List<string> Tags { get; set; } = new();
        public string Title { get; set; }
        public string Body { get; set; }
        public string? CategoryName { get; set; } 
        public BlogStatus Status { get; set; }
        public List<IFormFile>? Images { get; set; }

    }
}
