using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.FoodCategory;
using Server.Application.DTOs.NutrientCategory;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NutrientCategoryController : ControllerBase
    {
        private readonly INutrientCategoryService _nutrientCategoryService;

        public NutrientCategoryController(INutrientCategoryService nutrientCategoryService)
        {
            _nutrientCategoryService = nutrientCategoryService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Gets()
        {
            return Ok(await _nutrientCategoryService.GetNutrientCategorysAsync());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] Guid categoryId)
        {
            return Ok(await _nutrientCategoryService.GetNutrientCategoryByIdAsync(categoryId));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateNutrientCategoryRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                return BadRequest("Name is null");
            if (string.IsNullOrEmpty(request.Description))
                return BadRequest("Description is null");

            try
            {
                var result = await _nutrientCategoryService.CreateNutrientCategory(request);
                if (result.Error == 1)
                    return BadRequest(result.Message);
                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateNutrientCategoryRequest request)
        {
            if (request.NutrientCategoryId == Guid.Empty)
                return BadRequest("NutrientCategory's Id is null or empty");
            if (string.IsNullOrEmpty(request.Name) && string.IsNullOrEmpty(request.Description))
                return BadRequest("Fields are empty");

            try
            {
                var result = await _nutrientCategoryService.UpdateNutrientCategory(request);
                if (result.Error == 1)
                    return BadRequest(result.Message);
                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDelete([FromQuery] Guid nutrientCategoryId)
        {
            if (nutrientCategoryId == Guid.Empty)
                return BadRequest("NutrientCategory Id is null or empty");

            try
            {
                if (!await _nutrientCategoryService.SoftDeleteNutrientCategory(nutrientCategoryId))
                    return BadRequest("Soft delete failed");
                return Ok("Soft delete success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("delete-nutrient-by-id")]
        public async Task<IActionResult> Delete([FromQuery] Guid nutrientCategoryId)
        {
            if (nutrientCategoryId == Guid.Empty)
                return BadRequest("NutrientCategory Id is null or empty");

            try
            {
                var result = await _nutrientCategoryService.DeleteNutrientCategory(nutrientCategoryId);
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
