namespace Server.Domain.Entities
{
    public class Doctor : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ClinicId { get; set; }
        public string Gender { get; set; }
        public string Specialization { get; set; }
        public string Certificate { get; set; }
        public int ExperienceYear { get; set; }
        public string WorkPosition { get; set; }
        public string? Description { get; set; }

        public User User { get; set; }
        public Clinic Clinic { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
