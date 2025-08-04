using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IDishRepository : IGenericRepository<Dish>
    {
        public void RemoveDish(Dish dish);
    }
}
