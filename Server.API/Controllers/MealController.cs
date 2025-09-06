using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.Meal;
using Server.Application.Interfaces;
using Server.Application.Services;
using Server.Domain.Enums;

namespace Server.API.Controllers
{
    [Route("api/meal")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealService _mealService;

        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }

        [HttpGet("view-menu-suggestion-by-trimester")]
        public async Task<IActionResult> MenuSuggestion([FromQuery]BuildWeeklyMealPlanRequest request)
        {
            if (request == null)
                return BadRequest("Request is null");

            if (request.Stage <= 0 || request.Stage > 40)
                return BadRequest("Stage must be greater than 0 and smaller than 41");
            try
            {
                var result = await _mealService.BuildWeeklyMealPlan(request);
                if (result.Error == 1)
                    return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("view-meals-suggestion")]
        public async Task<IActionResult> MealsSuggestion([FromQuery] MealsSuggestionRequest request)
        {
            if (request == null)
                return BadRequest("Request is null");

            if (request.Stage <= 0 || request.Stage > 40)
                return BadRequest("Stage must be between 1 and 40");

            if (request.NumberOfDishes <= 0)
                return BadRequest("NumberOfDishes must be greater than 0");

            try
            {
                var result = await _mealService.MealsSuggestion(request);
                if (result.Error == 1)
                    return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost("add-meal")]
        public async Task<IActionResult> CreateMeal(CreateMealRequest request)
        {
            if (request.Trimester <= 0 && request.Trimester > 3)
                return BadRequest("Trimester must be greater than 0 and smaller than 4");

            if (request.DishMeals == null || request.DishMeals.Count == 0)
                return BadRequest("DishMeals list cannot be null or empty");

            foreach (var dishMeal in request.DishMeals)
            {
                if (dishMeal.DishId == Guid.Empty)
                    return BadRequest("DishId cannot be null or empty");

                if (!Enum.IsDefined(typeof(MealType), dishMeal.MealType))
                    return BadRequest($"Invalid MealType value: {dishMeal.MealType}");
            }

            if (!Enum.IsDefined(typeof(DayOfWeek), request.DayOfWeek))
                return BadRequest($"Invalid DayOfWeek value: {request.DayOfWeek}");

            try
            {
                var result = await _mealService.CreateMeal(request);
                if (result.Error == 1)
                    return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
