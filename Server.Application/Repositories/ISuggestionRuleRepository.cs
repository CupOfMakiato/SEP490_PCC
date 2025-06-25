using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface ISuggestionRuleRepository : IGenericRepository<SuggestionRule>
    {
        public Task<SuggestionRule> GetSuggestionRule(Guid suggestionRuleId);
        public Task<List<SuggestionRule>> GetSuggestionRules();
        public Task<List<SuggestionRule>> GetSuggestionRulesByWeek(int week);
    }
}
