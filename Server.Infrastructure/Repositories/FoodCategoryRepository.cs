using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class FoodCategoryRepository : GenericRepository<FoodCategory>, IFoodCategoryRepository
    {
        private readonly AppDbContext _context;

        public FoodCategoryRepository(AppDbContext context, 
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(context,
                  timeService,
                  claimsService)
        {
            _context = context;
        }

        public void DeleteFoodCategory(FoodCategory foodCategory)
        {
            _dbSet.Remove(foodCategory);
        }

        public async Task<FoodCategory> GetFoodCategoryByIdAsync(Guid foodCategoryId) => 
            await _context.FoodCategory.Include(fc => fc.Foods).FirstOrDefaultAsync(fc => fc.Id.Equals(foodCategoryId));

        public async Task<FoodCategory> GetFoodCategoryByName(string Name) =>
            await _context.FoodCategory.FirstOrDefaultAsync(fc => fc.Name.Equals(Name));

        public async Task<List<FoodCategory>> GetFoodCategorysAsync() =>
            await _context.FoodCategory.Include(fc => fc.Foods).ToListAsync();
    }
}
