using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Meal;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Domain.Enums;
using System;

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

        public async Task<Result<MealPlanResponse>> BuildWeeklyMealPlan(BuildWeeklyMealPlanRequest request)
        {
            var _random = new Random();
            var energy = await _unitOfWork.EnergySuggestionRepository.GetEnergySuggestionByTrimester(request.Stage switch
            {
                < 14 => 1,
                < 28 => 2,
                _ => 3
            });
            if (energy is null)
            {
                return new Result<MealPlanResponse>()
                {
                    Error = 1,
                    Message = "Cannot find energy suggestion"
                };
            }
            var caloriesId = await _unitOfWork.NutrientRepository.GetNutrientIdByName("Calories");
            if (energy is null || caloriesId == Guid.Empty)
            {
                return new Result<MealPlanResponse>()
                {
                    Error = 1,
                    Message = "Cannot find energy suggestion or calories nutrient"
                };
            }
            var allMeals = await _unitOfWork.MealRepository.GetMealsWithCalories(caloriesId);

            var mealsByType = allMeals
                .GroupBy(m => m.MealType)
                .ToDictionary(g => g.Key, g => g.ToList());

            var distribution = new Dictionary<MealType, double>
            {
                { MealType.Breakfast, 0.25 },
                { MealType.Lunch, 0.35 },
                { MealType.Dinner, 0.25 },
                { MealType.Snack1, 0.10 },
                { MealType.Snack2, 0.05 }
            };

            var targetCalories = energy.BaseCalories + energy.AdditionalCalories;

            var result = new MealPlanResponse
            {
                TargetCalories = targetCalories   
            };

            for (int dayIndex = 1; dayIndex <= 7; dayIndex++)
            {
                var day = new DayDto { DayOfWeek = (DayOfWeek)((dayIndex - 1) % 7) };

                foreach (var dist in distribution)
                {
                    if (!mealsByType.ContainsKey(dist.Key) || mealsByType[dist.Key].Count == 0)
                        continue;

                    double expectedCalories = targetCalories * dist.Value;

                    var candidateMeals = mealsByType[dist.Key]
                        .Where(m => Math.Abs(m.TotalCalories - expectedCalories) <= 50)
                        .ToList();

                    if (candidateMeals.Count == 0)
                    {
                        candidateMeals = mealsByType[dist.Key];
                    }

                    var chosen = candidateMeals[_random.Next(candidateMeals.Count)];
                    day.Meals.Add(chosen);
                }

                result.Days.Add(day);
            }

            return new Result<MealPlanResponse>()
            {
                Error = 0,
                Data = result,
                Message = "Build meal plan success"
            };
        }
    }
}
