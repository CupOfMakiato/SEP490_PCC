using Server.Application.DTOs.FoodCategory;
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
        public async Task<bool> CreateFoodCategory(CreateFoodCategoryRequest request)
        {
            if (request == null)
                return false;
            var foodCategory = new FoodCategory()
            {
                Description = request.Description,
                Name = request.Name,
            };
            await _unitOfWork.FoodCategoryRepository.AddAsync(foodCategory);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<FoodCategory> GetFoodCategoryByIdAsync(Guid foodCategoryId)
            => await _unitOfWork.FoodCategoryRepository.GetByIdAsync(foodCategoryId);

        public async Task<List<FoodCategory>> GetFoodCategorysAsync()
            => await _unitOfWork.FoodCategoryRepository.GetAllAsync();

        public async Task<FoodCategory> GetFoodCategoryWithFoodByIdAsync(Guid foodCategoryId)
        {
            return await _unitOfWork.FoodCategoryRepository.GetFoodCategoryByIdAsync(foodCategoryId);
        }

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

        public async Task<bool> UpdateFoodCategory(UpdateFoodCategoryRequest request)
        {
            var foodCategory = await _unitOfWork.FoodCategoryRepository.GetByIdAsync(request.Id);
            if (foodCategory is null)
                return false;
            if (!string.IsNullOrEmpty(request.Description))
                foodCategory.Description = request.Description;
            if (!string.IsNullOrEmpty(request.Name))
                foodCategory.Description = request.Name;
            _unitOfWork.FoodCategoryRepository.Update(foodCategory);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
