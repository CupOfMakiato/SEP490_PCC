using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class NSAttributeRepository : GenericRepository<NSAttribute>, INSAttributeRepository
    {
        public NSAttributeRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService)
            : base(context, currentTime, claimsService)
        {
        }

        public async Task<NSAttribute> GetNSAttributeById(Guid id)
        {
            return await _dbSet
                .Include(a => a.Nutrient)
                .FirstOrDefaultAsync(a => a.Id.Equals(id));
        }

        public void Remove(NSAttribute nSAttribute)
        {
            _dbSet.Remove(nSAttribute);
        }
    }
}
