using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Server.Application.DTOs.Clinic
{
    public class UpdateClinicDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        public bool IsInsuranceAccepted { get; set; }
        public string Specializations { get; set; }
        public IFormFile? ImageUrl { get; set; }
    }
}
