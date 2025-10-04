using Microsoft.AspNetCore.Http;
using Server.Application.DTOs.Schedule;

namespace Server.Application.DTOs.OfflineConsultation
{
    public class UpdateOfflineConsultationDTO
    {
        public Guid Id { get; set; }
        public string? HealthNote { get; set; }

        //for OneTime consultation
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //for Periodic consultation
        public DateTime? FromMonth { get; set; }
        public DateTime? ToMonth { get; set; }
        public List<IFormFile>? Attachments { get; set; }
        public List<AddDoctorScheduleDTO>? Schedule { get; set; }
    }
}
