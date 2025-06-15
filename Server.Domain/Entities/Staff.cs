using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Staff : BaseEntity
    {
        public Guid UserId { get; set; }
        public string StaffType { get; set; }
        public string Specialization { get; set; }
        public bool IsAvailable { get; set; }

        public User User { get; set; }
    }
}
