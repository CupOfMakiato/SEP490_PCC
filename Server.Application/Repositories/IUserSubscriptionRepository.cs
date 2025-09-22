using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IUserSubscriptionRepository : IGenericRepository<UserSubscription>
    {
        public Task<UserSubscription> GetActiveSubscriptionByUserIdAsync(Guid userId);
        public Task<List<UserSubscription>> GetSubscriptionsByUserIdAsync(Guid userId);
        public Task<List<UserSubscription>> GetSubscriptionsExpiringInDaysAsync(int days);
        public Task<List<UserSubscription>> GetAllActiveSubscriptionsAsync();
        public Task<UserSubscription> GetUserSubscriptionByIdAsync(Guid userSubscriptionId);
        public Task<List<UserSubscription>> GetAllUserSubscriptionsAsync();
        public Task<UserSubscription> IsUserSubscriptionCreated(Guid subscriptionId, Guid userId);
    }
}
