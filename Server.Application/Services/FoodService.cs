using AutoMapper;
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
        private readonly IMapper _mapper;

        public FoodService(IUnitOfWork unitOfWork, ICloudinaryService cloudinaryService, IMapper mapper)
        {
            _cloudinaryService = cloudinaryService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

            var uploadImageResponse = await _cloudinaryService.UploadImage(request.image, "Food");
            if (uploadImageResponse != null)
                food.ImageUrl = uploadImageResponse.FileUrl;
            else
                food.ImageUrl = "";

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

        public async Task<FoodDTO> GetFoodByIdAsync(Guid foodId)
        {
            return _mapper.Map<FoodDTO>(await _unitOfWork.FoodRepository.GetFoodByIdAsync(foodId));
        }

        public async Task<List<FoodDTO>> GetFoodsAsync()
        {
            return _mapper.Map<List<FoodDTO>>(await _unitOfWork.FoodRepository.GetFoodsAsync());
        }

        public async Task<Result<bool>> RemoveFoodNutrient(RemoveFoodNutrientRequest request)
        {
            if (request is null)
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Request is null"
                };
            var result = await _unitOfWork.FoodRepository.DeleteFoodNutrient(request.FoodId, request.NutrientId);
            if (!result)
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Food or Nutrient is not found"
                };
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<bool>()
                {
                    Error = 0,
                    Message = "Remove success"
                };
            return new Result<bool>()
            {
                Error = 1,
                Message = "Remove failed"
            };
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

        public async Task<Result<FoodDTO>> UpdateFood(UpdateFoodRequest request)
        {
            if (request is null)
                return new Result<FoodDTO>()
                {
                    Error = 1,
                    Message = "Request is null"
                };
            var food = await _unitOfWork.FoodRepository.GetByIdAsync(request.Id);
            if (food is null)
                return new Result<FoodDTO>()
                {
                    Error = 1,
                    Message = "Food is not found"
                };
            food.SafetyNote = request.SafetyNote;
            food.Name = request.Name;
            food.Description = request.Description;
            food.PregnancySafe = request.PregnancySafe;
            _unitOfWork.FoodRepository.Update(food);
            if(await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<FoodDTO>()
                {
                    Error = 0,
                    Message = "Update success"
                };

            return new Result<FoodDTO>()
            {
                Error = 1,
                Message = "Update failed"
            };
        }

        public async Task<Result<FoodDTO>> UpdateFoodImage(UpdateFoodImageRequest request)
        {
            if (request is null)
                return new Result<FoodDTO>()
                {
                    Error = 1,
                    Message = "Request is null"
                };
            var food = await _unitOfWork.FoodRepository.GetByIdAsync(request.Id);
            if (food is null)
                return new Result<FoodDTO>()
                {
                    Error = 1,
                    Message = "Food is not found"
                };
            var uploadImageResponse = await _cloudinaryService.UploadImage(request.image, "Food");
            if (uploadImageResponse is null)
            {
                return new Result<FoodDTO>()
                {
                    Error = 1,
                    Message = "Fail to upload image"
                };
            }
            food.ImageUrl = uploadImageResponse.FileUrl;
            _unitOfWork.FoodRepository.Update(food);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<FoodDTO>()
                {
                    Error = 0,
                    Message = "Update success"
                };

            return new Result<FoodDTO>()
            {
                Error = 1,
                Message = "Update failed"
            };
        }

        public async Task<Result<FoodDTO>> UpdateFoodNutrient(UpdateFoodNutrientRequest request)
        {
            if (request is null)
                return new Result<FoodDTO>()
                {
                    Error = 1,
                    Message = "Request is null"
                };
            var food = await _unitOfWork.FoodRepository.GetFoodWithFoodNutrient(request.FoodId, request.NutrientId);
            if (food is null)
                return new Result<FoodDTO>()
                {
                    Error = 1,
                    Message = "Food or Nutrient is not found"
                };

            food.FoodNutrients.First().FoodEquivalent = request.FoodEquivalent;
            food.FoodNutrients.First().NutrientEquivalent = request.NutrientEquivalent;
            food.FoodNutrients.First().TotalWeight = request.TotalWeight;
            food.FoodNutrients.First().Unit = request.Unit;
            food.FoodNutrients.First().AmountPerUnit = request.AmountPerUnit;
            _unitOfWork.FoodRepository.Update(food);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<FoodDTO>()
                {
                    Error = 0,
                    Message = "Update success"
                };

            return new Result<FoodDTO>()
            {
                Error = 1,
                Message = "Update failed"
            };
        }
    }
}
