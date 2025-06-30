using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class SuggestionRuleRepository : GenericRepository<SuggestionRule>, ISuggestionRuleRepository
    {
        private readonly AppDbContext _context;

        public SuggestionRuleRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService)
            : base(context, currentTime, claimsService)
        {
            _context = context;
        }

        public void DeleteSuggestionRule(SuggestionRule rule)
        {
            _context.SuggestionRule.Remove(rule);
        }

        public async Task<SuggestionRule> GetSuggestionRuleById(Guid id)
        {
            return await _context.SuggestionRule
                .Include(r => r.Foods)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<SuggestionRule>> GetSuggestionRules()
        {
            return await _context.SuggestionRule
                .Include(r => r.Foods)
                .ToListAsync();
        }

        public async Task<List<SuggestionRule>> GetSuggestionRulesForUser(int week)
        {
            var currentTrimester = week switch
            {
                < 14 => 1,
                < 28 => 2,
                _ => 3
            };
            return await _dbSet.Where(g => week <= g.MaxWeek && week >= g.MinWeek && g.Trimester == currentTrimester && g.IsPositive).ToListAsync();
        }
    }

}
