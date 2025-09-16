namespace Server.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public DateTime PaymentDate { get; set; }
        public List<UserSubscription> UserSubscriptions { get; set; }   
    }
}
