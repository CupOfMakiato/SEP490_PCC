using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.Nutrient;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NutrientController : ControllerBase
    {
        private readonly INutrientService _nutrientService;

        public NutrientController(INutrientService nutrientService)
        {
            _nutrientService = nutrientService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Gets()
        {
            return Ok(await _nutrientService.GetNutrientsAsync());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] Guid nutrientId)
        {
            return Ok(await _nutrientService.GetNutrientByIdAsync(nutrientId));
        }

        [HttpGet("GetWithDetailsById")]
        public async Task<IActionResult> GetWithDetailsById([FromQuery] Guid nutrientId)
        {
            return Ok(await _nutrientService.GetNutrientByIdAsync(nutrientId));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateNutrientRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest("Name is required");

            if (string.IsNullOrWhiteSpace(request.Unit))
                return BadRequest("Unit is required");

            if (string.IsNullOrWhiteSpace(request.Description))
                return BadRequest("Unit is required");

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

        [HttpPut("ApproveNutrient")]
        public async Task<IActionResult> Update([FromQuery] Guid nutrientId)
        {
            if (nutrientId == Guid.Empty)
                return BadRequest("Nutrient Id is null or empty");

            try
            {
                var result = await _nutrientService.ApproveNutrient(nutrientId);
                if (result.Error == 1)
                    return BadRequest(result.Message);

                return Ok(new { Data = result.Data, Message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("SoftDelete")]
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

        [HttpDelete("Delete")]
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