namespace Server.Domain.Entities
{
    public class DailySchedule :BaseEntity
    {
        public Guid ClinicWorkRuleId { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool IsWorking { get; set; }
        public string Note { get; set; }

        public ClinicWorkRule ClinicWorkRule { get; set; }
    }
}
