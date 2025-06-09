namespace Server.Domain.Entities
{
    public class Consultant : BaseEntity
    {
        public string? Specialization { get; set; }
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
        public bool IsCurrentlyConsulting { get; set; } = false;
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public Guid ClinicId { get; set; }
        public User User { get; set; }
        public Clinic Clinic { get; set; }
    }
}
