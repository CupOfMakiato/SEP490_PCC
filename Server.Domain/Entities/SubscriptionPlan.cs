using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class SubscriptionPlan : BaseEntity
    {
        public SubscriptionName SubscriptionName { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int? DurationInDays { get; set; } // monthly = 30, yearly = 365, etc.
        public SubscriptionType SubscriptionType { get; set; } // Monthly, Yearly, etc.
        public bool IsActive { get; set; } = true; // if false, the plan is not available for new subscriptions
        public ICollection<UserSubscription> UserSubscriptions { get; set; } = new List<UserSubscription>();
    }
}
