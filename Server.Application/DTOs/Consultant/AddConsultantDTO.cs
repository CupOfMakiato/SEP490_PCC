namespace Server.Application.DTOs.Consultant
{
    public class AddConsultantDTO
    {
        public Guid UserId { get; set; }
        public Guid ClinicId { get; set; }
        public string Specialization { get; set; }
        public string Status { get; set; }
        public string Gender { get; set; }
        public DateTime JoinedAt { get; set; }
        public bool IsCurrentlyConsulting { get; set; }
    }
}
