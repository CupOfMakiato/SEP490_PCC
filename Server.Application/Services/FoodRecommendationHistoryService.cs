using Server.Application.Abstractions.Shared;
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

        public async Task<Result<FoodRecommendationHistory>> CreateFoodRecommendation(Guid userId)
        {
            try
            {
                var currentGrowthData = await _unitOfWork.GrowthDataRepository.GetActiveGrowthDataByUserId(userId);
                if (currentGrowthData is null)
                    return new Result<FoodRecommendationHistory>()
                    {
                        Error = 1,
                        Message = "Current GrowData of this user doesn't exist",
                    };

                //User dont include current growthData
                var user = await _unitOfWork.UserRepository.GetUserById(userId); 

                var currentTrimester = currentGrowthData.GetCurrentTrimester(DateTime.Now);
  
                var ageGroup = await _unitOfWork.AgeGroupRepository.GetGroupByUserDateOfBirthAndTrimester((DateTime)user.DateOfBirth, currentTrimester);
                if (currentGrowthData is null)
                    return new Result<FoodRecommendationHistory>()
                    {
                        Error = 1,
                        Message = "User's age are not in my system, please go to hospital",
                    };

                var energySuggestion = await _unitOfWork.EnergySuggestionRepository.GetEnergySuggestionByAgeGroupAndTrimester(DateTime.Now.Year - user.DateOfBirth.Value.Year, currentTrimester);

                

                var recommendationHistory = new FoodRecommendationHistory()
                {
                    RecommededAt = DateTime.Now,
                    GrowthData = currentGrowthData,
                    Source = "System",

                };

                await _unitOfWork.FoodRecommendationHistoryRepository.AddAsync(recommendationHistory);
                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    return new Result<FoodRecommendationHistory>()
                    {
                        Error = 0,
                        Message = "Create success",
                        Data = recommendationHistory
                    };
                }

                return new Result<FoodRecommendationHistory>()
                {
                    Error = 1,
                    Message = "Create fail",
                };
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return new Result<FoodRecommendationHistory>()
                {
                    Error = 1,
                    Message = ex.Message
                };
            }    
        }
    }
}
