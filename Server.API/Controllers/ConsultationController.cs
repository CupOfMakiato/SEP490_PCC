using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.Consultation;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/consultation")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationService _consultationService;

        public ConsultationController(IConsultationService consultationService)
        {
            _consultationService = consultationService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateConsultation([FromBody] AddConsultationDTO consultation)
        {
            var result = await _consultationService.CreateConsultation(consultation);

            return Ok(result);
        }

        [HttpGet("view-consultation-by-id/{consultationId}")]
        public async Task<IActionResult> GetConsultationById(Guid consultationId)
        {
            var result = await _consultationService.GetConsultationByIdAsync(consultationId);

            return Ok(result);
        }

        [HttpGet("view-all-consultation-by-consultant-id/{consultantId}")]
        public async Task<IActionResult> GetConsultationsByConsultantId(Guid consultantId)
        {
            var result = await _consultationService.GetConsultationByConsultantIdAsync(consultantId);

            return Ok(result);
        }

        [HttpPut("update-consultation")]
        public async Task<IActionResult> UpdateConsultation([FromBody] UpdateConsultationDTO consultation)
        {
            var result = await _consultationService.UpdateConsultatation(consultation);

            return Ok(result);
        }

        [HttpDelete("soft-delete-consultation/{consultationId}")]
        public async Task<IActionResult> SoftDeleteConsultation(Guid consultationId)
        {
            var result = await _consultationService.SoftDeleteConsultation(consultationId);

            return Ok(result);
        }
    }
}
