using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Payment
{
    public class UserSubscriptionStatisticsRaw
    {
        public int? Month { get; set; }
        public int? Quarter { get; set; }
        public int Year { get; set; }
        public int ActiveCount { get; set; }
        public int ExpiredCount { get; set; }
        public int CanceledCount { get; set; }
        public int PendingCount { get; set; }
        public int TotalUsers { get; set; }
        public int TotalMonthsUsed { get; set; }
    }
}
