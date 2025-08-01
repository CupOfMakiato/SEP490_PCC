namespace Server.Application.DTOs.Doctor
{
    public class UpdateDoctorDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Specialization { get; set; }
        public string Certificate { get; set; }
        public int ExperienceYear { get; set; }
        public string WorkPosition { get; set; }
        public string? Description { get; set; }
    }
}
