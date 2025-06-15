using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class AllergyCategory : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public User User { get; set; }
    }
}
