using Microsoft.EntityFrameworkCore;
using Server.Application.DTOs.Payment;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Domain.Enums;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService) : base(context, currentTime, claimsService)
        {
        }

        public async Task<List<RevenueStatisticsRaw>> GetRevenueByMonthAsync(int year)
        {
            return await _dbSet
                .Where(p => p.Status == PaymentStatus.Success && p.CreatedAt.Year == year)
                .GroupBy(p => new { p.CreatedAt.Year, p.CreatedAt.Month, p.UserSubscription.SubscriptionPlanId, p.UserSubscription.SubscriptionPlan.SubscriptionName })
                .Select(g => new RevenueStatisticsRaw
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    SubscriptionPlanId = g.Key.SubscriptionPlanId,
                    SubscriptionName = g.Key.SubscriptionName.ToString(),
                    Count = g.Count(),
                    TotalRevenue = g.Sum(x => x.Amount)
                })
                .ToListAsync();
        }

        public async Task<List<RevenueStatisticsRaw>> GetRevenueByQuarterAsync(int year)
        {
            return await _dbSet
                .Where(p => p.Status == PaymentStatus.Success && p.CreatedAt.Year == year)
                .GroupBy(p => new
                {
                    p.CreatedAt.Year,
                    Quarter = ((p.CreatedAt.Month - 1) / 3) + 1,
                    p.UserSubscription.SubscriptionPlanId,
                    p.UserSubscription.SubscriptionPlan.SubscriptionName
                })
                .Select(g => new RevenueStatisticsRaw
                {
                    Year = g.Key.Year,
                    Quarter = g.Key.Quarter,
                    SubscriptionPlanId = g.Key.SubscriptionPlanId,
                    SubscriptionName = g.Key.SubscriptionName.ToString(),
                    Count = g.Count(),
                    TotalRevenue = g.Sum(x => x.Amount)
                })
                .ToListAsync();
        }

        public async Task<List<RevenueStatisticsRaw>> GetRevenueByYearAsync()
        {
            return await _dbSet
                .Where(p => p.Status == PaymentStatus.Success)
                .GroupBy(p => new
                {
                    p.CreatedAt.Year,
                    p.UserSubscription.SubscriptionPlanId,
                    p.UserSubscription.SubscriptionPlan.SubscriptionName
                })
                .Select(g => new RevenueStatisticsRaw
                {
                    Year = g.Key.Year,
                    SubscriptionPlanId = g.Key.SubscriptionPlanId,
                    SubscriptionName = g.Key.SubscriptionName.ToString(),
                    Count = g.Count(),
                    TotalRevenue = g.Sum(x => x.Amount)
                })
                .ToListAsync();
        }
        public async Task<List<Payment>> GetSuccessfulPaymentsAsync()
        {
            return await _dbSet
                .Include(p => p.UserSubscription)
                    .ThenInclude(us => us.SubscriptionPlan)
                .Include(p => p.UserSubscription)
                    .ThenInclude(us => us.User)
                .Where(p => p.Status == PaymentStatus.Success)
                .ToListAsync();
        }

        public async Task<List<Payment>> GetPaymentsAsync(DateTime? fromDate, DateTime? toDate, Guid? userId, PaymentStatus? status)
        {
            var query = _dbSet
                .Include(p => p.UserSubscription)
                    .ThenInclude(us => us.SubscriptionPlan)
                .Include(p => p.UserSubscription)
                    .ThenInclude(us => us.User)
                .AsQueryable();

            if (fromDate.HasValue) query = query.Where(p => p.CreatedAt >= fromDate.Value);
            if (toDate.HasValue) query = query.Where(p => p.CreatedAt <= toDate.Value);
            if (userId.HasValue) query = query.Where(p => p.UserSubscription.UserId == userId.Value);
            if (status.HasValue) query = query.Where(p => p.Status == status.Value);

            return await query.OrderByDescending(p => p.CreatedAt).ToListAsync();
        }
    }
}
