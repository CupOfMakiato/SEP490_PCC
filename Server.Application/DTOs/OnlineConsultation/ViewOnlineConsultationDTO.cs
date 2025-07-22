using Server.Application.DTOs.Consultant;
using Server.Application.DTOs.User;

namespace Server.Application.DTOs.OnlineConsultation
{
    public class ViewOnlineConsultationDTO
    {
        public Guid Id { get; set; }
        public string Mode { get; set; }
        public string Status { get; set; }
        public string? JoinUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int SessionCount { get; set; }
        public string? Notes { get; set; }
        public bool IsPregnancyRelated { get; set; }

        public GetUserDTO User { get; set; }
        public ViewConsultantDTO Consultant { get; set; }
    }
}
