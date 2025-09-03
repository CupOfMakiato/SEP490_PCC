using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class MealRepository : GenericRepository<Meal>, IMealRepository
    {
        public MealRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }

        public async Task<List<Meal>> GetMealsByCalories(double calories, Guid caloriesNutrientId)
        {
            double min = calories - 50;
            double max = calories + 50;

            // Step 1: Query chỉ lấy MealId + tổng calories
            var mealCandidates = await _dbSet
                .Select(m => new
                {
                    m.Id,
                    TotalCalories = m.DishMeals
                        .SelectMany(dm => dm.Dish.Foods)
                        .SelectMany(fd => fd.Food.FoodNutrients
                            .Where(fn => fn.NutrientId == caloriesNutrientId)
                            .Select(fn => fn.AmountPerUnit * fd.Amount)
                        )
                        .Sum()
                })
                .Where(x => x.TotalCalories >= min && x.TotalCalories <= max)
                .ToListAsync();

            // Step 2: Random chọn 7 Id
            var random = new Random();
            var selectedMealIds = mealCandidates
                .OrderBy(x => random.Next())
                .Take(7)
                .Select(x => x.Id)
                .ToList();

            if (!selectedMealIds.Any())
                return new List<Meal>();

            // Step 3: Query lại để load Meal đầy đủ
            return await _dbSet
                .Where(m => selectedMealIds.Contains(m.Id))
                .Include(m => m.DishMeals)
                    .ThenInclude(dm => dm.Dish)
                        .ThenInclude(d => d.Foods)
                            .ThenInclude(fd => fd.Food)
                                .ThenInclude(f => f.FoodNutrients)
                .ToListAsync();
        }


        public async Task<List<Meal>> GetMealsByCalories(double calories, List<Guid> dishesId, Guid caloriesNutrientId)
        {
            double min = calories - 50;
            double max = calories + 50;

            var mealCandidates = await _dbSet
                .Where(m => m.DishMeals.Any(dm => dishesId.Contains(dm.DishId)))
                .Select(m => new
                {
                    m.Id,
                    TotalCalories = m.DishMeals
                        .SelectMany(dm => dm.Dish.Foods)
                        .SelectMany(fd => fd.Food.FoodNutrients
                            .Where(fn => fn.NutrientId == caloriesNutrientId)
                            .Select(fn => fn.AmountPerUnit * fd.Amount)
                        )
                        .Sum()
                })
                .Where(x => x.TotalCalories >= min && x.TotalCalories <= max)
                .ToListAsync();

            var random = new Random();
            var selectedMealIds = mealCandidates
                .OrderBy(x => random.Next())
                .Take(7)
                .Select(x => x.Id)
                .ToList();

            if (!selectedMealIds.Any())
                return new List<Meal>();

            return await _dbSet
                .Where(m => selectedMealIds.Contains(m.Id))
                .Include(m => m.DishMeals)
                    .ThenInclude(dm => dm.Dish)
                        .ThenInclude(d => d.Foods)
                            .ThenInclude(fd => fd.Food)
                                .ThenInclude(f => f.FoodNutrients)
                .ToListAsync();
        }
    }
}
