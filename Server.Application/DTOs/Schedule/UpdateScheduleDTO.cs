namespace Server.Application.DTOs.Schedule
{
    public class UpdateScheduleDTO
    {
        public Guid Id { get; set; }
        public Guid ConsultantId { get; set; }
        public int DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsAvailable { get; set; }
    }
}
