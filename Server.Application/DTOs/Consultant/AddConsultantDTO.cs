namespace Server.Application.DTOs.Consultant
{
    public class AddConsultantDTO
    {
        public Guid ClinicId { get; set; }
        public string Specialization { get; set; }
        public string Status { get; set; }
        public string Gender { get; set; }
        public DateTime JoinedAt { get; set; }
        public bool IsCurrentlyConsulting { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string? Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
