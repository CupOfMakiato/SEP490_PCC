using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.UserSubscription;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/user-subscription")]
    [ApiController]
    public class UserSubscriptionController : ControllerBase
    {
        private readonly IUserSubscriptionService _userSubscriptionService;

        public UserSubscriptionController(IUserSubscriptionService userSubscriptionService)
        {
            _userSubscriptionService = userSubscriptionService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUserSubscription([FromBody] CreateUserSubscriptionRequest request)
        {
            if (request == null)
                return BadRequest(new { Message = "Invalid request data" });
            if(request.SubscriptionPlanId == Guid.Empty)
                return BadRequest(new { Message = "SubscriptionPlanId is required" });
            try
            {
                var result = await _userSubscriptionService.CreateUserSubscription(request);
                if (result.Error != 0)
                {
                    return BadRequest(new { result.Message });
                }
                return Ok(result.Data);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }            
        }

        [HttpGet("view-user-subscription-by-user-id/{userId}")]
        public async Task<IActionResult> GetActiveSubscriptionByUserId(Guid userId)
        {
            if (userId == Guid.Empty)
                return BadRequest(new { Message = "Invalid userId" });
            try
            {
                var result = await _userSubscriptionService.GetAllSubscriptionsByUserId(userId);
                if (result.Error != 0)
                {
                    return BadRequest(new { result.Message });
                }
                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("view-user-subscription-by-id/{userSubscriptionId}")]
        public async Task<IActionResult> GetUserSubscriptionById(Guid userSubscriptionId)
        {
            if (userSubscriptionId == Guid.Empty)
                return BadRequest(new { Message = "Invalid userSubscriptionId" });
            try
            {
                var result = await _userSubscriptionService.GetUserSubscriptionById(userSubscriptionId);
                if (result.Error != 0)
                {
                    return BadRequest(new { result.Message });
                }
                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("view-all-user-subscriptions")]
        public async Task<IActionResult> GetAllUserSubscriptions()
        {
            try
            {
                var result = await _userSubscriptionService.GetAllUserSubscriptions();
                if (result.Error != 0)
                {
                    return BadRequest(new { result.Message });
                }
                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("renew-subscription/{userSubscriptionId}")]
        public async Task<IActionResult> RenewSubscription(Guid userSubscriptionId, [FromBody] DateTime expiresAt)
        {
            if (userSubscriptionId == Guid.Empty)
                return BadRequest(new { Message = "Invalid userSubscriptionId" });
            if (expiresAt == default)
                return BadRequest(new { Message = "Invalid expiresAt date" });
            if (expiresAt <= DateTime.UtcNow)
                return BadRequest(new { Message = "expiresAt must be a future date" });
            try
            {
                var result = await _userSubscriptionService.RenewSubscription(userSubscriptionId, expiresAt);
                if (result.Error != 0)
                {
                    return BadRequest(new { result.Message });
                }
                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("cancel-subscription/{userSubscriptionId}")]
        public async Task<IActionResult> CancelSubscription(Guid userSubscriptionId)
        {
            if (userSubscriptionId == Guid.Empty)
                return BadRequest(new { Message = "Invalid userSubscriptionId" });
            try
            {
                var result = await _userSubscriptionService.CancelSubscription(userSubscriptionId);
                if (result.Error != 0)
                {
                    return BadRequest(new { result.Message });
                }
                return Ok(new { Message = "Subscription canceled successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("expire-subscription/{userSubscriptionId}")]
        public async Task<IActionResult> ExpireSubscription(Guid userSubscriptionId)
        {
            if (userSubscriptionId == Guid.Empty)
                return BadRequest(new { Message = "Invalid userSubscriptionId" });
            try
            {
                var result = await _userSubscriptionService.ExpireSubscription(userSubscriptionId);
                if (result.Error != 0)
                {
                    return BadRequest(new { result.Message });
                }
                return Ok(new { Message = "Subscription expired successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
