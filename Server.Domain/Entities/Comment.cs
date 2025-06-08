using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Body { get; set; }
        public Guid BlogId { get; set; }
        public User CommentCreatedBy { get; set; }
        public Blog Blog { get; set; }
        // List of replies to the comment
        public ICollection<Comment> Replies { get; set; } = new List<Comment>();
        // Parent comment for replies
        public Guid? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
        //public CommentStatus Status { get; set; } = CommentStatus.Active;

    }
}
