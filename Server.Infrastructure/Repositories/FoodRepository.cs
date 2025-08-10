using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Repositories
{
    public class FoodRepository : GenericRepository<Food>, IFoodRepository
    {
        private readonly AppDbContext _context;

        public FoodRepository(AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(context,
                  timeService,
                  claimsService)
        {
            _context = context;
        }

        public void DeleteFood(Food food)
        {
            _context.Food.Remove(food);
        }

        public async Task<bool> DeleteFoodNutrient(Guid foodId, Guid NutrientId)
        {
            var foodNutrient = await _context.FoodNutrient.FirstOrDefaultAsync(fn => fn.FoodId == foodId && fn.NutrientId == NutrientId);
            if (foodNutrient == null)
                return false;
            _context.FoodNutrient.Remove(foodNutrient);
            return true;
        }

        public async Task<Food> GetFoodByIdAsync(Guid foodId)
        {
            return await _context.Food.Include(f => f.FoodNutrients)
                                      .Include(f => f.FoodAllergy)
                                      .Include(f => f.FoodCategory)
                                      .Include(f => f.FoodDiseaseWarning)
                                      .FirstOrDefaultAsync(f => f.Id.Equals(foodId));
        }

        public async Task<Food> GetFoodByName(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(f => f.Name.Equals(name));
        }

        public async Task<List<Food>> GetFoodsAsync()
        {
            return await _context.Food.Include(f => f.FoodNutrients)
                                      .Include(f => f.FoodAllergy)
                                      .Include(f => f.FoodCategory)
                                      .Include(f => f.FoodDiseaseWarning)
                                      .ToListAsync();
        }

        public async Task<Food> GetFoodWithFoodNutrient(Guid foodId, Guid NutrientId)
        {
            return await _dbSet
                .Where(f => f.Id == foodId && f.FoodNutrients
                    .Any(fn => fn.NutrientId == NutrientId))
                .Include(f => f.FoodNutrients.Where(fn => fn.NutrientId == NutrientId))    
                .FirstOrDefaultAsync();
        }
    }
}
