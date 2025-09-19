using Server.Domain.Enums;

namespace Server.Application.DTOs.Payment
{
    public class CreateCheckoutSessionRequest
    {
        public Guid UserSubscriptionId { get; set; }
        public Guid SubscriptionPlanId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
