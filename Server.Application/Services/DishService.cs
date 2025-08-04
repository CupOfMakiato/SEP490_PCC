using Google;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Dish;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class DishService : IDishService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DishService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<GetDishResponse>> GetDishByIdAsync(Guid dishId)
        {
            var dish = await _unitOfWork.DishRepository.GetByIdAsync(dishId);
            if (dish == null)
                return new Result<GetDishResponse>()
                {
                    Error = 1,
                    Message = "Dish not found"
                };
            return new Result<GetDishResponse>()
            {
                Error = 0,
                //Data = dish
            };
        }

        public async Task<Result<List<GetDishResponse>>> GetDishsAsync()
        {
            var dishes = await _unitOfWork.DishRepository.GetAllAsync();
            return new Result<List<GetDishResponse>>()
            {
                Error = 0,
                //Data = dish
            };
        }

        public async Task<Result<object>> SoftDeleteDish(Guid dishId)
        {
            var dish = await _unitOfWork.DishRepository.GetByIdAsync(dishId);
            if (dish == null)
                return new Result<object>()
                {
                    Error = 1,
                    Message = "Dish not found"
                };
            _unitOfWork.DishRepository.SoftRemove(dish);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<object>()
                {
                    Error = 0,
                    Message = "SoftRemove success"
                };
            return new Result<object>()
            {
                Error = 1,
                Message = "SoftRemove fail"
            };
        }

        public async Task<Result<object>> DeleteDish(Guid dishId)
        {
            var dish = await _unitOfWork.DishRepository.GetByIdAsync(dishId);
            if (dish == null)
                return new Result<object>()
                {
                    Error = 1,
                    Message = "Dish not found"
                };
            _unitOfWork.DishRepository.RemoveDish(dish);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<object>()
                {
                    Error = 0,
                    Message = "Remove success"
                };
            return new Result<object>()
            {
                Error = 1,
                Message = "Remove fail"
            };
        }

        public async Task<Result<Dish>> CreateDish(UpdateDishRequest request)
        {
            if (request == null)
                return new Result<Dish>()
                {
                    Error = 1,
                    Message = "Request is null"
                };
            var foodDish = new List<FoodDish>();
            for (int i = 0; i <= request.foodList.Count; i++)
            {
                var food = await _unitOfWork.FoodRepository.GetByIdAsync(request.foodList[i].FoodId);
                if (food is not null)
                    foodDish.Add(new FoodDish()
                    {
                        Food = food,
                        FoodId = food.Id,
                        Amount = request.foodList[i].Amount,
                        Unit = request.foodList[i].Unit,    
                    });
            }
            var dish = new Dish
            {
                Foods = foodDish,
            };
            await _unitOfWork.DishRepository.AddAsync(dish);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<Dish>()
                {
                    Error = 0,
                    Message = "Create dish success"
                };
            return new Result<Dish>()
            {
                Error = 1,
                Message = "Create dish fail"
            };
        }

        public async Task<Result<Dish>> UpdateDish(UpdateDishRequest request)
        {
            if (request == null)
                return new Result<Dish>()
                {
                    Error = 1,
                    Message = "Request is null"
                };
            var dish = await _unitOfWork.DishRepository.GetByIdAsync(request.dishID); 
            if (dish is null)
                return new Result<Dish>()
                {
                    Error = 1,
                    Message = "Dish is not found"
                };
            var foodDish = new List<FoodDish>();
            for (int i = 0; i <= request.foodList.Count; i++)
            {
                var food = await _unitOfWork.FoodRepository.GetByIdAsync(request.foodList[i].FoodId);
                if (food is not null)
                    foodDish.Add(new FoodDish()
                    {
                        Food = food,
                        FoodId = food.Id,
                        Amount = request.foodList[i].Amount,
                        Unit = request.foodList[i].Unit,
                    });
            }
            dish.Foods = foodDish;
            _unitOfWork.DishRepository.Update(dish);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<Dish>()
                {
                    Error = 0,
                    Message = "Update dish success"
                };
            return new Result<Dish>()
            {
                Error = 1,
                Message = "Update dish fail"
            };
        }
    }

}
