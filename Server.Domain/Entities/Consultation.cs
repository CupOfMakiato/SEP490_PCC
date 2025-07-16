using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Consultation : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ConsultantId { get; set; }
        //public Guid ClinicId { get; set; }
        //public Guid? JournalId { get; set; }
        public string ConsultationType { get; set; }
        public string Mode { get; set; }
        public string Status { get; set; }
        public string JoinUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int SessionCount { get; set; }
        public string Notes { get; set; }
        public bool IsPregnancyRelated { get; set; }

        public User User { get; set; }
        public Consultant Consultant { get; set; }
        //public Clinic Clinic { get; set; }
    }
}
