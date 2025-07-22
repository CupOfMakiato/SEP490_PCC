using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.OnlineConsultation;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/online-consultation")]
    [ApiController]
    public class OnlineConsultationController : ControllerBase
    {
        private readonly IOnlineConsultationService _onlineConsultationService;

        public OnlineConsultationController(IOnlineConsultationService onlineConsultationService)
        {
            _onlineConsultationService = onlineConsultationService;
        }

        [HttpGet("view-all-online-consultations/{consultantId}")]
        public async Task<IActionResult> GetOnlineConsultations(Guid consultantId, [FromQuery] string? status)
        {
            var result = await _onlineConsultationService.GetOnlineConsultationsAsync(consultantId, status);

            return Ok(result);
        }

        [HttpGet("view-online-consultation-by-id/{onlineConsultationId}")]
        public async Task<IActionResult> GetOnlineConsultationById(Guid onlineConsultationId)
        {
            var result = await _onlineConsultationService.GetOnlineConsultationByIdAsync(onlineConsultationId);

            return Ok(result);
        }

        [HttpPost("book-online-consultation")]
        public async Task<IActionResult> BookOnlineConsultation([FromBody] AddOnlineConsultationDTO onlineConsultation)
        {
            var result = await _onlineConsultationService.BookOnlineConsultationAsync(onlineConsultation);

            return Ok(result);
        }

        [HttpPut("update-online-consultation")]
        public async Task<IActionResult> UpdateOnlineConsultation([FromBody] UpdateOnlineConsultationDTO onlineConsultation)
        {
            var result = await _onlineConsultationService.UpdateOnlineConsultation(onlineConsultation);

            return Ok(result);
        }

        [HttpPut("cancel-online-consultation/{onlineConsultationId}")]
        public async Task<IActionResult> CancelOnlineConsultation(Guid onlineConsultationId)
        {
            var result = await _onlineConsultationService.CancelOnlineConsultationAsync(onlineConsultationId);

            return Ok(result);
        }

        [HttpPut("confirm-online-consultation/{onlineConsultationId}")]
        public async Task<IActionResult> ConfirmOnlineConsultation(Guid onlineConsultationId)
        {
            var result = await _onlineConsultationService.ConfirmOnlineConsultationAsync(onlineConsultationId);

            return Ok(result);
        }

        [HttpDelete("soft-delete-online-consultation/{onlineConsultationId}")]
        public async Task<IActionResult> SoftDeleteOnlineConsultation(Guid onlineConsultationId)
        {
            var result = await _onlineConsultationService.SoftDeleteOnlineConsultation(onlineConsultationId);

            return Ok(result);
        }
    }
}
