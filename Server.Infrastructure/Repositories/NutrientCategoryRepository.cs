using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class NutrientCategoryRepository : GenericRepository<NutrientCategory>, INutrientCategoryRepository
    {
        private readonly AppDbContext _context;

        public NutrientCategoryRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService) : base(context, currentTime, claimsService)
        {
            _context = context;
        }

        public void DeleteNutrientCategory(NutrientCategory nutrientCategory)
        {
            _dbSet.Remove(nutrientCategory);
        }

        public async Task<NutrientCategory> GetNutrientCategoryById(Guid vitaminCategoryId)
        {
            return await _context.NutrientCategory.Include(v => v.Nutrients)
                                         .FirstOrDefaultAsync();
        }

        public async Task<List<NutrientCategory>> GetNutrientCategorys()
        {
            return await _context.NutrientCategory.Include(v => v.Nutrients)
                                         .ToListAsync();
        }
    }
}
