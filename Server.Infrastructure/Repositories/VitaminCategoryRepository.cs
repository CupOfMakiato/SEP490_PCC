using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class VitaminCategoryRepository : GenericRepository<VitaminCategory>, IVitaminCategoryRepository
    {
        private readonly AppDbContext _context;

        public VitaminCategoryRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService) : base(context, currentTime, claimsService)
        {
            _context = context;
        }

        public async Task<VitaminCategory> GetVitaminCategoryById(Guid vitaminCategoryId)
        {
            return await _context.VitaminCategory.Include(v => v.Vitamins)
                                         .FirstOrDefaultAsync();
        }

        public async Task<List<VitaminCategory>> GetVitaminCategorys()
        {
            return await _context.VitaminCategory.Include(v => v.Vitamins)
                                         .ToListAsync();
        }
    }
}
