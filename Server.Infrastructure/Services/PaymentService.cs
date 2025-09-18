using Server.Application.DTOs.Payment;
using Server.Application.Interfaces;

namespace Server.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        public Task<string> CreateCheckoutSession(CreateCheckoutSessionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
