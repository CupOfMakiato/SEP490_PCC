using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IFoodRecommendationHistoryRepository : IGenericRepository<FoodRecommendationHistory>
    {
        public Task<FoodRecommendationHistory> GetFoodRecommendationHistoryById(Guid id);
        public Task<List<FoodRecommendationHistory>> GetFoodRecommendationHistorys();
        public Task<FoodRecommendationHistory> GetByGrowthIdAndDate(Guid growthId, DateOnly date);
        public Task<FoodRecommendationHistory> GetByGrowthIdAndWeek(Guid growthId, int week);
        public Task<FoodRecommendationHistory> GetByGrowthIdAndWeekInMonth(Guid growthId, int week, int Month);
        public Task<FoodRecommendationHistory> GetInCurrentWeekByGrowthId(Guid growthId);
        public Task<List<FoodRecommendationHistory>> GetByGrowthId(Guid growthId);
    }
}
