namespace Server.Domain.Entities
{
    public class Message : BaseEntity
    {
        public string MessageText { get; set; }
        public string MessageType { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public DateTime ReadAt { get; set; } = DateTime.UtcNow;
    }
}
