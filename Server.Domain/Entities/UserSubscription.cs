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
        public ICollection<Payment> Payments { get; set; }
        public UserSubscriptionStatus Status { get; set; } // Current status of the subscription, e.g., Active, Canceled, Expired
        public DateTime ExpiresAt { get; set; }
        public DateTime? NextBillingDate { get; set; }        
        public bool IsAutoRenew { get; set; } = true; // Indicates if the subscription will auto-renew at the end of the period
    }
}
