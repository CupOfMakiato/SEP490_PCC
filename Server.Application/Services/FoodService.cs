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
            var food = await _unitOfWork.FoodRepository.GetFoodByIdAsync(request.FoodId);
            if (food == null)
                return new Result<Food> { Error = 1, Message = "Food does not exist." };

            foreach (var reqNutrient in request.Nutrients)
            {
                Nutrient nutrientEntity = null;

                if (reqNutrient.NutrientId.HasValue)
                {
                    nutrientEntity = await _unitOfWork.NutrientRepository
                        .GetByIdAsync((Guid)reqNutrient.NutrientId);
                }

                // If no nutrient found -> skip or return error
                if (nutrientEntity == null)
                    continue;

                // Skip if already exists
                if (food.FoodNutrients.Any(fn => fn.NutrientId == nutrientEntity.Id))
                    continue;

                // Create and add FoodNutrient
                var foodNutrient = new FoodNutrient
                {
                    FoodId = food.Id,
                    NutrientId = nutrientEntity.Id,
                    NutrientEquivalent = reqNutrient.NutrientEquivalent,
                    Unit = reqNutrient.Unit,
                    AmountPerUnit = reqNutrient.AmountPerUnit,
                    TotalWeight = reqNutrient.TotalWeight,
                    FoodEquivalent = reqNutrient.FoodEquivalent,
                    Nutrient = nutrientEntity
                };

                food.FoodNutrients.Add(foodNutrient);
            }
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

        public async Task<Result<FoodDTO>> CreateFood(CreateFoodRequest request)
        {
            var foodCategory = await _unitOfWork.FoodCategoryRepository.GetByIdAsync(request.FoodCategoryId);
            if (foodCategory is null)
                return new Result<FoodDTO>()
                {
                    Error = 1,
                    Message = "Food category is not found"
                };
            if (await _unitOfWork.FoodRepository.GetFoodByName(request.Name) != null)
                return new Result<FoodDTO>()
                {
                    Error = 1,
                    Message = "Name is duplicate"
                };
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
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<FoodDTO>()
                {
                    Error = 0,
                    Message = "Create success",
                    Data = _mapper.Map<FoodDTO>(food)
                };
            return new Result<FoodDTO>()
            {
                Error = 1,
                Message = "Create failed"
            };
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

        public async Task<ViewFoodResponse> GetFoodByIdAsync(Guid foodId)
        {
            return _mapper.Map<ViewFoodResponse>(await _unitOfWork.FoodRepository.GetFoodByIdAsync(foodId));
        }

        public async Task<List<ViewFoodResponse>> GetFoodsAsync()
        {
            return _mapper.Map<List<ViewFoodResponse>>(await _unitOfWork.FoodRepository.GetFoodsAsync());
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
            if (!food.Name.Equals(request.Name))
                if (await _unitOfWork.FoodRepository.GetFoodByName(request.Name) != null)
                    return new Result<FoodDTO>()
                    {
                        Error = 1,
                        Message = "Name is duplicate"
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
            if (request.image is null)
            {
                food.ImageUrl = "";
                _unitOfWork.FoodRepository.Update(food);
                if (await _unitOfWork.SaveChangeAsync() > 0)
                    return new Result<FoodDTO>()
                    {
                        Error = 0,
                        Message = "Remove image success"
                    };
                else
                {
                    return new Result<FoodDTO>()
                    {
                        Error = 1,
                        Message = "Remove image failed"
                    };
                }
            }

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
