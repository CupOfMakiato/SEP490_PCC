namespace Server.Domain.Entities
{
    public class ChatThread : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ConsultantId { get; set; }
        public string Status { get; set; }

        public User User { get; set; }
        public User Consultant { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
