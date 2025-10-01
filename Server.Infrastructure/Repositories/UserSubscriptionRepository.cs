using Microsoft.EntityFrameworkCore;
using Server.Application.DTOs.Payment;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Domain.Enums;
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

        public async Task<List<UserSubscriptionStatisticsRaw>> GetUserStatisticsByMonthAsync(int year)
        {
            return await _dbSet
                .Where(us => us.CreationDate.Year == year)
                .GroupBy(us => new { us.CreationDate.Year, us.CreationDate.Month })
                .Select(g => new UserSubscriptionStatisticsRaw
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    ActiveCount = g.Count(x => x.Status == UserSubscriptionStatus.Active),
                    ExpiredCount = g.Count(x => x.Status == UserSubscriptionStatus.Expired),
                    CanceledCount = g.Count(x => x.Status == UserSubscriptionStatus.Canceled),
                    PendingCount = g.Count(x => x.Status == UserSubscriptionStatus.Pending),
                    TotalUsers = g.Count(),
                    TotalMonthsUsed = g.Sum(x => EF.Functions.DateDiffMonth(x.CreationDate, x.ExpiresAt))
                })
                .ToListAsync();
        }

        public async Task<List<UserSubscriptionStatisticsRaw>> GetUserStatisticsByQuarterAsync(int year)
        {
            return await _dbSet
                .Where(us => us.CreationDate.Year == year)
                .GroupBy(us => new { us.CreationDate.Year, Quarter = ((us.CreationDate.Month - 1) / 3) + 1 })
                .Select(g => new UserSubscriptionStatisticsRaw
                {
                    Year = g.Key.Year,
                    Quarter = g.Key.Quarter,
                    ActiveCount = g.Count(x => x.Status == UserSubscriptionStatus.Active),
                    ExpiredCount = g.Count(x => x.Status == UserSubscriptionStatus.Expired),
                    CanceledCount = g.Count(x => x.Status == UserSubscriptionStatus.Canceled),
                    PendingCount = g.Count(x => x.Status == UserSubscriptionStatus.Pending),
                    TotalUsers = g.Count(),
                    TotalMonthsUsed = g.Sum(x => EF.Functions.DateDiffMonth(x.CreationDate, x.ExpiresAt))
                })
                .ToListAsync();
        }

        public async Task<List<UserSubscriptionStatisticsRaw>> GetUserStatisticsByYearAsync()
        {
            return await _dbSet
                .GroupBy(us => us.CreationDate.Year)
                .Select(g => new UserSubscriptionStatisticsRaw
                {
                    Year = g.Key,
                    ActiveCount = g.Count(x => x.Status == UserSubscriptionStatus.Active),
                    ExpiredCount = g.Count(x => x.Status == UserSubscriptionStatus.Expired),
                    CanceledCount = g.Count(x => x.Status == UserSubscriptionStatus.Canceled),
                    PendingCount = g.Count(x => x.Status == UserSubscriptionStatus.Pending),
                    TotalUsers = g.Count(),
                    TotalMonthsUsed = g.Sum(x => EF.Functions.DateDiffMonth(x.CreationDate, x.ExpiresAt))
                })
                .ToListAsync();
        }
    }
}
