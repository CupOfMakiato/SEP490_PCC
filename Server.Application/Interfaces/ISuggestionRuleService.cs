using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface ISuggestionRuleService
    {
        Task<SuggestionRule> GetSuggestionRuleByIdAsync(Guid id);
        Task<List<SuggestionRule>> GetSuggestionRulesAsync();
        Task<bool> CreateSuggestionRule(SuggestionRule rule);
        Task<bool> UpdateSuggestionRule(SuggestionRule rule);
        Task<bool> DeleteSuggestionRule(Guid id);
        Task<bool> SoftDeleteSuggestionRule(Guid id);
    }
}
