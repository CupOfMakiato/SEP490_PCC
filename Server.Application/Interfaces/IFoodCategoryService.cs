using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface IFoodCategoryService
    {
        public Task<FoodCategory> GetFoodCategoryByIdAsync(Guid foodCategoryId);
        public Task<List<FoodCategory>> GetFoodCategorysAsync();
        public Task<bool> SoftDeleteFoodCategory(Guid foodCategoryId);
        public Task<bool> CreateFoodCategory(FoodCategory foodCategory);
        public Task<bool> UpdateFoodCategory(FoodCategory foodCategory);
    }
}
