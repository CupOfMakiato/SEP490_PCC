using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public BlogStatus Status { get; set; } = BlogStatus.Published; 
        // List of images
        public IEnumerable<Media> Media { get; set; } = new List<Media>();
        public User BlogCreatedBy { get; set; }
        // Blog can have many tags
        public IEnumerable<BlogTag> BlogTags { get; set; } = new List<BlogTag>();
        // Blog can have many comments
        public IEnumerable<Comment> Comment { get; set; } = new List<Comment>();
        // Blog can have many bookmarks
        public IEnumerable<Bookmark> BookmarkedByUsers { get; set; }
        // Blog can have many likes
        public IEnumerable<Like> LikedByUsers { get; set; }

    }
}
