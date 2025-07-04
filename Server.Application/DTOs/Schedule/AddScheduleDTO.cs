namespace Server.Application.DTOs.Schedule
{
    public class AddScheduleDTO
    {
        public Guid ConsultantId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public Guid? BookedByUserId { get; set; }
    }
}
