using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class DishRepository : GenericRepository<Dish>, IDishRepository
    {
        public DishRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService)
            : base(context, currentTime, claimsService)
        {
        }

        public async Task<List<Dish>> GetAllDishes()
        {
            return await _dbSet
                .Include(d => d.HistoryDish)
                .Include(d => d.DishMeals)
                .Include(d => d.Foods).ThenInclude(fd => fd.Food)
                .ToListAsync();  
        }

        public async Task<Dish> GetDishById(Guid dishId)
        {
            return await _dbSet
                .Include(d => d.HistoryDish)
                .Include(d => d.DishMeals)
                .Include(d => d.Foods).ThenInclude(fd => fd.Food)
                .FirstOrDefaultAsync(d => d.Id == dishId);
        }

        public void RemoveDish(Dish dish)
        {
            _dbSet.Remove(dish);
        }

        public async Task<List<Dish>> GetDishesByCaloriesAndMealType(double calorieTarget, Guid caloriesNutrientId, List<Guid>? foodWarningIds, int numberOfDishes)
        {
            double min = calorieTarget - 50;
            double max = calorieTarget + 50;

            var query = _dbSet.AsNoTracking().AsSplitQuery()
                .Select(d => new
                {
                    Dish = d,
                    TotalCalories = d.Foods
                        .SelectMany(fd => fd.Food.FoodNutrients
                            .Where(fn => fn.NutrientId == caloriesNutrientId)
                            .Select(fn => fn.AmountPerUnit * fd.Amount))
                        .Sum()
                });

            if (foodWarningIds is not null && foodWarningIds.Any())
            {
                query = query.Where(x => !x.Dish.Foods.Any(fd => foodWarningIds.Contains(fd.FoodId)));
            }         

            query = query.Where(x => x.TotalCalories >= min && x.TotalCalories <= max);

            return await query
                .Select(x => x.Dish)
                .Include(d => d.Foods)
                    .ThenInclude(fd => fd.Food)
                        .ThenInclude(f => f.FoodNutrients).
                            ThenInclude(fn => fn.Nutrient)
                .OrderBy(x => Guid.NewGuid())
                .Take(numberOfDishes)
                .ToListAsync();
        }
    }
}
