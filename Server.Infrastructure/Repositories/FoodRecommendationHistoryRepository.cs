using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class FoodRecommendationHistoryRepository : GenericRepository<FoodRecommendationHistory>, IFoodRecommendationHistoryRepository
    {
        public FoodRecommendationHistoryRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
        }

        public async Task<FoodRecommendationHistory> GetByGrowthIdAndDate(Guid growthId, DateOnly date)
        {
            return await _dbSet
                .Include(frh => frh.Versions.OrderByDescending(v => v.Version).First())
                .FirstOrDefaultAsync(frh => frh.GrowthDataId.Equals(growthId)
                && frh.CreationDate.Date.Equals(date)
                && frh.PregnancyWeek() > 0
                && frh.PregnancyWeek() <= 40);
        }

        public async Task<FoodRecommendationHistory> GetByGrowthIdAndWeek(Guid growthId, int week)
        {
            return await _dbSet
                .Include(frh => frh.Versions.OrderByDescending(v => v.Version).First())
                .FirstOrDefaultAsync(frh => frh.GrowthDataId.Equals(growthId) && frh.PregnancyWeek() == week);
        }

        public async Task<FoodRecommendationHistory> GetByGrowthIdAndWeekInMonth(Guid growthId, int week, int month)
        {
            return await _dbSet
                .Include(frh => frh.Versions.OrderByDescending(v => v.Version).First())
                .FirstOrDefaultAsync(frh => frh.GrowthDataId.Equals(growthId) && frh.PregnancyWeek() == week + month * 4);
        }

        public async Task<FoodRecommendationHistory> GetFoodRecommendationHistoryById(Guid id)
        {
            return await _dbSet.Include(frh => frh.GrowthData).FirstOrDefaultAsync(frh => frh.Equals(id));
        }

        public async Task<List<FoodRecommendationHistory>> GetFoodRecommendationHistorys()
        {
            return await _dbSet.Include(frh => frh.GrowthData).ToListAsync();
        }

        public async Task<FoodRecommendationHistory> GetInCurrentWeekByGrowthId(Guid growthId)
        {
            return await _dbSet
                .Include(frh => frh.Versions.OrderByDescending(v => v.Version).First())
                .Where(frh => frh.GrowthDataId.Equals(growthId))
                .OrderByDescending(frh => frh.RecommededAt)
                .FirstOrDefaultAsync();
        }

        public async Task<List<FoodRecommendationHistory>> GetByGrowthId(Guid growthId)
        {
            return await _dbSet
                .Include(frh => frh.Versions.OrderByDescending(v => v.Version).First())
                .Where(frh => frh.GrowthDataId.Equals(growthId))
                .OrderByDescending(frh => frh.RecommededAt)
                .ToListAsync();
        }
    }
}
