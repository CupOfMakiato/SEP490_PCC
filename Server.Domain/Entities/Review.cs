namespace Server.Domain.Entities
{
    public class Review : BaseEntity
    {
        public decimal Rating { get; set; }
        public string Comment { get; set; }
        public Guid UserId { get; set; }
        public Guid ClinicId { get; set; }
        public User User { get; set; }
        public Clinic Clinic { get; set; }
    }
}
