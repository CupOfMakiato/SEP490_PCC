using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Feedback : BaseEntity
    {
        public Guid ClinicId { get; set; }
        public Guid UserId { get; set; }
        public float Rating { get; set; }
        public string Comment { get; set; }

        public Clinic Clinic { get; set; }
        public User User { get; set; }
    }
}
