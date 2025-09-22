using Server.Domain.Enums;

namespace Server.Application.DTOs.SubscriptionPlan
{
    public class UpdateSubscriptionPlanRequest
    {
        public Guid Id { get; set; }
        public SubscriptionName SubscriptionName { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int DurationInDays { get; set; } // monthly = 30, yearly = 365, etc.
        public SubscriptionType SubscriptionType { get; set; } // Monthly, Yearly, etc.
        public bool IsActive { get; set; }
    }
}
