using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.NutrientSuggestion;
using Server.Application.Interfaces;
using Server.Application.Services;

namespace Server.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NutrientSuggestionController : ControllerBase
    {
        private readonly INutrientSuggestionService _nutrientSuggestionService;

        public NutrientSuggestionController(INutrientSuggestionService nutrientSuggestionService)
        {
            _nutrientSuggestionService = nutrientSuggestionService;
        }

        [HttpGet("GetEssentialNutritionalNeedsInOneDay")]
        public async Task<ActionResult> GetEssentialNutritionalNeedsInOneDay([FromBody] GetEssentialNutritionalNeedsInOneDayRequest request)
        {
            var result = await _nutrientSuggestionService.GetEssentialNutritionalNeedsInOneDay(request);

            if (result.Error == 1)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateNutrientSuggestionRequest request)
        {
            if (request.Id == Guid.Empty)
                return BadRequest("Id is required");

            if (string.IsNullOrWhiteSpace(request.NutrientSuggetionName))
                return BadRequest("NutrientSuggetionName is required");

            try
            {
                var result = await _nutrientSuggestionService.UpdateNutrientSuggestion(request);
                if (result.Error != 0)
                    return BadRequest(result.Message);

                return Ok("Update Success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDelete([FromQuery] Guid nutrientSuggestionId)
        {
            if (nutrientSuggestionId == Guid.Empty)
                return BadRequest("nutrientSuggestionId is null or empty");

            try
            {
                var result = await _nutrientSuggestionService.SoftDeleteNutrientSuggestion(nutrientSuggestionId);
                if (result.Error != 0)
                    return BadRequest(result.Message);

                return Ok("Soft delete success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateNutrientSuggestionRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.NutrientSuggetionName))
                return BadRequest("NutrientSuggetionName is required");

            try
            {
                var result = await _nutrientSuggestionService.CreateNutrientSuggestion(request);
                if (result.Error != 0)
                    return BadRequest(result.Message);

                return Ok("Create Success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
