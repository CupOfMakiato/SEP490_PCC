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
        public ICollection<Media> Media { get; set; } = new List<Media>();
        public User BlogCreatedBy { get; set; }
        // Blog can have many tags
        public ICollection<BlogTag> BlogTags { get; set; } = new List<BlogTag>();
        // Blog can have many comments
        public ICollection<Comment> Comment { get; set; } = new List<Comment>();
        // Blog can have many bookmarks
        public ICollection<Bookmark> Bookmark { get; set; } = new List<Bookmark>();
        // Blog can have many likes
        public ICollection<Like> Like { get; set; } = new List<Like>();

    }
}
