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

        public async Task<Result<bool>> CreateRecommendFoodForDisease(CreateRecommendFoodForDiseaseRequest request)
        {
            var disease = await _unitOfWork.DiseaseRepository.GetDiseaseById(request.DiseaseId);
            if (disease is null)
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Disease is not found"
                };

            foreach (var recommendFoodDto in request.recommendFoodDtos)
            {
                if (disease.FoodDiseases.Any(fd => fd.FoodId == recommendFoodDto.FoodId && fd.Status == Domain.Enums.FoodDiseaseStatus.Warning))
                {
                    return new Result<bool>()
                    {
                        Error = 1,
                        Message = "Food is already in warning list"
                    };
                }
                bool alreadyExists = disease.FoodDiseases.All(fd => fd.FoodId == recommendFoodDto.FoodId);
                if (!alreadyExists)
                {
                    var food = await _unitOfWork.FoodRepository.GetByIdAsync(recommendFoodDto.FoodId);
                    if (food is null)
                    {
                        return new Result<bool>
                        {
                            Error = 1,
                            Message = $"Food {recommendFoodDto.FoodId} is not found"
                        };
                    }
                    disease.FoodDiseases.Add(new FoodDisease
                    {
                        DiseaseId = disease.Id,
                        FoodId = food.Id,
                        Food = food,
                        Description = recommendFoodDto.Description,
                        Status = Domain.Enums.FoodDiseaseStatus.Warning
                    });
                }
            }
            _unitOfWork.DiseaseRepository.Update(disease);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<bool>()
                {
                    Error = 0,
                    Message = "Add success",
                    Data = true
                };
            return new Result<bool>()
            {
                Error = 1,
                Message = "Add failed",
                Data = false
            };
        }

        public async Task<Result<bool>> CreateWarningFoodForAllergy(CreateWarningFoodForAllergyRequest request)
        {
            var allergy = await _unitOfWork.AllergyRepository.GetAllergyById(request.AllergyId);
            if (allergy is null)
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Allergy is not found"
                };

            foreach (var warningFoodDto in request.warningFoodDtos)
            {
                bool alreadyExists = allergy.FoodAllergy.All(fd => fd.FoodId == warningFoodDto.FoodId);
                if (!alreadyExists)
                {
                    var food = await _unitOfWork.FoodRepository.GetByIdAsync(warningFoodDto.FoodId);
                    if (food is null)
                    {
                        return new Result<bool>
                        {
                            Error = 1,
                            Message = $"Food {warningFoodDto.FoodId} is not found"
                        };
                    }
                    allergy.FoodAllergy.Add(new FoodAllergy
                    {
                        AllergyId = allergy.Id,
                        FoodId = food.Id,
                        Food = food,
                        Description = warningFoodDto.Description,
                    });
                }
            }
            _unitOfWork.AllergyRepository.Update(allergy);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<bool>()
                {
                    Error = 0,
                    Message = "Add success",
                    Data = true
                };
            return new Result<bool>()
            {
                Error = 1,
                Message = "Add failed",
                Data = false
            };
        }

        public async Task<Result<bool>> CreateWarningFoodForDisease(CreateWarningFoodForDiseaseRequest request)
        {
            var disease = await _unitOfWork.DiseaseRepository.GetDiseaseById(request.DiseaseId);
            if (disease is null)
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Disease is not found"
                };

            foreach (var warningFoodDto in request.warningFoodDtos)
            {
                if (disease.FoodDiseases.Any(fd => fd.FoodId == warningFoodDto.FoodId && fd.Status == Domain.Enums.FoodDiseaseStatus.Recommend))
                {
                    return new Result<bool>()
                    {
                        Error = 1,
                        Message = "Food is already in recommend list"
                    };
                }
                bool alreadyExists = disease.FoodDiseases.All(fd => fd.FoodId == warningFoodDto.FoodId);
                if (!alreadyExists)
                {
                    var food = await _unitOfWork.FoodRepository.GetByIdAsync(warningFoodDto.FoodId);
                    if (food is null)
                    {
                        return new Result<bool>
                        {
                            Error = 1,
                            Message = $"Food {warningFoodDto.FoodId} is not found"
                        };
                    }
                    disease.FoodDiseases.Add(new FoodDisease
                    {
                        DiseaseId = disease.Id,
                        FoodId = food.Id,
                        Food = food,
                        Description = warningFoodDto.Description,
                        Status = Domain.Enums.FoodDiseaseStatus.Warning
                    });
                }
            }
            _unitOfWork.DiseaseRepository.Update(disease);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<bool>()
                {
                    Error = 0,
                    Message = "Add success",
                    Data = true
                };
            return new Result<bool>()
            {
                Error = 1,
                Message = "Add failed",
                Data = false
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

        public async Task<List<ViewWarningFoodsResponse>> GetWarningFoods(ViewWarningFoodsRequest request)
        {
            return _mapper.Map<List<ViewWarningFoodsResponse>>(await _unitOfWork.FoodRepository.GetFoodWarningIdsByAllergiesAndDiseases(request.allergyIds, request.diseaseIds));
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

        public async Task<Result<bool>> RemoveFoodDisease(RemoveFoodDiseaseRequest request)
        {
            var disease = await _unitOfWork.DiseaseRepository.GetDiseaseById(request.DiseaseId);
            if (disease is null)
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Disease is not found"
                };

            var food = await _unitOfWork.FoodRepository.GetByIdAsync(request.FoodId);
            if (food is null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = $"Food {request.FoodId} is not found"
                };
            }
            var toRemovefoodDisease = disease.FoodDiseases.FirstOrDefault(fd => fd.FoodId == request.FoodId);
            if (toRemovefoodDisease is null)
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Food disease is not found",
                    Data = false
                };
            disease.FoodDiseases.Remove(toRemovefoodDisease);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<bool>()
                {
                    Error = 0,
                    Message = "Remove success",
                    Data = true
                };
            return new Result<bool>()
            {
                Error = 1,
                Message = "Remove failed",
                Data = false
            };
        }

        public async Task<Result<bool>> RemoveFoodAllergy(RemoveFoodAllergyRequest request)
        {
            var allergy = await _unitOfWork.AllergyRepository.GetAllergyById(request.AllergyId);
            if (allergy is null)
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Allergy is not found"
                };

            var food = await _unitOfWork.FoodRepository.GetByIdAsync(request.FoodId);
            if (food is null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = $"Food {request.FoodId} is not found"
                };
            }
            var toRemovefoodAllergy = allergy.FoodAllergy.FirstOrDefault(fd => fd.FoodId == request.FoodId);
            if (toRemovefoodAllergy is null)
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Food allergy is not found",
                    Data = false
                };
            allergy.FoodAllergy.Remove(toRemovefoodAllergy);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<bool>()
                {
                    Error = 0,
                    Message = "Remove success",
                    Data = true
                };
            return new Result<bool>()
            {
                Error = 1,
                Message = "Remove failed",
                Data = false
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
