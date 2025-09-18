using Server.Application.DTOs.Payment;

namespace Server.Application.Interfaces
{
    public interface IPaymentService
    {
        public Task<string> CreateCheckoutSession(CreateCheckoutSessionRequest request);
    }
}
