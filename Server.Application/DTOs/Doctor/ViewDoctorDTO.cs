using Server.Application.DTOs.Clinic;
using Server.Application.DTOs.User;

namespace Server.Application.DTOs.Doctor
{
    public class ViewDoctorDTO
    {
        public Guid Id { get; set; }
        public string Gender { get; set; }
        public string Specialization { get; set; }
        public string Certificate { get; set; }
        public int ExperienceYear { get; set; }
        public string WorkPosition { get; set; }
        public string? Description { get; set; }
        public GetUserDTO User { get; set; }
        public ViewClinicDTO Clinic { get; set; }
    }
}
