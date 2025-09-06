using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.Allergy;
using Server.Application.Interfaces;
using Server.Application.Services;

namespace Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly IAllergyService _allergyService;

        public AllergyController(IAllergyService allergyService)
        {
            _allergyService = allergyService;
        }

        [HttpGet("view-allergy-by-id")]
        public async Task<IActionResult> GetAllergyByIdAsync([FromQuery] Guid allergyId)
        {
            if (allergyId == Guid.Empty)
                return BadRequest("Allergy Id is null or empty");

            var result = await _allergyService.GetAllergyByIdAsync(allergyId);
            if (result.Error == 1)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpGet("view-all-allergies")]
        public async Task<IActionResult> GetAllergiesAsync()
        {
            var result = await _allergyService.GetAllergiesAsync();
            if (result.Error == 1)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("soft-delete-allergy-by-id")]
        public async Task<IActionResult> SoftDeleteAllergy([FromQuery] Guid allergyId)
        {
            if (allergyId == Guid.Empty)
                return BadRequest("Allergy Id is null or empty");

            var result = await _allergyService.SoftDeleteAllergy(allergyId);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("delete-allergy-by-id")]
        public async Task<IActionResult> DeleteAllergy([FromQuery] Guid allergyId)
        {
            if (allergyId == Guid.Empty)
                return BadRequest("Allergy Id is null or empty");

            var result = await _allergyService.DeleteAllergy(allergyId);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("add-allergy")]
        public async Task<IActionResult> CreateAllergy([FromBody] CreateAllergyRequest request)
        {
            if (request == null)
                return BadRequest("Allergy must not be null");

            var result = await _allergyService.CreateAllergy(request);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("update-allergy")]
        public async Task<IActionResult> UpdateAllergy([FromBody] UpdateAllergyRequest request)
        {
            if (request == null)
                return BadRequest("Allergy must not be null");

            var result = await _allergyService.UpdateAllergy(request);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

    }
}
