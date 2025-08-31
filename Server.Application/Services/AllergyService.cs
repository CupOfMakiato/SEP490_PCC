using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Allergy;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class AllergyService : IAllergyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AllergyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetAllergyResponse>> GetAllergyByIdAsync(Guid allergyId)
        {
            var allergy = await _unitOfWork.AllergyRepository.GetAllergyById(allergyId);
            if (allergy == null)
                return new Result<GetAllergyResponse> { Error = 1, Message = "Allergy not found" };

            return new Result<GetAllergyResponse>
            {
                Error = 0,
                Data = _mapper.Map<GetAllergyResponse>(allergy)
            };
        }

        public async Task<Result<List<GetAllergyResponse>>> GetAllergiesAsync()
        {
            var allergies = await _unitOfWork.AllergyRepository.GetAllAllergies();
            return new Result<List<GetAllergyResponse>>
            {
                Error = 0,
                Data = _mapper.Map<List<GetAllergyResponse>>(allergies)
            };
        }

        public async Task<Result<object>> SoftDeleteAllergy(Guid allergyId)
        {
            var allergy = await _unitOfWork.AllergyRepository.GetByIdAsync(allergyId);
            if (allergy == null)
                return new Result<object> { Error = 1, Message = "Allergy not found" };

            _unitOfWork.AllergyRepository.SoftRemove(allergy);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<object> { Error = 0, Message = "SoftRemove success" };

            return new Result<object> { Error = 1, Message = "SoftRemove fail" };
        }

        public async Task<Result<object>> DeleteAllergy(Guid allergyId)
        {
            var allergy = await _unitOfWork.AllergyRepository.GetAllergyById(allergyId);
            if (allergy == null)
                return new Result<object> { Error = 1, Message = "Allergy not found" };

            if (allergy.UserAllergy.Count > 0 || allergy.FoodAllergy.Count > 0)
                return new Result<object> { Error = 0, Message = "Can't remove this allergy because it is in use" };

            _unitOfWork.AllergyRepository.DeleteAllergy(allergy);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<object> { Error = 0, Message = "Remove success" };

            return new Result<object> { Error = 1, Message = "Remove fail" };
        }

        public async Task<Result<Allergy>> CreateAllergy(CreateAllergyRequest request)
        {
            if (request == null)
                return new Result<Allergy> { Error = 1, Message = "Request is null" };

            var allergy = _mapper.Map<Allergy>(request);
            await _unitOfWork.AllergyRepository.AddAsync(allergy);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<Allergy> { Error = 0, Message = "Create allergy success" };

            return new Result<Allergy> { Error = 1, Message = "Create allergy fail" };
        }

        public async Task<Result<Allergy>> UpdateAllergy(UpdateAllergyRequest request)
        {
            if (request == null)
                return new Result<Allergy> { Error = 1, Message = "Request is null" };

            var allergy = await _unitOfWork.AllergyRepository.GetByIdAsync(request.AllergyId);
            if (allergy == null)
                return new Result<Allergy> { Error = 1, Message = "Allergy not found" };

            allergy.Name = request.Name;
            allergy.Description = request.Description;
            allergy.AllergyCategoryId = request.AllergyCategoryId;
            allergy.CommonSymptoms = request.CommonSymptoms;
            allergy.PregnancyRisk = request.PregnancyRisk;

            _unitOfWork.AllergyRepository.Update(allergy);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<Allergy> { Error = 0, Message = "Update allergy success" };

            return new Result<Allergy> { Error = 1, Message = "Update allergy fail" };
        }
    }
}
