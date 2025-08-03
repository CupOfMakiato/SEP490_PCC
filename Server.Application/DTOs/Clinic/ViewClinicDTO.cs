using Server.Application.DTOs.Consultant;
using Server.Application.DTOs.Doctor;
using Server.Application.DTOs.Feedback;
using Server.Application.DTOs.Media;

namespace Server.Application.DTOs.Clinic
{
    public class ViewClinicDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsInsuranceAccepted { get; set; }
        public string Specializations { get; set; }
        public MediaDTO ImageUrl { get; set; }
        public ICollection<ViewConsultantDTO> Consultants { get; set; }
        public ICollection<ViewDoctorDTO> Doctors { get; set; }
        public ICollection<ViewFeedbackDTO> Feedbacks { get; set; }
    }
}
