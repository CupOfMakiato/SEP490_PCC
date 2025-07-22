namespace Server.Application.DTOs.OnlineConsultation
{
    public class UpdateOnlineConsultationDTO
    {
        public Guid Id { get; set; }
        public string? JoinUrl { get; set; }
        public bool IsPregnancyRelated { get; set; }
    }
}
