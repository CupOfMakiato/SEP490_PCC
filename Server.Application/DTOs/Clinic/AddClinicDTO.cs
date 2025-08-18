using System.ComponentModel.DataAnnotations;

namespace Server.Application.DTOs.Clinic
{
    public class AddClinicDTO
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Address { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        public bool IsInsuranceAccepted { get; set; }
        public string Specializations { get; set; }
    }
}
