using Server.Domain.Enums;

namespace Server.Application.DTOs.OfflineConsultation
{
    public class BookingOfflineConsultationDTO
    {
        public Guid UserId { get; set; }
        public Guid ClinicId { get; set; }
        public Guid ConsultantId { get; set; }
        public Guid ScheduleId { get; set; }
        public ConsultationType ConsultationType { get; set; }
        public string? HealthNote { get; set; }
        public string? Attachment { get; set; }
    }
}
