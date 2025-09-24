using Microsoft.AspNetCore.SignalR.Protocol;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Food;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface IFoodService
    {
        public Task<Result<bool>> CreateWarningFoodForAllergy(CreateWarningFoodForAllergyRequest request);
        public Task<Result<bool>> CreateRecommendFoodForDisease(CreateRecommendFoodForDiseaseRequest request);
        public Task<List<ViewWarningFoodsResponse>> GetWarningFoods(ViewWarningFoodsRequest request);
        public Task<List<ViewWarningFoodsResponse>> GetWarningFoodsByDiseases(List<Guid> diseaseIds);
        public Task<List<ViewWarningFoodsResponse>> GetWarningFoodsByAllergies(List<Guid> allergyIds);
        public Task<ViewFoodResponse> GetFoodByIdAsync(Guid foodId);
        public Task<List<ViewFoodResponse>> GetFoodsAsync();
        public Task<bool> SoftDeleteFood(Guid foodId);
        public Task<bool> DeleteFood(Guid foodId);
        public Task<Result<FoodDTO>> CreateFood(CreateFoodRequest request);
        public Task<Result<FoodDTO>> UpdateFood(UpdateFoodRequest request);
        public Task<Result<FoodDTO>> UpdateFoodNutrient(UpdateFoodNutrientRequest request);
        public Task<Result<FoodDTO>> UpdateFoodImage(UpdateFoodImageRequest request);
        public Task<Result<bool>> RemoveFoodNutrient(RemoveFoodNutrientRequest request);
        public Task<Result<Food>> AddNutrientsByNames(AddNutrientsRequest request);
        public Task<Result<bool>> CreateWarningFoodForDisease(CreateWarningFoodForDiseaseRequest request);
        public Task<Result<bool>> RemoveFoodDisease(RemoveFoodDiseaseRequest request);
        public Task<Result<bool>> RemoveFoodAllergy(RemoveFoodAllergyRequest request);

    }
}
