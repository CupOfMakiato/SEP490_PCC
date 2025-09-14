using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.EnergySuggestion;
using Server.Application.DTOs.Food;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnergySuggestionController : ControllerBase
    {
        private readonly IEnergySuggestionService _energyService;

        public EnergySuggestionController(IEnergySuggestionService energyService)
        {
            _energyService = energyService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Gets()
        {
            return Ok(await _energyService.GetEnergySuggestionsAsync());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] Guid enegrySuggestionId)
        {
            return Ok(await _energyService.GetEnergySuggestionByIdAsync(enegrySuggestionId));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateEnergySuggestionRequest request)
        {
            if (request.BaseCalories == 0)
                return BadRequest("BaseCalories is invalid");

            if (request.Trimester == 0 || request.Trimester > 3)
                return BadRequest("Trimester is invalid");

            if (request.AdditionalCalories == 0)
                return BadRequest("AdditionalCalories is invalid");

            if (request.AgeGroupId == Guid.Empty)
                return BadRequest("AgeGroupId is required");

            try
            {
                var result = await _energyService.CreateEnergySuggestion(request);
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
        public async Task<IActionResult> Update([FromBody] UpdateEnergySuggestionRequest request)
        {
            if (request.BaseCalories == 0)
                return BadRequest("BaseCalories is invalid");

            if (request.Trimester == 0 || request.Trimester > 3)
                return BadRequest("Trimester is invalid");

            if (request.AdditionalCalories == 0)
                return BadRequest("AdditionalCalories is invalid");

            if (request.AgeGroupId == Guid.Empty)
                return BadRequest("AgeGroupId is required");

            try
            {
                if (!await _energyService.UpdateEnergySuggestion(request))
                    return BadRequest("Update fail");

                return Ok("Update Success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDelete([FromQuery] Guid energySuggestionId)
        {
            if (energySuggestionId == Guid.Empty)
                return BadRequest("energySuggestionId is null or empty");

            try
            {
                if (!await _energyService.SoftDeleteEnergySuggestion(energySuggestionId))
                    return BadRequest("Soft delete fail");

                return Ok("Soft delete success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
