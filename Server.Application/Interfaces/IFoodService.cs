using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Food;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface IFoodService
    {
        public Task<Food> GetFoodByIdAsync(Guid foodId);
        public Task<List<Food>> GetFoodsAsync();
        public Task<bool> SoftDeleteFood(Guid foodId);
        public Task<bool> DeleteFood(Guid foodId);
        public Task<bool> CreateFood(CreateFoodRequest request);
        public Task<bool> UpdateFood(Food food);
        public Task<Result<Food>> AddNutrientsByNames(AddNutrientsRequest request);
    }
}
