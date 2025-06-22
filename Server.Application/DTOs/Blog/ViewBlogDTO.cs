using Server.Application.DTOs.Category;
using Server.Application.DTOs.User;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Blog
{
    public class ViewBlogDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string CategoryName { get; set; } 
        public BlogStatus Status { get; set; }
        public List<string> Tags { get; set; } // fix later
        public int LikeCount { get; set; }
        //public int CommentCount { get; set; }
        public int BookmarkCount { get; set; }
        public GetUserDTO? CreatedByUser { get; set; }
    }    
}
