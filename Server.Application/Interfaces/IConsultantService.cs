using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Consultant;
using Server.Application.DTOs.User;

namespace Server.Application.Interfaces
{
    public interface IConsultantService
    {
        public Task<Result<ViewConsultantDTO>> GetConsultantByIdAsync(Guid consultantId);
        public Task<Result<bool>> SoftDeleteConsultant(Guid consultantId);
        public Task<Result<ViewConsultantDTO>> CreateConsultant(AddConsultantDTO consultant);
        public Task<Result<ViewConsultantDTO>> UpdateConsultant(UpdateConsultantDTO consultant);
        public Task<Result<ViewConsultantDTO>> GetConsultantByUserIdAsync(Guid userId);
        public Task<Result<List<GetUserDTO>>> GetAllUsersAsync();
        public Task<Result<List<GetUserDTO?>>> GetAllUsersByNameAsync(string? name);
    }
}
