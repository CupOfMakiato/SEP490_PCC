using Microsoft.AspNetCore.Http;

namespace Server.Application.DTOs.OnlineConsultation
{
    public class UpdateOnlineConsultationDTO
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
        public List<IFormFile>? Attachments { get; set; }
    }
}
