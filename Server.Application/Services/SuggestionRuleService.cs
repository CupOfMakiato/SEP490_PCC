using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class SuggestionRuleService : ISuggestionRuleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SuggestionRuleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateSuggestionRule(SuggestionRule rule)
        {
            await _unitOfWork.SuggestionRuleRepository.AddAsync(rule);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> DeleteSuggestionRule(Guid id)
        {
            var rule = await _unitOfWork.SuggestionRuleRepository.GetByIdAsync(id);
            if (rule == null) return false;

            _unitOfWork.SuggestionRuleRepository.DeleteSuggestionRule(rule);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<SuggestionRule> GetSuggestionRuleByIdAsync(Guid id)
        {
            return await _unitOfWork.SuggestionRuleRepository.GetSuggestionRuleById(id);
        }

        public async Task<List<SuggestionRule>> GetSuggestionRulesAsync()
        {
            return await _unitOfWork.SuggestionRuleRepository.GetSuggestionRules();
        }

        public async Task<bool> SoftDeleteSuggestionRule(Guid id)
        {
            var rule = await _unitOfWork.SuggestionRuleRepository.GetByIdAsync(id);
            if (rule == null) 
                return false;

            _unitOfWork.SuggestionRuleRepository.SoftRemove(rule);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UpdateSuggestionRule(SuggestionRule rule)
        {
            _unitOfWork.SuggestionRuleRepository.Update(rule);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }

}
