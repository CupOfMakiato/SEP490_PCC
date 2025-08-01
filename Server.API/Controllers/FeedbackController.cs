using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.Feedback;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/feedback")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet("view-feedback-by-id/{feedbackId}")]
        public async Task<IActionResult> GetFeedbackByIdAsync(Guid feedbackId)
        {
            var result = await _feedbackService.GetFeedbackByIdAsync(feedbackId);

            return Ok(result);
        }

        [HttpPost("create-feedback")]
        public async Task<IActionResult> CreateFeedbackAsync([FromBody] AddFeedbackDTO feedback)
        {
            var result = await _feedbackService.CreateFeedbackAsync(feedback);

            return Ok(result);
        }

        [HttpPut("update-feedback")]
        public async Task<IActionResult> UpdateFeedbackAsync([FromBody] UpdateFeedbackDTO feedback)
        {
            var result = await _feedbackService.UpdateFeedbackAsync(feedback);

            return Ok(result);
        }

        [HttpDelete("soft-delete-feedback/{feedbackId}")]
        public async Task<IActionResult> SoftDeleteFeedbackAsync(Guid feedbackId)
        {
            var result = await _feedbackService.SoftDeleteFeedbackAsync(feedbackId);

            return Ok(result);
        }
    }
}
