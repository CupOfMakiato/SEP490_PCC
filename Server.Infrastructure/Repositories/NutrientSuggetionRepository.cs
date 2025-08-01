using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class NutrientSuggetionRepository : GenericRepository<NutrientSuggetion>, INutrientSuggetionRepository
    { 

        public NutrientSuggetionRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
        }

        public async Task<List<NutrientSuggetion>> GetNutrientSuggetionListWithAttribute(Guid ageGroupId, int trimester)
        {
            return await _dbSet
                .Include(ns => ns.NutrientSuggestionAttributes
                    .Where(nsa => nsa.Trimester == trimester && ageGroupId.Equals(ageGroupId)))
                .ThenInclude(nas => nas.Attribute)
                .ThenInclude(a => a.Nutrient)
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();
        }
    }
}
