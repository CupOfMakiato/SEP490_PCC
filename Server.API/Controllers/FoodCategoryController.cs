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

        [HttpGet("GetAll")]
        public async Task<IActionResult> Gets()
        {
            return Ok(await _foodCategoryService.GetFoodCategorysAsync());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] Guid categoryId)
        {
            return Ok(await _foodCategoryService.GetFoodCategoryByIdAsync(categoryId));
        }

        [HttpGet("GetWithFoodById")]
        public async Task<IActionResult> GetWithFoodById([FromQuery] Guid categoryId)
        {
            return Ok(await _foodCategoryService.GetFoodCategoryWithFoodByIdAsync(categoryId));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateFoodCategoryRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                return BadRequest("Name is null");
            if (string.IsNullOrEmpty(request.Description))
                return BadRequest("Description is null");
            try
            {
                if (!await _foodCategoryService.CreateFoodCategory(request))
                    return BadRequest("Create fail");
                return Ok("Create success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateFoodCategoryRequest request)
        {
            if (request.Id == Guid.Empty)
                return BadRequest("FoodCategory Id is null or empty");
            if (string.IsNullOrEmpty(request.Name) && string.IsNullOrEmpty(request.Description))
                return BadRequest("Fields are empty");
            try
            {

                if (!await _foodCategoryService.UpdateFoodCategory(request))
                    return BadRequest("Create fail");
                return Ok("Create success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDelete([FromQuery] Guid foodCategoryId)
        {
            if (foodCategoryId == Guid.Empty)
                return BadRequest("FoodCategory Id is null or empty");
            try
            {
                if (!await _foodCategoryService.SoftDeleteFoodCategory(foodCategoryId))
                    return BadRequest("Create fail");
                return Ok("Create success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
