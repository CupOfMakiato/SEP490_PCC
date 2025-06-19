using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IFoodCategoryRepository : IGenericRepository<FoodCategory>
    {
        public Task<FoodCategory> GetFoodCategoryByIdAsync(Guid FoodCategoryId);
        public Task<List<FoodCategory>> GetFoodCategorysAsync();
    }
}
