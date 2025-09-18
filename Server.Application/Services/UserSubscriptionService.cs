using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.UserSubscription;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class UserSubscriptionService : IUserSubscriptionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserSubscriptionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<UserSubscription>> CreateUserSubscription(CreateUserSubscriptionRequest request)
        {
            return new Result<UserSubscription>
            {
                
            };
        }
    }
}
