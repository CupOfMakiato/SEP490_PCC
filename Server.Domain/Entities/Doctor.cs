namespace Server.Domain.Entities
{
    public class Doctor : BaseEntity
    {
        public Guid ClinicId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }
        public int ExperienceYear { get; set; }
        public string Degree { get; set; }
        public string WorkPosition { get; set; }
        public string? Description { get; set; }

        public Clinic Clinic { get; set; }
    }
}
