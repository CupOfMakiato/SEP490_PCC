using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface IFoodService
    {
        public Task<Food> GetFoodByIdAsync(Guid foodId);
        public Task<List<Food>> GetFoodsAsync();
        public Task<bool> SoftDeleteFood(Guid foodId);
        public Task<bool> DeleteFood(Guid foodId);
        public Task<bool> CreateFood(Food food);
        public Task<bool> UpdateFood(Food food);
        public Task<bool> ApproveFood(Guid foodId);
    }
}
