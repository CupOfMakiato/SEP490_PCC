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

        public async Task<bool> CreateFoodRecommendation(Guid userId)
        {
            try
            {
                var currentGrowthData = await _unitOfWork.GrowthDataRepository.GetActiveGrowthDataByUserId(userId);
                
                //var recommendRules = await _unitOfWork.SuggestionRuleRepository

                var recommendationHistory = new FoodRecommendationHistory()
                {
                    RecommededAt = DateTime.Now,
                    GrowthData = currentGrowthData,
                    Source = "System",

                };

                await _unitOfWork.FoodRecommendationHistoryRepository.AddAsync(recommendationHistory);
                return await _unitOfWork.SaveChangeAsync() > 0;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }    
        }
    }
}
