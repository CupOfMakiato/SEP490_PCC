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
    public class SuggestionRuleRepository : GenericRepository<SuggestionRule>, ISuggestionRuleRepository
    {
        public SuggestionRuleRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
        }

        public async Task<SuggestionRule> GetSuggestionRule(Guid suggestionRuleId)
        {
            return await _dbSet.Include(sr => sr.Foods).FirstOrDefaultAsync(sr => sr.Equals(suggestionRuleId));
        }

        public async Task<List<SuggestionRule>> GetSuggestionRules()
        {
            return await _dbSet.Include(sr => sr.Foods).ToListAsync();
        }

        public Task<List<SuggestionRule>> GetSuggestionRulesByWeek(int week)
        {
            throw new NotImplementedException();
        }
    }
}
