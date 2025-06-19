using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IFoodRepository : IGenericRepository<Food>
    {
        public Task<Food> GetFoodByIdAsync(Guid foodId);
        public Task<List<Food>> GetFoodsAsync();
        public void DeleteFood(Food food);
    }
}
