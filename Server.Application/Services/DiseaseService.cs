using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Disease;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class DiseaseService : IDiseaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DiseaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetDiseaseResponse>> GetDiseaseByIdAsync(Guid diseaseId)
        {
            var disease = await _unitOfWork.DiseaseRepository.GetDiseaseById(diseaseId);
            if (disease == null)
                return new Result<GetDiseaseResponse>()
                {
                    Error = 1,
                    Message = "Disease not found"
                };

            return new Result<GetDiseaseResponse>()
            {
                Error = 0,
                Data = _mapper.Map<GetDiseaseResponse>(disease)
            };
        }

        public async Task<Result<List<GetDiseaseResponse>>> GetDiseasesAsync()
        {
            var diseases = await _unitOfWork.DiseaseRepository.GetDiseases();
            return new Result<List<GetDiseaseResponse>>()
            {
                Error = 0,
                Data = _mapper.Map<List<GetDiseaseResponse>>(diseases)
            };
        }

        public async Task<Result<object>> SoftDeleteDisease(Guid diseaseId)
        {
            var disease = await _unitOfWork.DiseaseRepository.GetByIdAsync(diseaseId);
            if (disease == null)
                return new Result<object>()
                {
                    Error = 1,
                    Message = "Disease not found"
                };

            _unitOfWork.DiseaseRepository.SoftRemove(disease);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<object>() { Error = 0, Message = "Soft delete success" };

            return new Result<object>() { Error = 1, Message = "Soft delete fail" };
        }

        public async Task<Result<object>> DeleteDisease(Guid diseaseId)
        {
            var disease = await _unitOfWork.DiseaseRepository.GetDiseaseById(diseaseId);
            if (disease == null)
                return new Result<object>() { Error = 1, Message = "Disease not found" };

            if (disease.DiseaseGrowthData.Count > 0 || disease.FoodDiseases.Count > 0)
                return new Result<object>() { Error = 0, Message = "Can't remove this disease (has related data)" };

            _unitOfWork.DiseaseRepository.DeleteDisease(disease);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<object>() { Error = 0, Message = "Remove success" };

            return new Result<object>() { Error = 1, Message = "Remove fail" };
        }

        public async Task<Result<Disease>> CreateDisease(CreateDiseaseRequest request)
        {
            if (request == null)
                return new Result<Disease>() { Error = 1, Message = "Request is null" };

            var disease = _mapper.Map<Disease>(request);
            await _unitOfWork.DiseaseRepository.AddAsync(disease);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<Disease>() { Error = 0, Message = "Create disease success" };

            return new Result<Disease>() { Error = 1, Message = "Create disease fail" };
        }

        public async Task<Result<Disease>> UpdateDisease(UpdateDiseaseRequest request)
        {
            if (request == null)
                return new Result<Disease>() { Error = 1, Message = "Request is null" };

            var disease = await _unitOfWork.DiseaseRepository.GetByIdAsync(request.DiseaseId);
            if (disease == null)
                return new Result<Disease>() { Error = 1, Message = "Disease not found" };

            disease.Name = request.Name;
            disease.Description = request.Description;
            disease.Symptoms = request.Symptoms;
            disease.TreatmentOptions = request.TreatmentOptions;
            disease.PregnancyRelated = request.PregnancyRelated;
            disease.RiskLevel = request.RiskLevel;
            disease.TypeOfDesease = request.TypeOfDesease;

            _unitOfWork.DiseaseRepository.Update(disease);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<Disease>() { Error = 0, Message = "Update disease success" };

            return new Result<Disease>() { Error = 1, Message = "Update disease fail" };
        }
    }

}
