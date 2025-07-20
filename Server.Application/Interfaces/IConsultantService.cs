using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Consultant;

namespace Server.Application.Interfaces
{
    public interface IConsultantService
    {
        public Task<Result<ViewConsultantDTO>> GetConsultantByIdAsync(Guid consultantId);
        public Task<Result<bool>> SoftDeleteConsultant(Guid consultantId);
        public Task<Result<ViewConsultantDTO>> CreateConsultant(AddConsultantDTO consultant);
        public Task<Result<ViewConsultantDTO>> UpdateConsultant(UpdateConsultantDTO consultant);
    }
}
