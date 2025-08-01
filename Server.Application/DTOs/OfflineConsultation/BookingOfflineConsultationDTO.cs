using Microsoft.AspNetCore.Http;
using Server.Application.DTOs.Schedule;
using Server.Domain.Enums;

namespace Server.Application.DTOs.OfflineConsultation
{
    public class BookingOfflineConsultationDTO
    {
        public Guid UserId { get; set; }
        public Guid DoctorId { get; set; }
        public ConsultationType ConsultationType { get; set; }
        public string? HealthNote { get; set; }
        public List<IFormFile>? Attachments { get; set; }
        public AddDoctorScheduleDTO Schedule { get; set; }
    }
}
