using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.Consultant;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/consultant")]
    [ApiController]
    public class ConsultantController : ControllerBase
    {
        private readonly IConsultantService _consultantService;

        public ConsultantController(IConsultantService consultantService)
        {
            _consultantService = consultantService;
        }

        [HttpGet("view-consultant-by-id/{consultantId}")]
        public async Task<IActionResult> ViewConsultantById(Guid consultantId)
        {
            var consultant = await _consultantService.GetConsultantByIdAsync(consultantId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(consultant);
        }

        [HttpPost("create-consultant")]
        public async Task<IActionResult> CreateConsultant(AddConsultantDTO addConsultantDTO)
        {
            var result = await _consultantService.CreateConsultant(addConsultantDTO);

            return Ok(result);
        }

        [HttpPut("update-consultant")]
        public async Task<IActionResult> UpdateConsultant(UpdateConsultantDTO updateConsultantDTO)
        {
            var result = await _consultantService.UpdateConsultant(updateConsultantDTO);

            return Ok(result);
        }

        [HttpDelete("soft-delete-consultant/{consultantId}")]
        public async Task<IActionResult> SoftDeleteConsultant(Guid consultantId)
        {
            var result = await _consultantService.SoftDeleteConsultant(consultantId);

            return Ok(result);
        }
    }
}
