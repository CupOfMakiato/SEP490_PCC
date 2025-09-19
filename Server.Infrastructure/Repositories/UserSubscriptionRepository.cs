using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class UserSubscriptionRepository : GenericRepository<UserSubscription>, IUserSubscriptionRepository
    {
        public UserSubscriptionRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService)
            : base(context, currentTime, claimsService)
        {
        }

        public async Task<UserSubscription> GetActiveSubscriptionByUserIdAsync(Guid userId)
        {
            return await _dbSet
                .Include(us => us.User)
                .Include(us => us.SubscriptionPlan)
                .Include(us => us.Payments)
                .Where(us => us.UserId == userId
                 && us.Status == Domain.Enums.UserSubscriptionStatus.Active)
                .OrderByDescending(us => us.NextBillingDate)
                .FirstOrDefaultAsync();
        }

        public async Task<List<UserSubscription>> GetAllActiveSubscriptionsAsync()
        {
            return await _dbSet
                .Include(us => us.User)
                .Include(us => us.SubscriptionPlan)
                .Include(us => us.Payments)
                .Where(us => us.NextBillingDate != null && us.NextBillingDate > DateTime.UtcNow)
                .ToListAsync();
        }

        public async Task<List<UserSubscription>> GetAllUserSubscriptionsAsync()
        {
            return await _dbSet
                .Include(us => us.User)
                .Include(us => us.SubscriptionPlan)
                .Include(us => us.Payments)
                .AsSplitQuery()
                .ToListAsync();
        }

        public async Task<List<UserSubscription>> GetSubscriptionsByUserIdAsync(Guid userId)
        {
            return await _dbSet
                .Include(us => us.User)
                .Include(us => us.SubscriptionPlan)
                .Include(us => us.Payments)
                .Where(us => us.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<UserSubscription>> GetSubscriptionsExpiringInDaysAsync(int days)
        {
            return await _dbSet
                .Include(us => us.User)
                .Include(us => us.SubscriptionPlan)
                .Include(us => us.Payments)
                .Where(us => us.NextBillingDate != null
                    && us.NextBillingDate.Value.Date == DateTime.UtcNow.AddDays(days).Date
                    && us.Status == Domain.Enums.UserSubscriptionStatus.Active)
                .ToListAsync();
        }

        public async Task<UserSubscription> GetUserSubscriptionByIdAsync(Guid userSubscriptionId)
        {
            return await _dbSet
                .Include(us => us.User)
                .Include(us => us.SubscriptionPlan)
                .Include(us => us.Payments)
                .OrderByDescending(us => us.NextBillingDate)
                .FirstOrDefaultAsync(us => us.Id == userSubscriptionId);
        }

        public async Task<UserSubscription> IsUserSubscriptionCreated(Guid subscriptionId, Guid userId)
        {
            return await _dbSet
                .Include(us => us.User)
                .Include(us => us.SubscriptionPlan)
                .FirstOrDefaultAsync(us => us.User.Id == userId && us.SubscriptionPlanId == subscriptionId);
        }
    }
}
