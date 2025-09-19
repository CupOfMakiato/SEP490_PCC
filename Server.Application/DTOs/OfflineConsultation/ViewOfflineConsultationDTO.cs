using Server.Application.DTOs.Clinic;
using Server.Application.DTOs.Doctor;
using Server.Application.DTOs.Media;
using Server.Application.DTOs.Schedule;
using Server.Application.DTOs.User;
using Server.Domain.Enums;

namespace Server.Application.DTOs.OfflineConsultation
{
    public class ViewOfflineConsultationDTO
    {
        public Guid Id { get; set; }
        public ConsultationType ConsultationType { get; set; }
        public string Status { get; set; } //"Pending", "Confirmed", "Cancelled" v.v.
        public string? HealthNote { get; set; } // Vấn đề về sức khỏe
        //for OneTime consultation
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //for Periodic consultation
        public DateTime? FromMonth { get; set; }
        public DateTime? ToMonth { get; set; }
        public List<AddDoctorScheduleDTO>? Schedules { get; set; }
        public List<MediaDTO>? Attachments { get; set; }
        public GetUserDTO User { get; set; }
        public ViewClinicDTO Clinic { get; set; }
        public ViewDoctorDTO Doctor { get; set; }
    }
}
