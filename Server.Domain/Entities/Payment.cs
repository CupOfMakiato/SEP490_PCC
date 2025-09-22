using Server.Domain.Enums;

namespace Server.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public Guid UserSubscriptionId { get; set; }
        public UserSubscription UserSubscription { get; set; }
        public string Description { get; set; } // Description of the subscription, can include details like "First month free", "Discount applied", etc.
        public decimal InvoicedPrice { get; set; } // The price charged for this subscription, can differ from the plan price due to discounts or offers
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "VND";
        public string CheckoutUrl { get; set; } // URL to redirect the user for payment
        public string GatewayTransactionId { get; set; } // Mã giao dịch từ PayOS
        public string Provider { get; set; } // PayOS, Stripe, PayPal...
        public PaymentMethod PaymentMethod { get; set; } // Payment method used for the subscription, e.g., Credit Card, PayPal, etc.
        public PaymentStatus Status { get; set; } // Pending, Success, Failed, Refunded
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }

        public string RawResponse { get; set; } // JSON lưu từ PayOS webhook
    }
}
