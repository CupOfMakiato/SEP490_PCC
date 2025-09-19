using Microsoft.AspNetCore.Mvc;
using Server.Application.Interfaces;
using Server.Infrastructure.Services;

namespace Server.API.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
    }
}
