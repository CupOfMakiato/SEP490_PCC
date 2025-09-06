using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IDishRepository : IGenericRepository<Dish>
    {
        public Task<Dish> GetDishById(Guid dishId);
        public Task<List<Dish>> GetAllDishes();
        public void RemoveDish(Dish dish);
    }
}
