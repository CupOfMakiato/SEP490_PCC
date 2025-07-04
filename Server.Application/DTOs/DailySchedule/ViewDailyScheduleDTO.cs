namespace Server.Application.DTOs.DailySchedule
{
    public class ViewDailyScheduleDTO
    {
        public Guid Id { get; set; }
        public Guid ClinicWorkRuleId { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool IsWorking { get; set; }
        public string? Note { get; set; }
    }
}
