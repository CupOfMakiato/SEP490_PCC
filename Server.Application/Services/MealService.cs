using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Meal;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class MealService : IMealService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MealService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Meal>> CreateMeal(CreateMealRequest request)
        {
            var meal = new Meal
            {
                Id = Guid.NewGuid(),
                Trimester = request.Trimester,
                DayOfWeek = request.DayOfWeek,
                DishMeals = new List<DishMeal>()
            };

            foreach (var item in request.DishMeals)
            {
                var dish = await _unitOfWork.DishRepository.GetByIdAsync(item.DishId);
                if (dish is null)
                    throw new ArgumentException($"Dish {item.DishId} not found");

                meal.DishMeals.Add(new DishMeal
                {
                    MealId = meal.Id,
                    DishId = item.DishId,
                    MealType = item.MealType,
                });
            }

            await _unitOfWork.MealRepository.AddAsync(meal);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<Meal>()
                {
                    Error = 0,
                    Data = meal,
                    Message = "Add success"
                };
            return new Result<Meal>()
            {
                Error = 1,
                Message = "Add failed"
            };
        }

        public async Task<Result<List<Meal>>> MenuSuggestion(ViewMenuSuggestionRequest request)
        {
            var energy = await _unitOfWork.EnergySuggestionRepository.GetEnergySuggestionByTrimester(request.Stage switch
            {
                < 14 => 1,
                < 28 => 2,
                _ => 3
            });
            var caloriesId = await _unitOfWork.NutrientRepository.GetNutrientIdByName("Calories");
            var meals = new List<Meal>();
            if (request.ListFavouriteDishesId is null)
            {
                meals = await _unitOfWork.MealRepository.GetMealsByCalories(energy.BaseCalories + energy.AdditionalCalories, caloriesId);
            }
            else
            {
                meals = await _unitOfWork.MealRepository.GetMealsByCalories(energy.BaseCalories + energy.AdditionalCalories, request.ListFavouriteDishesId, caloriesId);
            }
            return new Result<List<Meal>>()
            {
                Error = 0,
                Message = "Get success",
            };
        }
    }
}
