using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Payment
{
    public class DashboardStatisticsDto
    {
        public List<RevenueStatisticsDetailDto> RevenueStatistics { get; set; }
        public List<UserSubscriptionStatisticsDetailDto> UserSubscriptionStatistics { get; set; }
    }
}
