using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class NutrientSuggetionRepository : GenericRepository<NutrientSuggetion>, INutrientSuggetionRepository
    {
        private readonly AppDbContext _context;

        public NutrientSuggetionRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _context = dbContext;
        }

        public async Task CreateNutrientSuggetionAttribute(NutrientSuggestionAttribute attribute)
        {
            await _context.NutrientSuggestionsAttributes.AddAsync(attribute);
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
