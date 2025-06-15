using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class MenstrualCycle : BaseEntity
    {
        public Guid GrowthDataId { get; set; }
        public DateTime FirstDayOfLastMenstrualPeriod { get; set; }
        public int GestationalAgeInWeeks { get; set; }
        public int CurrentTrimester { get; set; }
        public DateTime EstimatedDueDate { get; set; }
        public GrowthData GrowthData { get; set; }
    }
}
