using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.AgeGroup;

namespace Server.Application.Interfaces
{
    public interface IAgeGroupService
    {
        public Task<Result<AgeGroupDTO>> GetAgeGroupByIdAsync(Guid ageGroupId);
        public Task<Result<List<AgeGroupDTO>>> GetAgeGroupsAsync();
        public Task<Result<AgeGroupDTO>> SoftDeleteAgeGroup(Guid ageGroupId);
        public Task<Result<AgeGroupDTO>> DeleteAgeGroup(Guid ageGroupId);
        public Task<Result<AgeGroupDTO>> CreateAgeGroup(CreateAgeGroupRequest request);
        public Task<Result<AgeGroupDTO>> UpdateAgeGroup(UpdateAgeGroupRequest request);
    }
}
