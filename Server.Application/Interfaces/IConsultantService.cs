using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Consultant;

namespace Server.Application.Interfaces
{
    public interface IConsultantService
    {
        public Task<Result<ViewConsultantDTO>> GetConsultantByIdAsync(Guid consultantId);
        public Task<Result<List<ViewConsultantDTO>>> GetConsultantByNameAsync(string name);
        public Task<Result<List<ViewConsultantDTO>>> GetConsultantsAsync();
        public Task<Result<object>> SoftDeleteConsultant(Guid consultantId);
        public Task<Result<object>> CreateConsultant(AddConsultantDTO consultant);
        public Task<Result<object>> UpdateConsultant(UpdateConsultantDTO consultant);
    }
}
