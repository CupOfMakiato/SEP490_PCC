using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IOnlineConsultationRepository : IGenericRepository<OnlineConsultation>
    {
        public Task<OnlineConsultation?> GetOnlineConsultationByIdAsync(Guid onlineConsultationId);
        public Task<List<OnlineConsultation>> GetOnlineConsultationsByConsultantIdAsync(Guid consultantId);
        public Task<List<OnlineConsultation>> GetOnlineConsultationsByUserIdAsync(Guid userId);
        public Task<UserSubscription?> GetActiveSubscriptionAsync(Guid userId);
    }
}
