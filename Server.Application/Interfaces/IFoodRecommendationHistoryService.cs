using Server.Application.Abstractions.Shared;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface IFoodRecommendationHistoryService
    {
        public Task<FoodRecommendationHistory> UserViewMealLog(Guid growDataId, DateOnly date);
        public Task<FoodRecommendationHistory> UserViewMealLog(Guid growDataId, int week);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="growDataId"></param>
        /// <param name="weekInMonth">Tuần thứ bao nhiêu đó trong tháng ex: 1,2,3,4</param>
        /// <param name="month">Tháng thứ bao nhiêu đó trong thai kỳ</param>
        /// <returns></returns>
        public Task<FoodRecommendationHistory> UserViewMealLog(Guid growDataId, int weekInMonth, int month);
        /// <summary>
        /// Xem cái thực phẩm đề xuất trong tuần hiện tại, nếu đã hết thai kỳ thì sẽ trả về null
        /// </summary>
        /// <param name="growDataId"></param>
        /// <returns></returns>
        public Task<FoodRecommendationHistory> UserViewMealLog(Guid growDataId);
        public Task<List<FoodRecommendationHistory>> GetGrowthDataMealLog(Guid userId);
        public Task<Result<FoodRecommendationHistory>> CreateFoodRecommendation(Guid growthDataId);
    }
}
