using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Payment
{
    public class RevenueStatisticsRaw
    {
        public int? Month { get; set; }
        public int? Quarter { get; set; }
        public int Year { get; set; }
        public Guid SubscriptionPlanId { get; set; }
        public string SubscriptionName { get; set; }
        public int Count { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
