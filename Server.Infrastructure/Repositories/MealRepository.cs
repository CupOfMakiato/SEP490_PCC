using Microsoft.EntityFrameworkCore;
using Server.Application.DTOs.Dish;
using Server.Application.DTOs.Meal;
using Server.Application.DTOs.User;
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

        public void DeleteMeal(Meal meal)
        {
            _dbSet.Remove(meal);
        }

        public async Task<List<Meal>> GetMeals()
        {
            return await _dbSet
                .Include(m => m.DishMeals)
                    .ThenInclude(dm => dm.Dish)
                        .ThenInclude(d => d.Foods)
                            .ThenInclude(fd => fd.Food)
                                .ThenInclude(f => f.FoodNutrients)
                                .AsSplitQuery()
                .ToListAsync();
        }

        public async Task<Meal> GetMealsById(Guid mealId)
        {
            return await _dbSet
                .Include(m => m.DishMeals)
                    .ThenInclude(dm => dm.Dish)
                        .ThenInclude(d => d.Foods)
                            .ThenInclude(fd => fd.Food)
                                .ThenInclude(f => f.FoodNutrients)
                                .AsSplitQuery()
                .FirstOrDefaultAsync(m => m.Id == mealId);
        }

        public async Task<List<MealDto>> GetMealsWithCalories(Guid caloriesNutrientId)
        {
            var result = await _dbSet
                .Select(m => new MealDto
                {
                    MealType = m.MealType,
                    TotalCalories = m.DishMeals
                        .SelectMany(dm => dm.Dish.Foods)
                        .SelectMany(fd => fd.Food.FoodNutrients
                            .Where(fn => fn.NutrientId == caloriesNutrientId)
                            .Select(fn => fn.AmountPerUnit * fd.Amount))
                        .Sum()/100,

                    Dishes = m.DishMeals.Select(dm => new DishDto
                    {
                        Id = dm.Dish.Id,
                        DishName = dm.Dish.DishName,
                        ImageUrl = dm.Dish.ImageUrl,
                        Description = dm.Dish.Description,
                        Calories = dm.Dish.Foods
                            .SelectMany(fd => fd.Food.FoodNutrients
                                .Where(fn => fn.NutrientId == caloriesNutrientId)
                                .Select(fn => fn.AmountPerUnit * fd.Amount))
                            .Sum()/100
                    }).ToList()
                })
                .ToListAsync();

            return result;
        }
    }
}
