using Microsoft.AspNetCore.Mvc;
using Server.Application.Interfaces;
using Server.Infrastructure.ThirdPartyServices;

namespace Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIChatController : ControllerBase
    {
        private readonly IGeminiChatService _geminiChatService;

        public AIChatController(IGeminiChatService geminiChatService)
        {
            _geminiChatService = geminiChatService;
        }

        [HttpGet("chat")]
        public async Task<IActionResult> Get(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Query 'query' is required");

            var reply = await _geminiChatService.SendMessageAsync(query);
            return Ok(new { Reply = reply });
        }
    }
}
