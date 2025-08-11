using Org.BouncyCastle.Asn1.Ocsp;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.AgeGroup;
using Server.Application.Interfaces;
using Server.Application.Mappers.AgeGroupExtensions;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class AgeGroupService : IAgeGroupService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AgeGroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<AgeGroupDTO>> CreateAgeGroup(CreateAgeGroupRequest request)
        {
            if (request is null)
                return new Result<AgeGroupDTO>()
                {
                    Error = 1,
                    Message = "Request is null"
                };
            var ageGroup = new AgeGroup()
            {
                FromAge = request.FromAge,
                ToAge = request.ToAge,
            };
            await _unitOfWork.AgeGroupRepository.AddAsync(ageGroup);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<AgeGroupDTO>()
                {
                    Error = 0,
                    Data = ageGroup.ToAgeGroupDTO()
                };
            return new Result<AgeGroupDTO>()
            {
                Error = 1,
                Message = "Add failed"
            };
        }

        public async Task<Result<AgeGroupDTO>> DeleteAgeGroup(Guid ageGroupId)
        {
            var ageGroup = await _unitOfWork.AgeGroupRepository.GetAgeGroupById(ageGroupId);
            if (ageGroup == null)
                return new Result<AgeGroupDTO>()
                {
                    Error = 1,
                    Message = "AgeGroup is not found"
                };
            if (ageGroup.EnergySuggestion != null || ageGroup.NutrientSuggetions.Count() > 0)
                return new Result<AgeGroupDTO>()
                {
                    Error = 1,
                    Message = "Cannot delete this ageGroup"
                };
            _unitOfWork.AgeGroupRepository.Delete(ageGroup);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<AgeGroupDTO>()
                {
                    Error = 0,
                    Data = ageGroup.ToAgeGroupDTO()
                };
            return new Result<AgeGroupDTO>()
            {
                Error = 1,
                Message = "Delete failed"
            };
        }

        public async Task<Result<AgeGroupDTO>> GetAgeGroupByIdAsync(Guid ageGroupId)
        {
            var result = await _unitOfWork.AgeGroupRepository.GetByIdAsync(ageGroupId);
            if (result == null)
                return new Result<AgeGroupDTO>()
                {
                    Error = 0,
                    Message = "Get success",
                };
            return new Result<AgeGroupDTO>()
            {
                Error = 0,
                Message = "Get success",
                Data = result.ToAgeGroupDTO()
            };
        }

        public async Task<Result<List<AgeGroupDTO>>> GetAgeGroupsAsync()
        {
            var result = await _unitOfWork.AgeGroupRepository.GetAllAsync();
            if (result == null)
                return new Result<List<AgeGroupDTO>>()
                {
                    Error = 0,
                    Message = "Get success",
                };
            List<AgeGroupDTO> ageGroups = new List<AgeGroupDTO>();
            foreach (var item in result)
            {
                ageGroups.Add(item.ToAgeGroupDTO());
            }
            return new Result<List<AgeGroupDTO>>()
            {
                Error = 0,
                Message = "Get success",
                Data = ageGroups
            };
        }

        public async Task<Result<AgeGroupDTO>> SoftDeleteAgeGroup(Guid ageGroupId)
        {
            var ageGroup = await _unitOfWork.AgeGroupRepository.GetByIdAsync(ageGroupId);
            if (ageGroup == null)
                return new Result<AgeGroupDTO>()
                {
                    Error = 1,
                    Message = "AgeGroup is not found"
                };
            _unitOfWork.AgeGroupRepository.SoftRemove(ageGroup);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<AgeGroupDTO>()
                {
                    Error = 0,
                    Data = ageGroup.ToAgeGroupDTO()
                };
            return new Result<AgeGroupDTO>()
            {
                Error = 1,
                Message = "Soft delete failed"
            };
        }

        public async Task<Result<AgeGroupDTO>> UpdateAgeGroup(UpdateAgeGroupRequest request)
        {
            if (request is null)
                return new Result<AgeGroupDTO>()
                {
                    Error = 1,
                    Message = "Request is null"
                };
            var ageGroup = await _unitOfWork.AgeGroupRepository.GetByIdAsync(request.AgeGroupId);
            if (ageGroup == null)
                return new Result<AgeGroupDTO>()
                {
                    Error = 1,
                    Message = "AgeGroup is not found"
                };

            ageGroup.FromAge = request.FromAge;
            ageGroup.ToAge = request.ToAge;

            _unitOfWork.AgeGroupRepository.Update(ageGroup);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<AgeGroupDTO>()
                {
                    Error = 0,
                    Data = ageGroup.ToAgeGroupDTO()
                };
            return new Result<AgeGroupDTO>()
            {
                Error = 1,
                Message = "Update failed"
            };
        }
    }
}
