using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.AllergyCategory;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/allergy-category")]
    [ApiController]
    public class AllergyCategoryController : ControllerBase
    {
        private readonly IAllergyCategoryService _allergyCategoryService;

        public AllergyCategoryController(IAllergyCategoryService allergyCategoryService)
        {
            _allergyCategoryService = allergyCategoryService;
        }

        [HttpGet("view-all-allergy-category")]
        public async Task<IActionResult> Gets()
        {
            return Ok(await _allergyCategoryService.GetAllergyCategoriesAsync());
        }

        [HttpGet("view-allergy-category-by-id")]
        public async Task<IActionResult> GetById([FromQuery] Guid categoryId)
        {
            return Ok(await _allergyCategoryService.GetAllergyCategoryByIdAsync(categoryId));
        }

        [HttpGet("view-allergy-category-by-id-with-allergies")]
        public async Task<IActionResult> GetWithAllergiesById([FromQuery] Guid categoryId)
        {
            return Ok(await _allergyCategoryService.GetAllergyCategoryWithAllergiesByIdAsync(categoryId));
        }

        [HttpPost("add-allergy-category")]
        public async Task<IActionResult> Create([FromBody] CreateAllergyCategoryRequest request)
        {

            try
            {
                var result = await _allergyCategoryService.CreateAllergyCategory(request);
                if (result.Error == 1)
                    return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update-allergy-category")]
        public async Task<IActionResult> Update([FromBody] UpdateAllergyCategoryRequest request)
        {
            try
            {
                var result = await _allergyCategoryService.UpdateAllergyCategory(request);
                if (result.Error == 1)
                    return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("soft-delete-allergy-category-by-id")]
        public async Task<IActionResult> SoftDelete([FromQuery] Guid allergyCategoryId)
        {
            if (allergyCategoryId == Guid.Empty)
                return BadRequest("AllergyCategory Id is null or empty");

            try
            {
                if (!await _allergyCategoryService.SoftDeleteAllergyCategory(allergyCategoryId))
                    return BadRequest("Soft delete fail");
                return Ok("Soft delete success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("delete-allergy-category-by-id")]
        public async Task<IActionResult> Delete([FromQuery] Guid allergyCategoryId)
        {
            if (allergyCategoryId == Guid.Empty)
                return BadRequest("AllergyCategory Id is null or empty");

            try
            {
                var result = await _allergyCategoryService.DeleteAllergyCategory(allergyCategoryId);
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
