namespace Server.Application.DTOs.Message
{
    public class SendMessageDTO
    {
        public Guid ChatThreadId { get; set; }
        public Guid SenderId { get; set; }
        public string MessageText { get; set; }
    }
}
