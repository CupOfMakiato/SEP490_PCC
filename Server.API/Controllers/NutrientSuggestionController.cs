using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.NutrientSuggestion;
using Server.Application.Interfaces;

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

        [HttpPost("AddAttribute")]
        public async Task<IActionResult> AddAttribute([FromBody] AddNutrientSuggestionAttributeRequest request)
        {
            if (request.NutrientSuggetionId == Guid.Empty)
                return BadRequest("NutrientSuggetionId is required");

            if (string.IsNullOrWhiteSpace(request.Unit))
                return BadRequest("Unit is required");

            if (request.Amount < 0)
                return BadRequest("Amount must be non-negative");

            if (request.NutrientId == Guid.Empty)
                return BadRequest("NutrientId is required");

            if (request.Type < 0)
                return BadRequest("Type must be non-negative");

            if (request.Trimester < 0 || request.Trimester > 3)
                return BadRequest("Trimester must be between 0 and 3");

            if (request.MinEnergyPercentage.HasValue &&
                (request.MinEnergyPercentage < 0 || request.MinEnergyPercentage > 100))
                return BadRequest("MinEnergyPercentage must be between 0 and 100");

            if (request.MaxEnergyPercentage.HasValue &&
                (request.MaxEnergyPercentage < 0 || request.MaxEnergyPercentage > 100))
                return BadRequest("MaxEnergyPercentage must be between 0 and 100");

            if (request.MinEnergyPercentage.HasValue && request.MaxEnergyPercentage.HasValue &&
                request.MinEnergyPercentage > request.MaxEnergyPercentage)
                return BadRequest("MinEnergyPercentage cannot be greater than MaxEnergyPercentage");

            if (request.MinValuePerDay.HasValue && request.MaxValuePerDay.HasValue &&
                request.MinValuePerDay > request.MaxValuePerDay)
                return BadRequest("MinValuePerDay cannot be greater than MaxValuePerDay");

            if (request.MinAnimalProteinPercentageRequire.HasValue &&
                (request.MinAnimalProteinPercentageRequire < 0 || request.MinAnimalProteinPercentageRequire > 100))
                return BadRequest("MinAnimalProteinPercentageRequire must be between 0 and 100");

            try
            {
                var result = await _nutrientSuggestionService.AddNutrientSuggestionAttribute(request);
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
