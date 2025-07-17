using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Consultant : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ClinicId { get; set; }
        public string Specialization { get; set; }
        public string Certificate { get; set; }
        public string Status { get; set; }
        public string Gender { get; set; }
        public DateTime JoinedAt { get; set; }
        public bool IsCurrentlyConsulting { get; set; }

        public User User { get; set; }
        public Clinic Clinic { get; set; }
    }
}
