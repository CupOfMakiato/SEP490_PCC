namespace Server.Domain.Entities
{
    public class ClinicWorkRule : BaseEntity
    {
        public Guid ClinicId { get; set; }
        public int TotalWorkingDays { get; set; }
        public string Annoucement { get; set; }

        public Clinic Clinic { get; set; }
        public ICollection<DailySchedule>? DailySchedules { get; set; }
    }
}
