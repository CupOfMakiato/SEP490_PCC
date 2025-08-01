using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class RecommendedCheckup : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Note { get; set; }

        // Optional for recommended checkups
        public int? RecommendedStartWeek { get; set; } // usually 4 weeks span
        public int? RecommendedEndWeek { get; set; }
        public CheckupType Type { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<RecommendedCheckupGrowthData> RecommendedCheckupGrowthDatas { get; set; } = new List<RecommendedCheckupGrowthData>();
    }
}
