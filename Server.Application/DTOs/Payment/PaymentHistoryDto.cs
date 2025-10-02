using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Payment
{
    public class PaymentHistoryDto
    {
        public Guid PaymentId { get; set; }
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
        public string SubscriptionPlan { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
