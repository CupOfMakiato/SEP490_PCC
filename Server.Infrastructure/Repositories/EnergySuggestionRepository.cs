using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class EnergySuggestionRepository : GenericRepository<EnergySuggestion>, IEnergySuggestionRepository
    {
        public EnergySuggestionRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService)
            : base(context, currentTime, claimsService)
        {
        }

        public async Task<EnergySuggestion> GetEnergySuggestionByAgeGroupAndTrimester(int age, int trimester)
        {
            return await _dbSet.FirstOrDefaultAsync(es => es.AgeGroup.FromAge <= age && es.AgeGroup.FromAge >= age && es.Trimester == trimester);
        }
    }
}
