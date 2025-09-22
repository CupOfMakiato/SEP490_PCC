namespace Server.Application.DTOs.Message
{
    public class ViewChatThreadDTO
    {
        public Guid Id { get; set; }
        public Guid ConsultantId { get; set; }
        public Guid UserId { get; set; }
        public string Status { get; set; }
        public List<ViewMessageDTO> Messages { get; set; }
    }
}
