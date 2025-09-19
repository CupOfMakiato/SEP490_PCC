using Microsoft.AspNetCore.Mvc;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.ChatThread;
using Server.Application.DTOs.Message;
using Server.Application.DTOs.Notification;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("get-chat-thread-by-user-id/{userId}")]
        public async Task<IActionResult> GetChatThreadsByUserIdAsync(Guid userId)
        {
            var result = await _messageService.GetChatThreadsByUserIdAsync(userId);

            return Ok(result);
        }

        [HttpGet("get-chat-thread-by-id/{chatThreadId}")]
        public async Task<IActionResult> GetChatThreadByIdAsync(Guid chatThreadId)
        {
            var result = await _messageService.GetChatThreadByIdAsync(chatThreadId);

            return Ok(result);
        }

        [HttpPost("send-message")]
        public async Task<IActionResult> SendMessageAsync([FromForm] SendMessageDTO sendMessage)
        {
            var result = await _messageService.SendMessageAsync(sendMessage);

            return Ok(result);
        }

        [HttpPost("start-thread")]
        [ProducesResponseType(200, Type = typeof(ViewChatThreadDTO))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> StartThreadAsync([FromBody] CreateChatThreadDTO chatThread)
        {
            var result = await _messageService.StartThreadAsync(chatThread);

            return Ok(result);
        }

        [HttpDelete("soft-delete-message/{messageId}")]
        public async Task<IActionResult> SoftDeleteMessageAsync(Guid messageId)
        {
            var result = await _messageService.SoftDeleteMessageAsync(messageId);

            return Ok(result);
        }

        [HttpDelete("soft-delete-chat-thread/{chatThreadId}")]
        public async Task<IActionResult> SoftDeleteChatThreadAsync(Guid chatThreadId)
        {
            var result = await _messageService.SoftDeleteChatThreadAsync(chatThreadId);

            return Ok(result);
        }
    }
}
