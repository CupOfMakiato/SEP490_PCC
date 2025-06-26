using Server.Application.DTOs.Food;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class FoodService : IFoodService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ApproveFood(Guid foodId)
        {
            var food = await _unitOfWork.FoodRepository.GetByIdAsync(foodId);
            if (food is null)
            {
                return false;
            }
            food.Review = true;
            _unitOfWork.FoodRepository.Update(food);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> CreateFood(CreateFoodRequest request)
        {
            var foodCategory = await _unitOfWork.FoodCategoryRepository.GetByIdAsync(request.FoodCategoryId);
            if (foodCategory is null) 
                return false;
            var nutrients = await _unitOfWork.NutrientRepository.GetByListName(request.FoodNutrientNames);
            var food = new Food()
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                FoodCategoryId = request.FoodCategoryId,
                Review = request.Review,
                SafetyNote = request.SafetyNote,
                PregnancySafe = request.PregnancySafe,
                FoodCategory = foodCategory,
                FoodNutrients = (IEnumerable<FoodNutrient>)nutrients
            };
            await _unitOfWork.FoodRepository.AddAsync(food);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> DeleteFood(Guid foodId)
        {
            var food = await _unitOfWork.FoodRepository.GetByIdAsync(foodId);
            if (food is null)
            {
                return false;
            }
            _unitOfWork.FoodRepository.DeleteFood(food);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<Food> GetFoodByIdAsync(Guid foodId)
        {
            return await _unitOfWork.FoodRepository.GetFoodByIdAsync(foodId);
        }

        public async Task<List<Food>> GetFoodsAsync()
        {
            return await _unitOfWork.FoodRepository.GetFoodsAsync();
        }

        public async Task<bool> SoftDeleteFood(Guid FoodId)
        {
            var food = await _unitOfWork.FoodRepository.GetByIdAsync(FoodId);
            if (food is null)
            {
                return false;
            }
            _unitOfWork.FoodRepository.SoftRemove(food);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UpdateFood(Food food)
        {
            _unitOfWork.FoodRepository.Update(food);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
