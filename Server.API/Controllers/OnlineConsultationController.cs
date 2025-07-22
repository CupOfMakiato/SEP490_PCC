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

        [HttpGet("view-all-online-consultations-by-consultant-id/{consultantId}")]
        public async Task<IActionResult> GetOnlineConsultationsByConsultantId(Guid consultantId)
        {
            var result = await _onlineConsultationService.GetOnlineConsultationsByConsultantIdAsync(consultantId);

            return Ok(result);
        }

        [HttpGet("view-all-online-consultations-by-user-id/{userId}")]
        public async Task<IActionResult> GetOnlineConsultationsByUserId(Guid userId)
        {
            var result = await _onlineConsultationService.GetOnlineConsultationsByUserIdAsync(userId);

            return Ok(result);
        }

        [HttpGet("view-online-consultation-by-id/{onlineConsultationId}")]
        public async Task<IActionResult> GetOnlineConsultationById(Guid onlineConsultationId)
        {
            var result = await _onlineConsultationService.GetOnlineConsultationByIdAsync(onlineConsultationId);

            return Ok(result);
        }

        [HttpPost("create-online-consultation")]
        public async Task<IActionResult> CreateOnlineConsultation([FromBody] AddOnlineConsultationDTO onlineConsultation)
        {
            var result = await _onlineConsultationService.CreateOnlineConsultation(onlineConsultation);

            return Ok(result);
        }

        [HttpPut("update-online-consultation")]
        public async Task<IActionResult> UpdateOnlineConsultation([FromBody] UpdateOnlineConsultationDTO onlineConsultation)
        {
            var result = await _onlineConsultationService.UpdateOnlineConsultation(onlineConsultation);

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
