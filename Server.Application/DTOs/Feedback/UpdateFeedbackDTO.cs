using System.ComponentModel.DataAnnotations;

namespace Server.Application.DTOs.Feedback
{
    public class UpdateFeedbackDTO
    {
        public Guid Id { get; set; }
        [Range(0, 10, ErrorMessage = "Rating must be between 0 and 10.")]
        public float? Rating { get; set; }
        public string? Comment { get; set; }
    }
}
