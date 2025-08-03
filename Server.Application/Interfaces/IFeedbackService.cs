using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Feedback;

namespace Server.Application.Interfaces
{
    public interface IFeedbackService
    {
        public Task<Result<ViewFeedbackDTO>> GetFeedbackByIdAsync(Guid feedbackId);
        public Task<Result<bool>> SoftDeleteFeedbackAsync(Guid feedbackId);
        public Task<Result<ViewFeedbackDTO>> CreateFeedbackAsync(AddFeedbackDTO feedback);
        public Task<Result<ViewFeedbackDTO>> UpdateFeedbackAsync(UpdateFeedbackDTO feedback);
    }
}
