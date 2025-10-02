using Server.Application.DTOs.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Commons
{
    public static class StatisticsHelper
    {
        public static List<T> CalculateGrowthPerSeries<T, TKey>(
            List<T> stats,
            Func<T, TKey> seriesKeySelector,
            Func<T, decimal> valueSelector,
            Func<T, PeriodDto> periodSelector,
            Action<T, decimal?> setGrowth)
        {
            var groups = stats.GroupBy(seriesKeySelector);
            var output = new List<T>();

            foreach (var grp in groups)
            {
                var ordered = grp.OrderBy(s => periodSelector(s).Year)
                                 .ThenBy(s => periodSelector(s).Value)
                                 .ToList();

                for (int i = 0; i < ordered.Count; i++)
                {
                    if (i == 0)
                    {
                        setGrowth(ordered[i], null);
                        continue;
                    }

                    var prev = ordered[i - 1];
                    var cur = ordered[i];
                    var prevValue = valueSelector(prev);

                    if (prevValue == 0)
                    {
                        setGrowth(cur, null);
                    }
                    else
                    {
                        var growth = ((valueSelector(cur) - prevValue) / prevValue) * 100m;
                        setGrowth(cur, Math.Round(growth, 2));
                    }
                }

                output.AddRange(ordered);
            }

            return output.OrderBy(s => periodSelector(s).Year)
                         .ThenBy(s => periodSelector(s).Value)
                         .ToList();
        }
    }

}
