namespace Server.Application.DTOs.Consultation
{
    public class AddConsultationDTO
    {
        public Guid UserId { get; set; }
        public Guid ConsultantId { get; set; }
        public Guid ClinicId { get; set; }
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
    }
}
