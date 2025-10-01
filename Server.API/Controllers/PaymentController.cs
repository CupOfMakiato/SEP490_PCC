using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.Payment;
using Server.Application.Interfaces;
using Server.Application.Services;
using Server.Domain.Enums;
using Server.Infrastructure.Services;

namespace Server.API.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("checkout-session")]
        public async Task<IActionResult> CreateCheckoutSession([FromBody] CreateCheckoutSessionRequest request)
        {
            // model validation
            if (request == null)
                return BadRequest("Request body is required.");

            if (request.UserSubscriptionId == Guid.Empty)
                return BadRequest("UserSubscriptionId is required.");

            if (request.SubscriptionPlanId == Guid.Empty)
                return BadRequest("SubscriptionPlanId is required.");

            if (request.PaymentMethod == PaymentMethod.Unknown)
                return BadRequest("PaymentMethod is required.");

            // service call
            var result = await _paymentService.CreateCheckoutSession(request);

            if (result.Error != 0)
                return BadRequest(new { result.Error, result.Message });

            return Ok(new
            {
                result.Data.Id,
                result.Data.CheckoutUrl,
                result.Data.Amount,
                result.Data.Currency,
                result.Data.Status,
                result.Data.ExpiresAt
            });
        }

        [HttpPatch("active-subscription/{userSubscriptionId}")]
        public async Task<IActionResult> ActiveSubscription(Guid userSubscriptionId)
        {
            if (userSubscriptionId == Guid.Empty)
                return BadRequest(new { Message = "Invalid userSubscriptionId" });
            try
            {
                var result = await _paymentService.ActiveSubscription(userSubscriptionId);
                if (result.Error != 0)
                {
                    return BadRequest(new { result.Message });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
