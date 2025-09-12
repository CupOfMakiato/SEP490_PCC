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
                .Include(d => d.Foods).ThenInclude(fd => fd.Food).ThenInclude(f => f.FoodNutrients).ThenInclude(fn => fn.Nutrient)
                .AsSplitQuery()
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

            // Step 1: Query candidate dishes with calories
            var candidates = await _dbSet.AsNoTracking()
                .AsSplitQuery()
                .Include(f => f.Foods)
                    .ThenInclude(fd => fd.Food)
                        .ThenInclude(f => f.FoodNutrients)  
                .Select(d => new
                {
                    Dish = d,
                    TotalCalories = d.Foods
                        .SelectMany(fd => fd.Food.FoodNutrients
                            .Where(fn => fn.NutrientId == caloriesNutrientId)
                            .Select(fn => fn.AmountPerUnit * fd.Amount))
                        .Sum() / 100
                })
                .Where(x => !foodWarningIds.Any() || !x.Dish.Foods.Any(fd => foodWarningIds.Contains(fd.FoodId)))
                .ToListAsync();

            // Step 2: Shuffle candidates
            var rnd = new Random();
            candidates = candidates.OrderBy(_ => rnd.Next()).ToList();

            // Step 3: Try to find a valid combination
            List<Dish> selected = null;
            foreach (var combo in GetCombinations(candidates, numberOfDishes))
            {
                var total = combo.Sum(c => c.TotalCalories);
                if (total >= min && total <= max)
                {
                    selected = combo.Select(c => c.Dish).ToList();
                    break;
                }
            }

            return selected ?? new List<Dish>();


            // Helper method for combinations
            static IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<T> items, int length)
            {
                if (length == 1) return items.Select(t => new T[] { t });

                return GetCombinations(items, length - 1)
                    .SelectMany(t => items.Where(o => !t.Contains(o)),
                        (t1, t2) => t1.Concat(new T[] { t2 }));
            }
        }
    }
}
