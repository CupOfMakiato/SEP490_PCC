using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.UserSubscription;
using Server.Application.Interfaces;
using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Application.Services
{
    public class UserSubscriptionService : IUserSubscriptionService
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public UserSubscriptionService(IUnitOfWork unitOfWork, IUserService userService)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> CancelSubscription(Guid userSubscriptionId)
        {
            var userSubscription = await _unitOfWork.UserSubscriptionRepository.GetUserSubscriptionByIdAsync(userSubscriptionId);
            if (userSubscription == null)
            {
                return new Result<bool>()
                {
                    Data = false,
                    Error = 1,
                    Message = "User subscription not found"
                };
            }
            if (userSubscription.Status != UserSubscriptionStatus.Active)
            {
                return new Result<bool>()
                {
                    Data = false,
                    Error = 1,
                    Message = "Only active subscriptions can be cancelled"
                };
            }
            userSubscription.Status = UserSubscriptionStatus.Canceled;
            _unitOfWork.UserSubscriptionRepository.Update(userSubscription);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<bool>()
                {
                    Data = true,
                    Error = 0,
                    Message = "Cancel subscription successfully"
                };
            }
            return new Result<bool>()
            {
                Data = false,
                Error = 1,
                Message = "Cancel subscription failed"
            };
        }

        public async Task<Result<UserSubscription>> CreateUserSubscription(CreateUserSubscriptionRequest request)
        {
            var subscriptionPlan = await _unitOfWork.SubscriptionPlanRepository.GetByIdAsync(request.SubscriptionPlanId);
            if (subscriptionPlan == null)
            {
                return new Result<UserSubscription>()
                {
                    Data = null,
                    Error = 1,
                    Message = "Subscription plan not found"
                };
            }

            var user = await _userService.GetCurrentUserById();
            if (user == null)
            {
                return new Result<UserSubscription>()
                {
                    Data = null,
                    Error = 1,
                    Message = "User not found"
                };
            }
            if (user.Data == null)
                return new Result<UserSubscription>()
                {
                    Data = null,
                    Error = 1,
                    Message = "User's data not found"
                };

            var existingSubscription = await _unitOfWork.UserSubscriptionRepository
                .IsUserSubscriptionCreated(request.SubscriptionPlanId, user.Data.Id);
            if (existingSubscription is not null)
            {
                return new Result<UserSubscription>()
                {
                    Data = existingSubscription,
                    Error = 0,
                    Message = "User subscription already exists"
                };
            }

            var userSubscription = new UserSubscription
            {
                UserId = user.Data.Id,
                SubscriptionPlanId = subscriptionPlan.Id,
                IsAutoRenew = false,
                NextBillingDate = DateTime.UtcNow.AddMonths(1),
                Status = Domain.Enums.UserSubscriptionStatus.Pending,
                SubscriptionPlan = subscriptionPlan
            };
            await _unitOfWork.UserSubscriptionRepository.AddAsync(userSubscription);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<UserSubscription>()
                {
                    Data = userSubscription,
                    Error = 0,
                    Message = "Create user subscription successfully"
                };
            }
            return new Result<UserSubscription>()
            {
                Data = null,
                Error = 1,
                Message = "Create user subscription failed"
            };
        }

        public async Task<Result<bool>> ExpireSubscription(Guid userSubscriptionId)
        {
            var userSubscription = await _unitOfWork.UserSubscriptionRepository.GetUserSubscriptionByIdAsync(userSubscriptionId);
            if (userSubscription == null)
            {
                return new Result<bool>()
                {
                    Data = false,
                    Error = 1,
                    Message = "User subscription not found"
                };
            }
            if (userSubscription.Payments is null || userSubscription.Payments.Count == 0)
            {
                return new Result<bool>()
                {
                    Data = false,
                    Error = 1,
                    Message = "No payments found for the subscription"
                };
            }
            var lastSuccessPayment = userSubscription.Payments?.OrderByDescending(p => p.CreatedAt).FirstOrDefault();
            if (lastSuccessPayment == null)
                return new Result<bool>()
                {
                    Data = false,
                    Error = 1,
                    Message = "No paid payment found for the subscription"
                };
            if (lastSuccessPayment.ExpiresAt > DateTime.UtcNow)
            {
                return new Result<bool>()
                {
                    Data = false,
                    Error = 1,
                    Message = "Cannot expire a subscription that has not yet expired"
                };
            }
            if (userSubscription.Status != UserSubscriptionStatus.Active || userSubscription.Status != UserSubscriptionStatus.Canceled)
            {
                return new Result<bool>()
                {
                    Data = false,
                    Error = 1,
                    Message = "Only active and canceled subscriptions can be expired"
                };
            }
            userSubscription.Status = UserSubscriptionStatus.Expired;
            _unitOfWork.UserSubscriptionRepository.Update(userSubscription);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<bool>()
                {
                    Data = true,
                    Error = 0,
                    Message = "Expire subscription successfully"
                };
            }
            return new Result<bool>()
            {
                Data = false,
                Error = 1,
                Message = "Expire subscription failed"
            };
        }

        public Task<Result<UserSubscription>> GetActiveSubscriptionByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<UserSubscription>>> GetAllSubscriptionsByUserId(Guid userId)
        {
            var userSubscriptions = await _unitOfWork.UserSubscriptionRepository.GetSubscriptionsByUserIdAsync(userId);
            if (userSubscriptions == null || userSubscriptions.Count == 0)
            {
                return new Result<List<UserSubscription>>()
                {
                    Data = null,
                    Error = 1,
                    Message = "No subscriptions found for the user"
                };
            }
            return new Result<List<UserSubscription>>()
            {
                Data = userSubscriptions,
                Error = 0,
                Message = "Get all subscriptions by user id successfully"
            };
        }

        public async Task<Result<List<UserSubscription>>> GetAllUserSubscriptions()
        {
            var userSubscription = await _unitOfWork.UserSubscriptionRepository.GetAllUserSubscriptionsAsync();
            return new Result<List<UserSubscription>>()
            {
                Data = userSubscription,
                Error = 0,
                Message = "Get all user subscriptions successfully"
            };
        }

        public async Task<Result<UserSubscription>> GetUserSubscriptionById(Guid userSubscriptionId)
        {
            var userSubscription = await _unitOfWork.UserSubscriptionRepository.GetUserSubscriptionByIdAsync(userSubscriptionId);
            if (userSubscription == null)
            {
                return new Result<UserSubscription>()
                {
                    Data = null,
                    Error = 1,
                    Message = "User subscription not found"
                };
            }
            return new Result<UserSubscription>()
            {
                Data = userSubscription,
                Error = 0,
                Message = "Get user subscription successfully"
            };
        }

        public async Task<Result<UserSubscription>> RenewSubscription(Guid userSubscriptionId, DateTime ExpiresAt)
        {
            var userSubscription = await _unitOfWork.UserSubscriptionRepository.GetUserSubscriptionByIdAsync(userSubscriptionId);
            if (userSubscription == null)
            {
                return new Result<UserSubscription>()
                {
                    Data = null,
                    Error = 1,
                    Message = "User subscription not found"
                };
            }
            if (userSubscription.Payments is null)
                return new Result<UserSubscription>()
                {
                    Data = null,
                    Error = 1,
                    Message = "No payments found for the subscription"
                };
            var lastSuccessPayment = userSubscription.Payments.Where(p => p.Status == PaymentStatus.Success).OrderByDescending(p => p.CreatedAt).FirstOrDefault();
            if (lastSuccessPayment == null)
                return new Result<UserSubscription>()
                {
                    Data = null,
                    Error = 1,
                    Message = "No paid payment found for the subscription"
                };
            if (lastSuccessPayment.ExpiresAt != ExpiresAt)
                return new Result<UserSubscription>()
                {
                    Data = null,
                    Error = 1,
                    Message = "ExpiresAt is invalid"
                };
            userSubscription.Status = UserSubscriptionStatus.Active;
            userSubscription.ExpiresAt = ExpiresAt;
            _unitOfWork.UserSubscriptionRepository.Update(userSubscription);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<UserSubscription>()
                {
                    Data = userSubscription,
                    Error = 0,
                    Message = "Renew subscription successfully"
                };
            }
            return new Result<UserSubscription>()
            {
                Data = null,
                Error = 1,
                Message = "Renew subscription failed"
            };
        }
    }
}
