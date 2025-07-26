using Server.Application.DTOs.Clinic;
using Server.Application.DTOs.Doctor;
using Server.Application.DTOs.User;
using Server.Domain.Enums;

namespace Server.Application.DTOs.OfflineConsultation
{
    public class ViewOfflineConsultationDTO
    {
        public Guid Id { get; set; }
        public ConsultationType ConsultationType { get; set; }
        public string Status { get; set; } //"Pending", "Confirmed", "Cancelled" v.v.
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DayOfWeek { get; set; } // 0 = Sunday
        public string? HealthNote { get; set; } // Vấn đề về sức khỏe
        public string? Attachment { get; set; }
        public GetUserDTO User { get; set; }
        public ViewClinicDTO Clinic { get; set; }
        public ViewDoctorDTO Doctor { get; set; }
    }
}
