using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface ISubscriptionPlanRepository : IGenericRepository<SubscriptionPlan>
    {
        public Task<List<SubscriptionPlan>> GetAllSubscriptionPlans();
        public Task<SubscriptionPlan> GetSubscriptionPlanById(Guid id);
        public void DeleteSubscriptionPlan(SubscriptionPlan subscriptionPlan);
    }
}
