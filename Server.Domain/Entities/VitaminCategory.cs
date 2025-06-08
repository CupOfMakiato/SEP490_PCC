using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class VitaminCategory : BaseEntity
    {
        public string Name { get; set; }    
        public string Description { get; set; } = string.Empty;
        public IEnumerable<Vitamin> Vitamins { get; set; }
    }
}
