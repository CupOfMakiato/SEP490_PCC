namespace Server.Application.DTOs.Feedback
{
    public class AddFeedbackDTO
    {
        public Guid ClinicId { get; set; }
        public Guid UserId { get; set; }
        public float? Rating { get; set; }
        public string? Comment { get; set; }
    }
}
