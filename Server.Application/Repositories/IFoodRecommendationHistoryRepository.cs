using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IFoodRecommendationHistoryRepository : IGenericRepository<DishesRecommendationHistory>
    {
        public Task<DishesRecommendationHistory> GetFoodRecommendationHistoryById(Guid id);
        public Task<List<DishesRecommendationHistory>> GetFoodRecommendationHistorys();
        public Task<DishesRecommendationHistory> GetByGrowthIdAndDate(Guid growthId, DateOnly date);
        public Task<DishesRecommendationHistory> GetByGrowthIdAndWeek(Guid growthId, int week);
        public Task<DishesRecommendationHistory> GetByGrowthIdAndWeekInMonth(Guid growthId, int week, int Month);
        public Task<DishesRecommendationHistory> GetInCurrentWeekByGrowthId(Guid growthId);
        public Task<List<DishesRecommendationHistory>> GetByGrowthId(Guid growthId);
    }
}
