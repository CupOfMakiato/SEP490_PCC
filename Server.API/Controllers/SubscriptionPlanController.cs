using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.SubscriptionPlan;
using Server.Application.Interfaces;
using Server.Application.Services;

namespace Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionPlanController : ControllerBase
    {
        private readonly ISubscriptionPlanService _subscriptionPlanService;

        public SubscriptionPlanController(ISubscriptionPlanService subscriptionPlanService)
        {
            _subscriptionPlanService = subscriptionPlanService;
        }

        [HttpGet("GetAllSubscriptionPlans")]
        public async Task<IActionResult> GetAllSubscriptionPlans()
        {
            var result = await _subscriptionPlanService.GetSubscriptionPlans();
            return Ok(result);
        }

        [HttpGet("GetSubscriptionPlanById/{id}")]
        public async Task<IActionResult> GetSubscriptionPlanById(Guid id)
        {
            var result = await _subscriptionPlanService.GetSubscriptionPlanById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("CreateSubscriptionPlan")]
        public async Task<IActionResult> CreateSubscriptionPlan([FromBody] CreateSubscriptionPlanRequest request)
        {
            var result = await _subscriptionPlanService.CreateSubscriptionPlan(request);
            if (result.Error != 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("UpdateSubscriptionPlan")]
        public async Task<IActionResult> UpdateSubscriptionPlan([FromBody] UpdateSubscriptionPlanRequest request)
        {
            var result = await _subscriptionPlanService.UpdateSubscriptionPlan(request);
            if (result.Error != 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("DeleteSubscriptionPlan/{id}")]
        public async Task<IActionResult> DeleteSubscriptionPlan(Guid id)
        {
            var result = await _subscriptionPlanService.DeleteSubscriptionPlan(id);
            if (result.Error != 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPatch("ToggleSubscriptionPlanStatus/{id}")]
        public async Task<IActionResult> ToggleSubscriptionPlanStatus(Guid id)
        {
            var result = await _subscriptionPlanService.ToggleSubscriptionPlanStatus(id);
            if (result.Error != 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
