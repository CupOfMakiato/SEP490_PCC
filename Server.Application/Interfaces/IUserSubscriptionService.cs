using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.UserSubscription;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface IUserSubscriptionService
    {
        public Task<Result<UserSubscription>> CreateUserSubscription(CreateUserSubscriptionRequest request);
    }
}
