using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Journal;
using Server.Application.DTOs.Notification;
using Server.Application.Interfaces;
using Server.Application.Services;
using Server.Domain.Entities;

namespace Server.API.Controllers
{
    [Route("api/notification")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet("view-notifications-by-user-id")]
        [ProducesResponseType(200, Type = typeof(ViewNotificationDTO))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewNotificationsByUserId(Guid userId)
        {
            var result = await _notificationService.GetNotificationsByUserId(userId);
            return Ok(result);
        }
        [HttpGet("view-notification-by-id")]
        [ProducesResponseType(200, Type = typeof(ViewNotificationDTO))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewNotificationById(Guid notificationId)
        {
            var result = await _notificationService.GetNotificationById(notificationId);
            return Ok(result);
        }
        [HttpPut("mark-notification-as-read")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> MarkNotificationAsRead(Guid notificationId)
        {
            var result = await _notificationService.MarkNotificationAsRead(notificationId);
            return Ok(result);
        }
        [HttpDelete("delete-notification")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> DeleteNotification(Guid notificationId)
        {
            var result = await _notificationService.DeleteNotification(notificationId);
            return Ok(result);
        }

    }
}
