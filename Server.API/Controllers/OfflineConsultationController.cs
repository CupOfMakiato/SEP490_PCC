using Microsoft.AspNetCore.Mvc;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.OfflineConsultation;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/offline-consultation")]
    [ApiController]
    public class OfflineConsultationController : ControllerBase
    {
        private readonly IOfflineConsultationService _offlineConsultationService;

        public OfflineConsultationController(IOfflineConsultationService offlineConsultationService)
        {
            _offlineConsultationService = offlineConsultationService;
        }

        [HttpGet("view-all-offline-consultations/{userId}")]
        public async Task<IActionResult> GetOfflineConsultations(Guid userId, [FromQuery] string? status)
        {
            var result = await _offlineConsultationService.GetOfflineConsultationsByUserIdAsync(userId, status);

            return Ok(result);
        }

        [HttpGet("view-offline-consultation-by-id/{offlineConsultationId}")]
        public async Task<IActionResult> GetOfflineConsultationById(Guid offlineConsultationId)
        {
            var result = await _offlineConsultationService.GetOfflineConsultationByIdAsync(offlineConsultationId);

            return Ok(result);
        }

        [HttpGet("view-offline-consultations-by-created-by/{userId}")]
        public async Task<IActionResult> GetOfflineConsultationsByCreatedBy(Guid userId)
        {
            var result = await _offlineConsultationService.GetOfflineConsultationsByCreatedByAsync(userId);

            return Ok(result);
        }

        [HttpPost("book-offline-consultation")]
        public async Task<IActionResult> BookOfflineConsultation([FromBody] BookingOfflineConsultationDTO offlineConsultation)
        {
            var result = await _offlineConsultationService.BookOfflineConsultationAsync(offlineConsultation);

            return Ok(result);
        }

        //[HttpPut("cancel-offline-consultation/{offlineConsultationId}")]
        //public async Task<IActionResult> CancelOfflineConsultation(Guid offlineConsultationId)
        //{
        //    var result = await _offlineConsultationService.CancelOfflineConsultationAsync(offlineConsultationId);

        //    return Ok(result);
        //}

        //[HttpPut("confirm-offline-consultation/{offlineConsultationId}")]
        //public async Task<IActionResult> ConfirmOfflineConsultation(Guid offlineConsultationId)
        //{
        //    var result = await _offlineConsultationService.ConfirmOfflineConsultationAsync(offlineConsultationId);

        //    return Ok(result);
        //}

        [HttpDelete("soft-delete-offline-consultation/{offlineConsultationId}")]
        public async Task<IActionResult> SoftDeleteOfflineConsultation(Guid offlineConsultationId)
        {
            var result = await _offlineConsultationService.SoftDeleteOfflineConsultation(offlineConsultationId);

            return Ok(result);
        }

        [HttpPost("send-booking-offline-consultation-emails/{offlineConsultationId}")]
        public async Task<IActionResult> SendBookingEmailAsync(Guid offlineConsultationId)
        {
            var result = await _offlineConsultationService.SendBookingEmailAsync(offlineConsultationId);

            return Ok(result);
        }

        [HttpPost("add-attachments/{offlineConsultationId}")]
        public async Task<IActionResult> AddAttachmentsAsync(Guid offlineConsultationId, [FromForm] List<IFormFile> attachments)
        {
            var result = await _offlineConsultationService.AddAttachmentsAsync(offlineConsultationId, attachments);
            
            return Ok(result);
        }

        [HttpPut("update-offline-consultation")]
        public async Task<IActionResult> UpdateOfflineConsultation([FromBody] UpdateOfflineConsultationDTO offlineConsultation)
        {
            var result = await _offlineConsultationService.UpdateOfflineConsultationAsync(offlineConsultation);

            return Ok(result);
        }

        [HttpPost("send-updated-booking-offline-consultation-emails/{offlineConsultationId}")]
        public async Task<IActionResult> SendUpdatedBookingEmailAsync(Guid offlineConsultationId)
        {
            var result = await _offlineConsultationService.SendUpdatedBookingEmailAsync(offlineConsultationId);

            return Ok(result);
        }
    }
}
