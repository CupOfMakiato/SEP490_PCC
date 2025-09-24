using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.UserSubscription;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface IUserSubscriptionService
    {
        public Task<Result<UserSubscription>> CreateUserSubscription(CreateUserSubscriptionRequest request);
        public Task<Result<UserSubscription>> GetActiveSubscriptionByUserId(Guid userId);
        public Task<Result<List<UserSubscription>>> GetAllSubscriptionsByUserId(Guid userId);
        public Task<Result<bool>> CancelSubscription(Guid userSubscriptionId);
        public Task<Result<bool>> ExpireSubscription(Guid userSubscriptionId);
        public Task<Result<UserSubscription>> RenewSubscription(Guid userSubscriptionId, DateTime ExpiresAt);
        public Task<Result<UserSubscription>> GetUserSubscriptionById(Guid userSubscriptionId);
        public Task<Result<List<UserSubscription>>> GetAllUserSubscriptions();

        //test
        Task<Result<UserSubscription>> CreateUserSubscriptionFreePlan();
    }
}
