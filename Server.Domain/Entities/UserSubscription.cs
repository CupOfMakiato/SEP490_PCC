using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class UserSubscription : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid SubscriptionPlanId { get; set; }
        public SubscriptionPlan SubscriptionPlan { get; set; }
        public float InvoicedPrice { get; set; } // The price charged for this subscription, can differ from the plan price due to discounts or offers
        public string Description { get; set; } // Description of the subscription, can include details like "First month free", "Discount applied", etc.
        public DateTime PaymentDate { get; set; }
        public DateTime? NextBillingDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; } // Payment method used for the subscription, e.g., Credit Card, PayPal, etc.
        //public bool IsActive { get; set; } = true;
        public bool IsAutoRenew { get; set; } = true; // Indicates if the subscription will auto-renew at the end of the period
    }
}
