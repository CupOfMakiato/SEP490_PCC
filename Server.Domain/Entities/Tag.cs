using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public StatusEnums Status { get; set; } = StatusEnums.Active;
        public User TagCreatedBy { get; set; }
        public ICollection<BlogTag> BlogTags { get; set; } = new List<BlogTag>();
    }
}
