using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Server.Application.DTOs.Doctor
{
    public class AddDoctorDTO
    {
        public Guid ClinicId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Specialization { get; set; }
        public string Certificate { get; set; }
        public int ExperienceYear { get; set; }
        public string WorkPosition { get; set; }
        public string? Description { get; set; }
    }
}
