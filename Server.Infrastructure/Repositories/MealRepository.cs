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

        public async Task<List<MealDto>> GetMealsWithCalories(Guid caloriesNutrientId)
        {
            return await _dbSet
                .Select(m => new MealDto
                {
                    MealType = m.MealType,
                    TotalCalories = m.DishMeals
                        .SelectMany(dm => dm.Dish.Foods)
                        .SelectMany(fd => fd.Food.FoodNutrients
                            .Where(fn => fn.NutrientId == caloriesNutrientId)
                            .Select(fn => fn.AmountPerUnit * fd.Amount))
                        .Sum(),

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
                            .Sum()
                    }).ToList()
                })
                .ToListAsync();
        }
    }
}
