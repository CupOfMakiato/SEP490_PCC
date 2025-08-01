using Server.Application.DTOs.Consultant;
using Server.Application.DTOs.Media;
using Server.Application.DTOs.User;

namespace Server.Application.DTOs.OnlineConsultation
{
    public class ViewOnlineConsultationDTO
    {
        public Guid Id { get; set; }
        public int Trimester { get; set; }
        public DateTime Date { get; set; }
        public int GestationalWeek { get; set; }
        public string Summary { get; set; }
        public string? ConsultantNote { get; set; }
        public string? UserNote { get; set; }
        public string? VitalSigns { get; set; }
        public string? Recommendations { get; set; }
        public List<MediaDTO>? Attachments { get; set; }

        public GetUserDTO User { get; set; }
        public ViewConsultantDTO Consultant { get; set; }
    }
}
