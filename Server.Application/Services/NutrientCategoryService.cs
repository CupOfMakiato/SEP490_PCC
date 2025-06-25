using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class NutrientCategoryService : INutrientCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NutrientCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateNutrientCategory(NutrientCategory nutrientCategory)
        {
            _unitOfWork.NutrientCategoryRepository.AddAsync(nutrientCategory);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<NutrientCategory> GetNutrientCategoryByIdAsync(Guid nutrientCategoryId)
        {
            return await _unitOfWork.NutrientCategoryRepository.GetNutrientCategoryById(nutrientCategoryId);
        }

        public async Task<List<NutrientCategory>> GetNutrientCategorysAsync()
        {
            return await _unitOfWork.NutrientCategoryRepository.GetAllAsync();
        }

        public async Task<bool> SoftDeleteNutrientCategory(Guid NutrientCategoryId)
        {
            var nutrientCategory = await _unitOfWork.NutrientCategoryRepository.GetByIdAsync(NutrientCategoryId);
            if (nutrientCategory is null)
            {
                return false;
            }
            _unitOfWork.NutrientCategoryRepository.SoftRemove(nutrientCategory);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UpdateNutrientCategory(NutrientCategory nutrientCategory)
        {
            _unitOfWork.NutrientCategoryRepository.Update(nutrientCategory);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
