using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class TrimesterChecklist : BaseEntity
    {
        public string TaskName { get; set; }
        public int Trimester { get; set; } // 1, 2, 3
        public int Order { get; set; }

        public Guid GrowthDataId { get; set; }
        public GrowthData GrowthData { get; set; }
        public bool IsTemplate { get; set; } = true; 

        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedDate { get; set; }
    }
}
