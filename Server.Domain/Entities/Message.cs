using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Message : BaseEntity
    {
        public Guid ChatThreadId { get; set; }
        public Guid SenderId { get; set; }
        public string? MessageText { get; set; }
        public string MessageType { get; set; } = "text";
        public bool IsRead { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public DateTime ReadAt { get; set; }

        // List of images
        public ICollection<Media> Media { get; set; } = new List<Media>();
        public ChatThread ChatThread { get; set; }
    }
}
