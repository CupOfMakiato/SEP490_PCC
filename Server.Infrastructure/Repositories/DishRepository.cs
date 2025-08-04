using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class DishRepository : GenericRepository<Dish>, IDishRepository
    {
        public DishRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService)
            : base(context, currentTime, claimsService)
        {
        }

        public void RemoveDish(Dish dish)
        {
            _dbSet.Remove(dish);
        }
    }
}
