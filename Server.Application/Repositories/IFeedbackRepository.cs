using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IFeedbackRepository : IGenericRepository<Feedback>
    {
        public Task<Feedback?> GetFeedbackByIdAsync(Guid feedbackId);
    }
}
