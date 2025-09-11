using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class NutrientSuggetionRepository : GenericRepository<NutrientSuggestion>, INutrientSuggetionRepository
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

        public void DeleteNutrientSuggetion(NutrientSuggestion nutrientSuggetion)
        {
            _dbSet.Remove(nutrientSuggetion);
        }

        public async Task<List<NutrientSuggestion>> GetNutrientSuggetions()
        {
            return await _dbSet
                .Include(ns => ns.NutrientSuggestionAttributes)
                .ThenInclude(nas => nas.Attribute)
                .ThenInclude(a => a.Nutrient)
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();
        }

        public async Task<NutrientSuggestion> GetNutrientSuggetionById(Guid id)
        {
            return await _dbSet
                .Include(ns => ns.NutrientSuggestionAttributes)
                .ThenInclude(nas => nas.Attribute)
                .ThenInclude(a => a.Nutrient)
                .AsNoTracking()
                .AsSplitQuery()
                .FirstOrDefaultAsync(ns => ns.Id == id);
        }

        public async Task<List<NutrientSuggestion>> GetNutrientSuggetionListWithAttribute(Guid ageGroupId, int trimester)
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
