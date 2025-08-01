using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class OnlineConsultation : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ConsultantId { get; set; }
        //public Guid ClinicId { get; set; }
        //public Guid? JournalId { get; set; }
        public int Trimester { get; set; }
        public DateTime Date { get; set; }
        public int GestationalWeek { get; set; } // Tuần thai khi tư vấn (tuần thứ mấy của thai kỳ)
        public string Summary { get; set; } // Nội dung tư vấn chính
        public string? ConsultantNote { get; set; }
        public string? UserNote { get; set; }
        public string? VitalSigns { get; set; } // Các chỉ số/đánh giá quan trọng trong buổi tư vấn, Ví dụ: huyết áp, nhịp tim, cân nặng...
        public string? Recommendations { get; set; } // Hướng dẫn, lời khuyên
        
        public User User { get; set; }
        public Consultant Consultant { get; set; }
        public ICollection<Media>? Attachments { get; set; }
        //public Guid? UserSubscriptionId { get; set; }
        //public UserSubscription UserSubscription { get; set; }
        //public Clinic Clinic { get; set; }
    }
}
