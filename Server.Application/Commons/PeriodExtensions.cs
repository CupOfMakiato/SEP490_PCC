using Server.Application.DTOs.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Commons
{
    public static class PeriodExtensions
    {
        public static PeriodDto ToPeriodDto(this RevenueStatisticsRaw r)
        {
            if (r == null) return null;
            if (r.Month.HasValue)
                return new PeriodDto { Type = "Month", Value = r.Month.Value, Year = r.Year };
            if (r.Quarter.HasValue)
                return new PeriodDto { Type = "Quarter", Value = r.Quarter.Value, Year = r.Year };
            return new PeriodDto { Type = "Year", Value = r.Year, Year = r.Year };
        }

        public static PeriodDto ToPeriodDto(this UserSubscriptionStatisticsRaw r)
        {
            if (r == null) return null;
            if (r.Month.HasValue)
                return new PeriodDto { Type = "Month", Value = r.Month.Value, Year = r.Year };
            if (r.Quarter.HasValue)
                return new PeriodDto { Type = "Quarter", Value = r.Quarter.Value, Year = r.Year };
            return new PeriodDto { Type = "Year", Value = r.Year, Year = r.Year };
        }
    }
}
