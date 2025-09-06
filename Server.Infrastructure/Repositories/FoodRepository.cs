using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Domain.Enums;
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
                                        .ThenInclude(fn => fn.Nutrient)
                                      .Include(f => f.FoodAllergies)
                                      .Include(f => f.FoodCategory)
                                      .Include(f => f.FoodDiseases)
                                      .FirstOrDefaultAsync(f => f.Id.Equals(foodId));
        }

        public async Task<Food> GetFoodByName(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(f => f.Name.Equals(name));
        }

        public async Task<List<Food>> GetFoodsAsync()
        {
            return await _context.Food.Include(f => f.FoodNutrients)
                                        .ThenInclude(fn => fn.Nutrient)
                                      .Include(f => f.FoodAllergies)
                                      .Include(f => f.FoodCategory)
                                      .Include(f => f.FoodDiseases)
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

        public async Task<List<Guid>> GetFoodWarningIdsByAllergiesAndDiseases(
    List<Guid> allergyIds,
    List<Guid> diseaseIds)
        {
            var foodIds = new List<Guid>();

            if (allergyIds is not null && allergyIds.Any())
            {
                var allergyFoodIds = await _dbSet
                    .Where(f => f.FoodAllergies.Any(a => allergyIds.Contains(a.AllergyId)))
                    .Select(f => f.Id)
                    .ToListAsync();

                foodIds.AddRange(allergyFoodIds);
            }

            if (diseaseIds is not null && diseaseIds.Any())
            {
                var diseaseFoodIds = await _dbSet
                    .Where(f => f.FoodDiseases.Any(dw => diseaseIds.Contains(dw.DiseaseId) && dw.Status == FoodDiseaseStatus.Warning))
                    .Select(f => f.Id)
                    .ToListAsync();

                foodIds.AddRange(diseaseFoodIds);
            }

            return foodIds.Distinct().ToList();
        }

        public async Task<List<Food>> GetFoodWarningsByAllergiesAndDiseases(
    List<Guid>? allergyIds,
    List<Guid>? diseaseIds)
        {
            var query = _dbSet.AsQueryable().AsNoTracking().AsSplitQuery();

            if (allergyIds is not null && allergyIds.Any())
            {
                query = query.Where(f =>
                    f.FoodAllergies.Any(a => allergyIds.Contains(a.AllergyId)));
            }

            if (diseaseIds is not null && diseaseIds.Any())
            {
                query = query.Where(f =>
                    f.FoodDiseases.Any(dw => diseaseIds.Contains(dw.DiseaseId) && dw.Status == FoodDiseaseStatus.Warning));
            }

            return await query
                .Include(f => f.FoodAllergies)
                .Include(f => f.FoodDiseases)
                .Include(f => f.FoodNutrients)
                    .ThenInclude(fn => fn.Nutrient)
                .ToListAsync();
        }
    }
}
