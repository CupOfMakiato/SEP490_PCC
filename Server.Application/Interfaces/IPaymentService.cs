using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Payment;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface IPaymentService
    {
        public Task<Result<Payment>> CreateCheckoutSession(CreateCheckoutSessionRequest request);
        public Task<Result<bool>> ActiveSubscription(Guid userSubscriptionId);
    }
}
