using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Dish>> GetAllDishes()
        {
            return await _dbSet
                .Include(d => d.HistoryDish)
                .Include(d => d.DishMeals)
                .Include(d => d.Foods).ThenInclude(fd => fd.Food)
                .ToListAsync();  
        }

        public async Task<Dish> GetDishById(Guid dishId)
        {
            return await _dbSet
                .Include(d => d.HistoryDish)
                .Include(d => d.DishMeals)
                .Include(d => d.Foods).ThenInclude(fd => fd.Food)
                .FirstOrDefaultAsync(d => d.Id == dishId);
        }

        public void RemoveDish(Dish dish)
        {
            _dbSet.Remove(dish);
        }
    }
}
