using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Application.Repositories
{
    public interface ISubscriptionPlanRepository : IGenericRepository<SubscriptionPlan>
    {
        public Task<List<SubscriptionPlan>> GetAllSubscriptionPlans();
        public Task<SubscriptionPlan> GetSubscriptionPlanById(Guid id);
        public void DeleteSubscriptionPlan(SubscriptionPlan subscriptionPlan);
        Task<SubscriptionPlan?> GetSubscriptionPlanByName(SubscriptionName subscriptionName);
    }
}
