using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.Disease;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly IDiseaseService _diseaseService;

        public DiseaseController(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }

        [HttpGet("view-disease-by-id")]
        public async Task<IActionResult> GetDiseaseByIdAsync([FromQuery] Guid diseaseId)
        {
            var result = await _diseaseService.GetDiseaseByIdAsync(diseaseId);
            if (result.Error == 1)
                return BadRequest(result.Message);
            return Ok(result.Data);
        }

        [HttpGet("view-all-diseases")]
        public async Task<IActionResult> GetDiseasesAsync()
        {
            var result = await _diseaseService.GetDiseasesAsync();
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("soft-delete-disease-by-id")]
        public async Task<IActionResult> SoftDeleteDisease([FromQuery] Guid diseaseId)
        {
            var result = await _diseaseService.SoftDeleteDisease(diseaseId);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("delete-disease-by-id")]
        public async Task<IActionResult> DeleteDisease([FromQuery] Guid diseaseId)
        {
            var result = await _diseaseService.DeleteDisease(diseaseId);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("add-disease")]
        public async Task<IActionResult> CreateDisease([FromBody] CreateDiseaseRequest request)
        {
            if (request == null)
                return BadRequest("Disease must not be null");

            var result = await _diseaseService.CreateDisease(request);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("update-disease")]
        public async Task<IActionResult> UpdateDisease([FromBody] UpdateDiseaseRequest request)
        {
            if (request == null)
                return BadRequest("Disease must not be null");

            var result = await _diseaseService.UpdateDisease(request);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
