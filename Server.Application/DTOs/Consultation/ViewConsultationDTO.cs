using Server.Application.DTOs.Clinic;
using Server.Application.DTOs.Consultant;
using Server.Application.DTOs.Journal;
using Server.Application.DTOs.User;

namespace Server.Application.DTOs.Consultation
{
    public class ViewConsultationDTO
    {
        public Guid Id { get; set; }
        public int Trimester { get; set; }
        public string ConsultationType { get; set; }
        public string Mode { get; set; }
        public string Status { get; set; }
        public int Week { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Diagnosis { get; set; }
        public string Notes { get; set; }
        public bool FollowUpRequired { get; set; }
        public GetUserDTO User { get; set; }
        public ViewConsultantDTO Consultant { get; set; }
        public ViewClinicDTO Clinic { get; set; }
    }
}
