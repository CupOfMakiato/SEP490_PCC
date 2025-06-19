using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class FoodRecommendationHistoryService : IFoodRecommendationHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodRecommendationHistoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<FoodRecommendationHistory> UserViewMealLog(Guid growDataId, DateOnly date)
        {
            return await _unitOfWork.FoodRecommendationHistoryRepository.GetByGrowthIdAndDate(growDataId, date);
        }

        public async Task<FoodRecommendationHistory> UserViewMealLog(Guid growDataId, int week)
        {
            return await _unitOfWork.FoodRecommendationHistoryRepository.GetByGrowthIdAndWeek(growDataId, week);
        }

        public async Task<FoodRecommendationHistory> UserViewMealLog(Guid growDataId, int weekInMonth, int month)
        {
            return await _unitOfWork.FoodRecommendationHistoryRepository.GetByGrowthIdAndWeekInMonth(growDataId, weekInMonth, month);
        }

        public async Task<FoodRecommendationHistory> UserViewMealLog(Guid growDataId)
        {
            return await _unitOfWork.FoodRecommendationHistoryRepository.GetInCurrentWeekByGrowthId(growDataId);
        }

        public async Task<List<FoodRecommendationHistory>> GetGrowthDataMealLog(Guid growDataId)
        {
            return await _unitOfWork.FoodRecommendationHistoryRepository.GetByGrowthId(growDataId);
        }
    }
}
