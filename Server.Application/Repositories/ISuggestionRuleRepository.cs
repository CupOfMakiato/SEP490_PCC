using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface ISuggestionRuleRepository : IGenericRepository<SuggestionRule>
    {
        public Task<SuggestionRule> GetSuggestionRule(Guid suggestionRuleId);
        public Task<List<SuggestionRule>> GetSuggestionRules();
    }
}
