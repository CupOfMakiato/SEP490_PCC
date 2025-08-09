using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.Nutrient;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.API.Controllers
{
    [ApiController]
    [Route("api/nutrient")]
    public class NutrientController : ControllerBase
    {
        private readonly INutrientService _nutrientService;

        public NutrientController(INutrientService nutrientService)
        {
            _nutrientService = nutrientService;
        }

        [HttpGet("view-all-nutrients")]
        public async Task<IActionResult> Gets()
        {
            return Ok(await _nutrientService.GetNutrientsAsync());
        }

        [HttpGet("view-nutrient-by-id")]
        public async Task<IActionResult> GetById([FromQuery] Guid nutrientId)
        {
            return Ok(await _nutrientService.GetNutrientByIdAsync(nutrientId));
        }

        [HttpPost("add-new-nutrient")]
        public async Task<IActionResult> Create([FromForm] CreateNutrientRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest("Name is required");

            if (string.IsNullOrWhiteSpace(request.Unit))
                return BadRequest("Unit is required");

            if (string.IsNullOrWhiteSpace(request.Description))
                return BadRequest("Unit is required");
            if (request.ImageUrl is not null)
                if (request.ImageUrl.Length > 0 && request.ImageUrl.Length <= 5 * 1024 * 1024)
                    return BadRequest("Image size must be smaller than 5mb");

            try
            {
                var result = await _nutrientService.CreateNutrient(request);
                if (result.Error == 1)
                    return BadRequest(result.Message);

                return Ok("Create success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("soft-delete-nutrient-by-id")]
        public async Task<IActionResult> SoftDelete([FromQuery] Guid nutrientId)
        {
            if (nutrientId == Guid.Empty)
                return BadRequest("Nutrient Id is null or empty");

            try
            {
                if (!await _nutrientService.SoftDeleteNutrient(nutrientId))
                    return BadRequest("Soft delete fail");

                return Ok("Soft delete success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update-nutrient")]
        public async Task<IActionResult> UpdateNutrient([FromBody] UpdateNutrientRequest request)
        {
            if (request.Id == Guid.Empty)
                return BadRequest("Nutrient Id is null or empty");

            try
            {
                var result = await _nutrientService.UpdateNutrient(request);
                if (result.Error == 1)
                    return BadRequest(result.Message);

                return Ok("Create success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update-nutrient-image")]
        public async Task<IActionResult> UpdateNutrientImage([FromForm] UpdateNutrientImageRequest request)
        {
            if (request.Id == Guid.Empty)
                return BadRequest("Nutrient Id is null or empty");
            if (request.ImageUrl == null)
                return BadRequest("Image is null");
            if (request.ImageUrl.Length > 0 && request.ImageUrl.Length <= 5 * 1024 * 1024)
                return BadRequest("Image size must be smaller than 5mb");

            try
            {
                var result = await _nutrientService.UpdateNutrientImage(request);
                if (result.Error == 1)
                    return BadRequest(result.Message);

                return Ok("Create success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("delete-nutrient-by-id")]
        public async Task<IActionResult> Delete([FromQuery] Guid nutrientId)
        {
            if (nutrientId == Guid.Empty)
                return BadRequest("Nutrient Id is null or empty");

            try
            {
                if (!await _nutrientService.DeleteNutrient(nutrientId))
                    return BadRequest("Delete fail");

                return Ok("Delete success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}