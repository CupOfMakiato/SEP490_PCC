using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class FoodCategoryService : IFoodCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateFoodCategory(FoodCategory foodCategory)
        {
            _unitOfWork.FoodCategoryRepository.AddAsync(foodCategory);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<FoodCategory> GetFoodCategoryByIdAsync(Guid foodCategoryId)
            => await _unitOfWork.FoodCategoryRepository.GetFoodCategoryByIdAsync(foodCategoryId);

        public async Task<List<FoodCategory>> GetFoodCategorysAsync()
            => await _unitOfWork.FoodCategoryRepository.GetFoodCategorysAsync();

        public async Task<bool> SoftDeleteFoodCategory(Guid foodCategoryId)
        {
            var foodCategory = await _unitOfWork.FoodCategoryRepository.GetByIdAsync(foodCategoryId);
            if (foodCategory is null)
            {
                return false;
            }
            _unitOfWork.FoodCategoryRepository.SoftRemove(foodCategory);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UpdateFoodCategory(FoodCategory foodCategory)
        {
            _unitOfWork.FoodCategoryRepository.Update(foodCategory);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
