using AutoMapper;
using Org.BouncyCastle.Asn1.Ocsp;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.SubscriptionPlan;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class SubscriptionPlanService : ISubscriptionPlanService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SubscriptionPlanService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<SubscriptionPlan>> CreateSubscriptionPlan(CreateSubscriptionPlanRequest request)
        {
            var subscriptionPlan = new SubscriptionPlan
            {
                SubscriptionName = request.SubscriptionName,
                Description = request.Description,
                Price = request.Price,
                DurationInDays = request.DurationInDays,
                SubscriptionType = request.SubscriptionType,
                IsActive = true,
            };
            await _unitOfWork.SubscriptionPlanRepository.AddAsync(subscriptionPlan);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<SubscriptionPlan>()
                {
                    Error = 0,
                    Message = "Subscription plan created successfully.",
                    Data = subscriptionPlan
                };                    
            }
            return new Result<SubscriptionPlan>()
            {
                Error = 1,
                Message = "Failed to create subscription plan.",
                Data = null
            };
        }

        public async Task<Result<bool>> DeleteSubscriptionPlan(Guid id)
        {
            var subscriptionPlan = await _unitOfWork.SubscriptionPlanRepository.GetSubscriptionPlanById(id);
            if (subscriptionPlan == null)
            {
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Subscription plan not found.",
                    Data = false
                };
            }

            if (subscriptionPlan.UserSubscriptions != null && subscriptionPlan.UserSubscriptions.Any())
            {
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Cannot delete subscription plan with active user subscriptions.",
                    Data = false
                };
            }

            _unitOfWork.SubscriptionPlanRepository.DeleteSubscriptionPlan(subscriptionPlan);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<bool>()
                {
                    Error = 0,
                    Message = "Subscription plan deleted successfully.",
                    Data = true
                };
            }
            return new Result<bool>()
            {
                Error = 1,
                Message = "Failed to delete subscription plan.",
                Data = false
            };
        }

        public async Task<SubscriptionPlan> GetSubscriptionPlanById(Guid id)
        {
            return await _unitOfWork.SubscriptionPlanRepository.GetSubscriptionPlanById(id);
        }

        public async Task<List<SubscriptionPlan>> GetSubscriptionPlans()
        {
            return await _unitOfWork.SubscriptionPlanRepository.GetAllSubscriptionPlans();
        }

        public async Task<Result<bool>> ToggleSubscriptionPlanStatus(Guid id)
        {
            var subscriptionPlan =  await _unitOfWork.SubscriptionPlanRepository.GetSubscriptionPlanById(id);
            if (subscriptionPlan == null)
            {
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Subscription plan not found.",
                    Data = false
                };
            }
            subscriptionPlan.IsActive = !subscriptionPlan.IsActive;
            _unitOfWork.SubscriptionPlanRepository.Update(subscriptionPlan);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<bool>()
                {
                    Error = 0,
                    Message = "Subscription plan status toggled successfully.",
                    Data = true
                };
            }
            return new Result<bool>()
            {
                Error = 1,
                Message = "Failed to toggle subscription plan status.",
                Data = false
            };
        }

        public Task<Result<SubscriptionPlan>> UpdateSubscriptionPlan(UpdateSubscriptionPlanRequest request)
        {
            var subscriptionPlan =  _unitOfWork.SubscriptionPlanRepository.GetSubscriptionPlanById(request.Id).Result;
            if (subscriptionPlan == null)
            {
                return Task.FromResult(new Result<SubscriptionPlan>()
                {
                    Error = 1,
                    Message = "Subscription plan not found.",
                    Data = null
                });
            }
            subscriptionPlan.SubscriptionName = request.SubscriptionName;
            subscriptionPlan.Description = request.Description;
            subscriptionPlan.Price = request.Price;
            subscriptionPlan.DurationInDays = request.DurationInDays;
            subscriptionPlan.SubscriptionType = request.SubscriptionType;
            subscriptionPlan.IsActive = request.IsActive;
            _unitOfWork.SubscriptionPlanRepository.Update(subscriptionPlan);
            if (_unitOfWork.SaveChangeAsync().Result > 0)
            {
                return Task.FromResult(new Result<SubscriptionPlan>()
                {
                    Error = 0,
                    Message = "Subscription plan updated successfully.",
                    Data = subscriptionPlan
                });
            }
            return Task.FromResult(new Result<SubscriptionPlan>()
            {
                Error = 1,
                Message = "Failed to update subscription plan.",
                Data = null
            });
        }
    }
}
