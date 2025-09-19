using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.SubscriptionPlan;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface ISubscriptionPlanService
    {
        public Task<List<SubscriptionPlan>> GetSubscriptionPlans();
        public Task<SubscriptionPlan> GetSubscriptionPlanById(Guid id);
        public Task<Result<SubscriptionPlan>> CreateSubscriptionPlan(CreateSubscriptionPlanRequest request);
        public Task<Result<SubscriptionPlan>> UpdateSubscriptionPlan(UpdateSubscriptionPlanRequest request);
        public Task<Result<bool>> DeleteSubscriptionPlan(Guid id);
        public Task<Result<bool>> ToggleSubscriptionPlanStatus(Guid id);
    }
}
