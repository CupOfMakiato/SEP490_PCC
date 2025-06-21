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

        public async Task<Food> GetFoodByIdAsync(Guid foodId)
        {
            return await _context.Food.Include(f => f.FoodVitamins)
                                      .Include(f => f.FoodAllergy)
                                      .Include(f => f.FoodCategory)
                                      .Include(f => f.SuggestionRule)
                                      .Include(f => f.FoodDiseaseWarning)
                                      .FirstOrDefaultAsync(f => f.Id.Equals(foodId));
        }

        public async Task<List<Food>> GetFoodsAsync()
        {
            return await _context.Food.Include(f => f.FoodVitamins)
                                      .Include(f => f.FoodAllergy)
                                      .Include(f => f.FoodCategory)
                                      .Include(f => f.SuggestionRule)
                                      .Include(f => f.FoodDiseaseWarning)
                                      .ToListAsync();
        }
    }
}
