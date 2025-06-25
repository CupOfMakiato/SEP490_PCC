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
        public Task<bool> CreateFoodCategory(CreateFoodCategoryRequest request);
        public Task<bool> UpdateFoodCategory(UpdateFoodCategoryRequest request);
    }
}
