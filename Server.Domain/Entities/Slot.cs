using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Slot :BaseEntity
    {
        public Guid ConsultantId { get; set; }
        public Guid ClinicId { get; set; }
        public DateTime SlotDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Status { get; set; }
        public Guid? BookedByUserId { get; set; }
        public Guid? ConsultationId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Consultant Consultant { get; set; }
        public Clinic Clinic { get; set; }
        public User BookedByUser { get; set; }
        public Consultation Consultation { get; set; }
    }
}
