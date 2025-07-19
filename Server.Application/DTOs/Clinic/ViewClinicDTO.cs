using Server.Application.DTOs.Consultant;

namespace Server.Application.DTOs.Clinic
{
    public class ViewClinicDTO
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsInsuranceAccepted { get; set; }
        public string Specializations { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<ViewConsultantDTO> Consultants { get; set; }
    }
}
