namespace Server.Domain.Entities
{
    public class PatientRecord : BaseEntity
    {
        public string PatientName { get; set; }
        public string MedicalCondition { get; set; }
        public string Medications { get; set; }
        public string CurrentMedications { get; set; }
        public string Treatment { get; set; }
        public DateTime LastVisitDate { get; set; } = DateTime.UtcNow;
        public string Notes { get; set; }
        public Guid UserId { get; set; }
        public Guid ConsultantId { get; set; }
        public User User { get; set; }
        public Consultant Consultant { get; set; }
    }
}
