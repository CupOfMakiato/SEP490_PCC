using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class BlogTag
    {
        public Guid BlogId { get; set; }
        public Blog Blog { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
