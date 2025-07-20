using System.ComponentModel.DataAnnotations;

namespace Server.Application.DTOs.Consultant
{
    public class AddConsultantDTO
    {
        public Guid ClinicId { get; set; }
        public string Specialization { get; set; }
        public string Certificate { get; set; }
        public string Status { get; set; }
        public string Gender { get; set; }
        public bool IsCurrentlyConsulting { get; set; }
        public int ExperienceYears { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
    }
}
