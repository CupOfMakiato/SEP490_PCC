namespace Server.Application.DTOs.Feedback
{
    public class ViewFeedbackDTO
    {
        public Guid Id { get; set; }
        public float? Rating { get; set; }
        public string? Comment { get; set; }
    }
}
