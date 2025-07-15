using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class TailoredCheckupReminder : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        // Optional for recommended checkups
        public int? RecommendedStartWeek { get; set; }
        public int? RecommendedEndWeek { get; set; }
        public CheckupType Type { get; set; }

        public DateTime? ScheduledDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public CheckupStatus CheckupStatus { get; set; }

        public string? Note { get; set; }
        public Guid GrowthDataId { get; set; }
        public GrowthData GrowthData { get; set; }
    }
}
