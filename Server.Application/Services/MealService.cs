using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Dish;
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
        private readonly IMapper _mapper;

        public MealService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<MealDto>> UpdateMeal(Guid id, UpdateMealRequest request)
        {
            var meal = await _unitOfWork.MealRepository.GetByIdAsync(id);
            if (meal == null)
                return new Result<MealDto> { Error = 1, Message = "Meal not found" };

            meal.MealType = request.MealType;

            var existingDishIds = meal.DishMeals.Select(dm => dm.DishId).ToList();
            var requestDishIds = request.DishMeals.Select(dm => dm.DishId).ToList();

            var toRemove = meal.DishMeals
                .Where(dm => !requestDishIds.Contains(dm.DishId))
                .ToList();
            foreach (var remove in toRemove)
            {
                meal.DishMeals.Remove(remove);
            }

            var toAdd = requestDishIds
                .Where(did => !existingDishIds.Contains(did))
                .ToList();
            foreach (var dishId in toAdd)
            {
                var dish = await _unitOfWork.DishRepository.GetDishById(dishId);
                if (dish != null)
                {
                    meal.DishMeals.Add(new DishMeal
                    {
                        MealId = id,
                        DishId = dish.Id,
                        Dish = dish
                    });
                }
            }
            _unitOfWork.MealRepository.Update(meal);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<MealDto> 
                {   Error = 0, 
                    Message = "Meal updated successfully",
                    Data = _mapper.Map<MealDto>(meal)
                };

            return new Result<MealDto> 
            {
                Error = 1, 
                Message = "Failed to update meal"
            };
        }

        public async Task<Result<bool>> DeleteMeal(Guid id)
        {
            var meal = await _unitOfWork.MealRepository.GetMealsById(id);
            if (meal == null)
                return new Result<bool> { Error = 1, Message = "Meal not found" };
            meal.DishMeals.Clear();
            _unitOfWork.MealRepository.DeleteMeal(meal);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<bool>
                {
                    Error = 0,
                    Message = "Meal deleted successfully"
                };

            return new Result<bool>
            {
                Error = 1,
                Message = "Failed to delete meal"
            };
        }

        public async Task<Result<MealDto>> MealsSuggestion(MealsSuggestionRequest request)
        {
            int trimester = request.Stage switch
            {
                < 14 => 1,
                < 28 => 2,
                _ => 3
            };

            var age = 22; // default age
            if (!string.IsNullOrEmpty(request.DateOfBirth))
            {
                var dob = DateTime.Parse(request.DateOfBirth);
                age = DateTime.Now.Year - dob.Year;
            }

            var energy = await _unitOfWork.EnergySuggestionRepository
                .GetEnergySuggestionByAgeAndTrimester(age, trimester);

            var caloriesId = await _unitOfWork.NutrientRepository
                .GetNutrientIdByName("Calories");

            var foodsWarningIds = await _unitOfWork.FoodRepository
                .GetFoodWarningIdsByAllergiesAndDiseases(request.allergyIds, request.diseaseIds);

            var distribution = new Dictionary<MealType, double>
            {
                { MealType.Breakfast, 0.25 },
                { MealType.Lunch, 0.35 },
                { MealType.Dinner, 0.25 },
                { MealType.Snack1, 0.10 },
                { MealType.Snack2, 0.05 }
            };

            double calorieTarget = (energy.BaseCalories + energy.AdditionalCalories) * distribution.GetValueOrDefault(request.Type);

            var result = new MealDto();
            if (request.favouriteDishId is not null)
            {
                var favouriteDish = await _unitOfWork.DishRepository.GetDishById((Guid)request.favouriteDishId);
                if (favouriteDish is null)
                    return new Result<MealDto>()
                    {
                        Error = 1,
                        Message = "Invalid favourite dish Id"
                    };
                result.Dishes.Add(_mapper.Map<DishDto>(favouriteDish, opt => opt.Items["CaloriesId"] = caloriesId));
                calorieTarget -= result.Dishes[0].Calories;
                request.NumberOfDishes -= 1;
            }
            

            var dishes = await _unitOfWork.DishRepository.GetDishesByCaloriesAndMealType(
                calorieTarget,
                caloriesId,
                foodsWarningIds,
                request.NumberOfDishes
            );

            if (dishes == null || dishes.Count < 1 || (dishes.Count == 0 && request.Type == MealType.Snack1 || request.Type == MealType.Snack2))
            {
                return new Result<MealDto>
                {
                    Error = 1,
                    Message = "No suitable dishes found"
                };
            }

            result.Dishes.AddRange(_mapper.Map<List<DishDto>>(dishes, opt => opt.Items["CaloriesId"] = caloriesId));

            foreach (var item in result.Dishes)
            {
                result.TotalCalories += item.Calories;
            }

            return new Result<MealDto>
            {
                Error = 0,
                Message = "Get success",
                Data = result
            };
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

        public async Task<Result<MealDto>> GetMealById(Guid id)
        {
            var meal = await _unitOfWork.MealRepository.GetMealsById(id);
            return new Result<MealDto>()
            {
                Error = 0,
                Data = _mapper.Map<MealDto>(meal),
                Message = "Get success"
            };
        }

        public async Task<Result<List<MealDto>>> GetMeals()
        {
            var meals = await _unitOfWork.MealRepository.GetMeals();
            return new Result<List<MealDto>>()
            {
                Error = 0,
                Data = _mapper.Map<List<MealDto>>(meals),
                Message = "Get success"
            };
        }
    }
}
