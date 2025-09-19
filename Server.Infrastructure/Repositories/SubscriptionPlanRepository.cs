using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class SubscriptionPlanRepository : GenericRepository<SubscriptionPlan>, ISubscriptionPlanRepository
    {
        public SubscriptionPlanRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService) : base(context, currentTime, claimsService)
        {
        }

        public void DeleteSubscriptionPlan(SubscriptionPlan subscriptionPlan)
        {
            _dbSet.Remove(subscriptionPlan);
        }

        public async Task<List<SubscriptionPlan>> GetAllSubscriptionPlans()
        {
            return await _dbSet.Include(sp => sp.UserSubscriptions).ToListAsync();
        }

        public async Task<SubscriptionPlan> GetSubscriptionPlanById(Guid id)
        {
            return await _dbSet.Include(sp => sp.UserSubscriptions).FirstOrDefaultAsync(sp => sp.Id.Equals(id));
        }
    }
}
