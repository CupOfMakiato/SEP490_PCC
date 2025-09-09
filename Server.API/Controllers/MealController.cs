using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.Meal;
using Server.Application.Interfaces;
using Server.Application.Services;
using Server.Domain.Entities;
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
            if (request.DishMeals == null || request.DishMeals.Count == 0)
                return BadRequest("DishMeals list cannot be null or empty");

            if (!Enum.IsDefined(typeof(MealType), request.MealType))
                return BadRequest($"Invalid MealType value: {request.MealType}");

            if (request.DishMeals.Any(dm => dm.DishId == Guid.Empty ))
                return BadRequest("DishId cannot be null or empty");

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

        [HttpPut("update-meal/{id}")]
        public async Task<IActionResult> UpdateMeal(Guid id, UpdateMealRequest request)
        {
            if (id == Guid.Empty)
                return BadRequest("MealId cannot be empty");

            if (request.DishMeals == null || request.DishMeals.Count == 0)
                return BadRequest("DishMeals list cannot be null or empty");

            try
            {
                var result = await _mealService.UpdateMeal(id, request);
                if (result.Error == 1)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("delete-meal/{id}")]
        public async Task<IActionResult> DeleteMeal(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("MealId cannot be empty");

            try
            {
                var result = await _mealService.DeleteMeal(id);
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
