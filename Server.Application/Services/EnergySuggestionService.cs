using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.EnergySuggestion;
using Server.Application.Interfaces;
using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Application.Services
{
    public class EnergySuggestionService : IEnergySuggestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnergySuggestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<EnergySuggestion>> CreateEnergySuggestion(CreateEnergySuggestionRequest request)
        {
            if (request == null)
                return new Result<EnergySuggestion>()
                {
                    Error = 1,
                    Message = "Request mustn't be null"
                };

            var ageGroup = await _unitOfWork.AgeGroupRepository.GetByIdAsync(request.AgeGroupId);

            if (ageGroup == null) 
                return new Result<EnergySuggestion>()
                {
                    Error = 1,
                    Message = "Invalid ageGroupId"
                }; ;

            var energySuggestion = new EnergySuggestion()
            {
                AdditionalCalories = request.AdditionalCalories,
                AgeGroupId = request.AgeGroupId,
                AgeGroup = ageGroup,
                BaseCalories = request.BaseCalories,
                Trimester = request.Trimester
            };
            if (request.ActivityLevel == 1)
                energySuggestion.ActivityLevel = (ActivityLevel)request.ActivityLevel;
            else energySuggestion.ActivityLevel = (ActivityLevel)2;
            await _unitOfWork.EnergySuggestionRepository.AddAsync(energySuggestion);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<EnergySuggestion>()
                {
                    Error = 0,
                    Message = "Request mustn't be null",
                    Data = energySuggestion
                };
            return new Result<EnergySuggestion>()
            {
                Error = 1,
                Message = "Create fail"
            };
        }

        public async Task<EnergySuggestion> GetEnergySuggestionByIdAsync(Guid energySuggestionId)
        {
            return await _unitOfWork.EnergySuggestionRepository.GetByIdAsync(energySuggestionId);
        }

        public async Task<List<EnergySuggestion>> GetEnergySuggestionsAsync()
        {
            return await _unitOfWork.EnergySuggestionRepository.GetAllAsync();
        }

        public async Task<bool> SoftDeleteEnergySuggestion(Guid energySuggestionId)
        {
            var energySuggestion = await _unitOfWork.EnergySuggestionRepository.GetByIdAsync(energySuggestionId);
            if (energySuggestion is null)
            {
                return false;
            }
            _unitOfWork.EnergySuggestionRepository.SoftRemove(energySuggestion);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UpdateEnergySuggestion(UpdateEnergySuggestionRequest request)
        {
            var energySuggestion = await _unitOfWork.EnergySuggestionRepository.GetByIdAsync(request.Id);
            if (energySuggestion is null) 
            { 
                return false; 
            }
            energySuggestion.ActivityLevel = (ActivityLevel)request.ActivityLevel;
            _unitOfWork.EnergySuggestionRepository.Update(energySuggestion);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
