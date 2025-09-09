using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Meal;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface IMealService
    {
        Task<Result<MealPlanResponse>> BuildWeeklyMealPlan(BuildWeeklyMealPlanRequest request);
        Task<Result<MealDto>> MealsSuggestion(MealsSuggestionRequest request);
        Task<Result<Meal>> CreateMeal(CreateMealRequest request);
        Task<Result<MealDto>> UpdateMeal(Guid id, UpdateMealRequest request);
        Task<Result<bool>> DeleteMeal(Guid id);
    }
}
