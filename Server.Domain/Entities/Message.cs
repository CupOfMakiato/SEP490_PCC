using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Message : BaseEntity
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string MessageText { get; set; }
        public string MessageType { get; set; } 
        public bool IsRead { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime ReadAt { get; set; }

        public User Sender { get; set; }
        public User Receiver { get; set; }

        // List of images
        public ICollection<Media> Media { get; set; } = new List<Media>();
    }
}
