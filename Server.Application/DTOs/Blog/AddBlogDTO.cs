﻿using Microsoft.AspNetCore.Http;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Blog
{
    public class AddBlogDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public List<string> Tags { get; set; } = new();
        public string Title { get; set; }
        public string Body { get; set; }
        public BlogStatus Status { get; set; }
        public List<IFormFile>? Images { get; set; }

    }
}
