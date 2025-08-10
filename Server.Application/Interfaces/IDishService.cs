using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Dish;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface IDishService
    {
        public Task<Result<GetDishResponse>> GetDishByIdAsync(Guid dishId);
        public Task<Result<List<GetDishResponse>>> GetDishsAsync();
        public Task<Result<object>> SoftDeleteDish(Guid dishId);
        public Task<Result<object>> DeleteDish(Guid dishId);
        public Task<Result<Dish>> CreateDish(CreateDishRequest request);
        public Task<Result<Dish>> AddDishImage(AddDishImageRequest request);
        public Task<Result<Dish>> UpdateDish(UpdateDishRequest request);
    }
}
