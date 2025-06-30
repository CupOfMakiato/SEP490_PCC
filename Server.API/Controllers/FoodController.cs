using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.Food;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Gets()
        {
            return Ok(await _foodService.GetFoodsAsync());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] Guid foodId)
        {
            return Ok(await _foodService.GetFoodByIdAsync(foodId));
        }

        [HttpGet("GetWithCategoryById")]
        public async Task<IActionResult> GetWithCategoryById([FromQuery] Guid foodId)
        {
            return Ok(await _foodService.GetFoodByIdAsync(foodId));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateFoodRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest("Name is required");

            if (string.IsNullOrWhiteSpace(request.Description))
                return BadRequest("Description is required");

            if (request.FoodCategoryId == Guid.Empty)
                return BadRequest("FoodCategoryId is required");

            try
            {
                if (!await _foodService.CreateFood(request))
                    return BadRequest("Create fail");

                return Ok("Create success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Food request)
        {
            if (request.Id == Guid.Empty)
                return BadRequest("Food Id is null or empty");
            if (string.IsNullOrEmpty(request.Name))
                return BadRequest("Name is null");

            try
            {
                if (!await _foodService.UpdateFood(request))
                    return BadRequest("Update fail");

                return Ok("Update success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDelete([FromQuery] Guid foodId)
        {
            if (foodId == Guid.Empty)
                return BadRequest("Food Id is null or empty");

            try
            {
                if (!await _foodService.SoftDeleteFood(foodId))
                    return BadRequest("Soft delete fail");

                return Ok("Soft delete success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid foodId)
        {
            if (foodId == Guid.Empty)
                return BadRequest("Food Id is null or empty");

            try
            {
                if (!await _foodService.DeleteFood(foodId))
                    return BadRequest("Soft delete fail");

                return Ok("Soft delete success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("AddNutrients")]
        public async Task<IActionResult> AddNutrients([FromBody] AddNutrientsRequest request)
        {
            if (request.FoodId == Guid.Empty)
                return BadRequest("Food Id is null or empty");
            if (request.NutrientsNames.Count <= 0)
                return BadRequest("List cannot be null");
            if (request.NutrientsNames.Any(string.IsNullOrEmpty))
                return BadRequest("Element in list cannot be null or empty");

            try
            {
                var result = await _foodService.AddNutrientsByNames(request);
                if (result.Error == 1)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}