using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.FoodCategory;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface IFoodCategoryService
    {
        public Task<FoodCategory> GetFoodCategoryByIdAsync(Guid foodCategoryId);
        public Task<List<FoodCategory>> GetFoodCategorysAsync();
        public Task<FoodCategory> GetFoodCategoryWithFoodByIdAsync(Guid foodCategoryId);
        public Task<bool> SoftDeleteFoodCategory(Guid foodCategoryId);
        public Task<Result<bool>> DeleteFoodCategory(Guid foodCategoryId);
        public Task<Result<object>> CreateFoodCategory(CreateFoodCategoryRequest request);
        public Task<Result<object>> UpdateFoodCategory(UpdateFoodCategoryRequest request);
    }
}
