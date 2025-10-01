using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Payment
{
    public class RevenueStatisticsDetailDto
    {
        public PeriodDto Period { get; set; }
        public Guid SubscriptionPlanId { get; set; }
        public string SubscriptionName { get; set; }
        public int Count { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal? GrowthRate { get; set; } // % tăng trưởng so với kỳ trước
    }
}
