using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.ClinicWorkRule;

namespace Server.Application.Interfaces
{
    public interface IClinicWorkRuleService
    {
        public Task<Result<ViewClinicWorkRuleDTO>> GetClinicWorkRuleAsync(Guid clinicId);
        public Task<Result<bool>> SoftDeleteSclinicWorkRule(Guid clinicId);
        public Task<Result<ViewClinicWorkRuleDTO>> CreateClinicWorkRule(AddClinicWorkRuleDTO clinicWorkRule);
        public Task<Result<ViewClinicWorkRuleDTO>> UpdateClinicWorkRule(UpdateClinicWorkRuleDTO clinicWorkRule);
    }
}
