using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Food;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class FoodService : IFoodService
    {
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IUnitOfWork _unitOfWork;

        public FoodService(IUnitOfWork unitOfWork, ICloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Food>> AddNutrientsByNames(AddNutrientsRequest request)
        {
            var food = await _unitOfWork.FoodRepository.GetByIdAsync(request.FoodId);
            if (food is null)
                return new Result<Food>()
                {
                    Error = 1,
                    Message = "Food is not exist."
                };
            List<Nutrient> nutrients = await _unitOfWork.NutrientRepository.GetByListName(request.NutrientsNames);
            if (nutrients is null)
                return new Result<Food>()
                {
                    Error = 1,
                    Message = "Didn't find any nutrient."
                };

            var containedNutrients = new List<Nutrient>();
            nutrients.ForEach(nutrient =>
                {
                    if (food.FoodNutrients.Any(f => f.NutrientId.Equals(nutrient.Id)))
                        containedNutrients.Add(nutrient);
                });
            nutrients.RemoveAll(containedNutrients.Contains);
            food.FoodNutrients.ToList().AddRange((IEnumerable<FoodNutrient>)nutrients);
            _unitOfWork.FoodRepository.Update(food);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<Food>()
                {
                    Error = 0,
                    Message = "Add success",
                    Data = food
                };
            }

            return new Result<Food>()
            {
                Error = 1,
                Message = "Add fail"
            };
        }

        public async Task<bool> CreateFood(CreateFoodRequest request)
        {
            var foodCategory = await _unitOfWork.FoodCategoryRepository.GetByIdAsync(request.FoodCategoryId);
            if (foodCategory is null)
                return false;

            var food = new Food()
            {
                Name = request.Name,
                Description = request.Description,
                FoodCategoryId = request.FoodCategoryId,
                SafetyNote = request.SafetyNote,
                PregnancySafe = request.PregnancySafe,
                FoodCategory = foodCategory,
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
