using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface ISuggestionRuleRepository : IGenericRepository<SuggestionRule>
    {
        Task<SuggestionRule> GetSuggestionRuleById(Guid id);
        Task<List<SuggestionRule>> GetSuggestionRules();
        void DeleteSuggestionRule(SuggestionRule rule);
    }
}
