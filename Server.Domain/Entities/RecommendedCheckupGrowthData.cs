using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class RecommendedCheckupGrowthData
    {
        public Guid GrowthDataId { get; set; }
        public GrowthData GrowthData { get; set; }
        public Guid RecommendedCheckupId { get; set; }
        public RecommendedCheckup RecommendedCheckup{ get; set; }
        public DateTime? ScheduledDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
