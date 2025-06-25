using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class NutrientService : INutrientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NutrientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ApproveNutrient(Guid nutrientId)
        {
            var nutrient = await _unitOfWork.NutrientRepository.GetByIdAsync(nutrientId);
            if (nutrient is null)
            {
                return false;
            }
            nutrient.Review = true;
            _unitOfWork.NutrientRepository.Update(nutrient);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> CreateNutrient(Nutrient nutrient)
        {
            _unitOfWork.NutrientRepository.AddAsync(nutrient);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> DeleteNutrient(Guid nutrientId)
        {
            var nutrient = await _unitOfWork.NutrientRepository.GetByIdAsync(nutrientId);
            if (nutrient is null)
            {
                return false;
            }
            _unitOfWork.NutrientRepository.DeleteNutrient(nutrient);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<Nutrient> GetNutrientByIdAsync(Guid nutrientId)
        {
            return await _unitOfWork.NutrientRepository.GetNutrientById(nutrientId);
        }

        public async Task<List<Nutrient>> GetNutrientsAsync()
        {
            return await _unitOfWork.NutrientRepository.GetAllAsync();
        }

        public async Task<bool> SoftDeleteNutrient(Guid NutrientId)
        {
            var nutrient = await _unitOfWork.NutrientRepository.GetByIdAsync(NutrientId);
            if (nutrient is null)
            {
                return false;
            }
            _unitOfWork.NutrientRepository.SoftRemove(nutrient);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UpdateNutrient(Nutrient nutrient)
        {
            _unitOfWork.NutrientRepository.Update(nutrient);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
