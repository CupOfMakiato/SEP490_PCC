using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IMealRepository : IGenericRepository<Meal>
    {
        Task<List<Meal>> GetMealsByCalories(double calories,Guid caloriesNutrientId);
        Task<List<Meal>> GetMealsByCalories(double calories, List<Guid> DishesId, Guid caloriesNutrientId);
    }
}
