namespace Server.Application.DTOs.OnlineConsultation
{
    public class AddOnlineConsultationDTO
    {
        public Guid ScheduleId { get; set; }
        public Guid UserId { get; set; }
        public Guid ConsultantId { get; set; }
        public string? Notes { get; set; }
    }
}
