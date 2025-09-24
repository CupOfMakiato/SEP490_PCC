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
            return await _context.Food
                .AsSplitQuery().
                AsNoTracking()
                .Select(fn => new Food
                {
                    Id = fn.Id,
                    Name = fn.Name,
                    Description = fn.Description,
                    ImageUrl = fn.ImageUrl,
                    PregnancySafe = fn.PregnancySafe,
                    FoodCategoryId = fn.FoodCategoryId,
                    SafetyNote = fn.SafetyNote,
                    FoodNutrients = fn.FoodNutrients.Select(n => new FoodNutrient
                    {
                        NutrientId = n.NutrientId,
                        AmountPerUnit = n.AmountPerUnit,
                        FoodEquivalent = n.FoodEquivalent,
                        NutrientEquivalent = n.NutrientEquivalent,
                        TotalWeight = n.TotalWeight,
                        Unit = n.Unit,
                        Nutrient = new Nutrient
                        {
                            Id = n.Nutrient.Id,
                            Name = n.Nutrient.Name,
                        }
                    }).ToList()
                })
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
            var query = _dbSet.AsQueryable()
                .AsNoTracking()
                .AsSplitQuery();

            var hasAllergies = allergyIds is { Count: > 0 };
            var hasDiseases = diseaseIds is { Count: > 0 };

            // Apply predicate based on available IDs
            if (hasAllergies && hasDiseases)
            {
                query = query.Where(f =>
                    f.FoodAllergies.Any(a => allergyIds.Contains(a.AllergyId)) ||
                    f.FoodDiseases.Any(d => diseaseIds.Contains(d.DiseaseId) &&
                                            d.Status == FoodDiseaseStatus.Warning));
            }
            else if (hasAllergies)
            {
                query = query.Where(f =>
                    f.FoodAllergies.Any(a => allergyIds.Contains(a.AllergyId)));
            }
            else if (hasDiseases)
            {
                query = query.Where(f =>
                    f.FoodDiseases.Any(d => diseaseIds.Contains(d.DiseaseId) &&
                                            d.Status == FoodDiseaseStatus.Warning));
            }
            else
            {
                query = query.Where(f => f.FoodAllergies.Any() || f.FoodDiseases.Any());
            }

            // Includes with filters
            query = query
                .Include(f => f.FoodAllergies
                    .Where(a => !hasAllergies || allergyIds.Contains(a.AllergyId)))
                    .ThenInclude(fa => fa.Allergy)
                .Include(f => f.FoodDiseases
                    .Where(d => !hasDiseases || diseaseIds.Contains(d.DiseaseId)))
                    .ThenInclude(fd => fd.Disease)
                .Include(f => f.FoodNutrients)
                    .ThenInclude(fn => fn.Nutrient);

            return await query.ToListAsync();
        }

    }
}
