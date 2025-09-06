using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.FoodCategory;
using Server.Application.Interfaces;
using Server.Application.Services;
using Server.Domain.Entities;
using System.Security.Claims;

namespace Server.API.Controllers
{
    [Route("api/food-category")]
    [ApiController]
    public class FoodCategoryController : ControllerBase
    {
        private readonly IFoodCategoryService _foodCategoryService;

        public FoodCategoryController(IFoodCategoryService foodCategoryService)
        {
            _foodCategoryService = foodCategoryService;
        }

        [HttpGet("view-all-foods-category")]
        public async Task<IActionResult> Gets()
        {
            return Ok(await _foodCategoryService.GetFoodCategorysAsync());
        }

        [HttpGet("view-food-category-by-id")]
        public async Task<IActionResult> GetById([FromQuery] Guid categoryId)
        {
            return Ok(await _foodCategoryService.GetFoodCategoryByIdAsync(categoryId));
        }

        [HttpGet("view-food-category-by-id-with-foods")]
        public async Task<IActionResult> GetWithFoodById([FromQuery] Guid categoryId)
        {
            return Ok(await _foodCategoryService.GetFoodCategoryWithFoodByIdAsync(categoryId));
        }

        [HttpPost("add-food-category")]
        public async Task<IActionResult> Create([FromBody] CreateFoodCategoryRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                return BadRequest("Name is null");
            if (string.IsNullOrEmpty(request.Description))
                return BadRequest("Description is null");
            try
            {
                var result = await _foodCategoryService.CreateFoodCategory(request);
                if (result.Error == 1)
                    return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update-food-category")]
        public async Task<IActionResult> Update([FromBody] UpdateFoodCategoryRequest request)
        {
            if (request.Id == Guid.Empty)
                return BadRequest("FoodCategory Id is null or empty");
            if (string.IsNullOrEmpty(request.Name) && string.IsNullOrEmpty(request.Description))
                return BadRequest("Fields are empty");
            try
            {

                var result = await _foodCategoryService.UpdateFoodCategory(request);
                if (result.Error == 1)
                    return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("soft-delete-food-category-by-id")]
        public async Task<IActionResult> SoftDelete([FromQuery] Guid foodCategoryId)
        {
            if (foodCategoryId == Guid.Empty)
                return BadRequest("FoodCategory Id is null or empty");
            try
            {
                if (!await _foodCategoryService.SoftDeleteFoodCategory(foodCategoryId))
                    return BadRequest("Soft delte fail");
                return Ok("Soft delte success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("delete-food-category-by-id")]
        public async Task<IActionResult> Delete([FromQuery] Guid foodCategoryId)
        {
            if (foodCategoryId == Guid.Empty)
                return BadRequest("FoodCategory Id is null or empty");
            try
            {
                var result = await _foodCategoryService.DeleteFoodCategory(foodCategoryId);
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
