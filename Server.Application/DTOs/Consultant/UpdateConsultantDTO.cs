namespace Server.Application.DTOs.Consultant
{
    public class UpdateConsultantDTO
    {
        public Guid Id { get; set; }
        public string Specialization { get; set; }
        public string Certificate { get; set; }
        public string Status { get; set; }
        public string Gender { get; set; }
        public bool IsCurrentlyConsulting { get; set; }
        public int ExperienceYears { get; set; }
    }
}
