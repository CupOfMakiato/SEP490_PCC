namespace Server.Application.DTOs.Message
{
    public class ViewMessageDTO
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public string MessageText { get; set; }
        public bool IsRead { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime ReadAt { get; set; }
    }
}
