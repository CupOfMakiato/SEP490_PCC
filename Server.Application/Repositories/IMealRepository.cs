using Server.Application.DTOs.Meal;
using Server.Application.DTOs.User;
using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IMealRepository : IGenericRepository<Meal>
    {
        public Task<List<MealDto>> GetMealsWithCalories(Guid caloriesNutrientId);
        public Task<Meal> GetMealsById(Guid mealId);
        public void DeleteMeal(Meal meal);
    }
}
