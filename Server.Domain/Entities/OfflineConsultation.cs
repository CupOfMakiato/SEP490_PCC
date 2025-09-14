using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class OfflineConsultation : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ClinicId { get; set; }
        public Guid DoctorId { get; set; }
        public ConsultationType ConsultationType { get; set; } = ConsultationType.OneTime;
        public string Status { get; set; } //"Pending", "Confirmed", "Cancelled" v.v.

        //for OneTime consultation
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //for Periodic consultation
        public DateTime? FromMonth { get; set; }
        public DateTime? ToMonth { get; set; }

        public string? HealthNote { get; set; } // Vấn đề về sức khỏe

        public User User { get; set; }
        public Clinic Clinic { get; set; }
        public Doctor Doctor { get; set; }
        public ICollection<Media>? Attachments { get; set; }
        public ICollection<Schedule>? Schedules { get; set; }
    }
}
