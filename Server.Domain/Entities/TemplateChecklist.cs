using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class TemplateChecklist : BaseEntity
    {
        public string TaskName { get; set; }
        public int Trimester { get; set; } // 1, 2, 3
        public bool IsActive { get; set; } = true;
        public ICollection<TemplateChecklistGrowthData> TemplateChecklistGrowthDatas { get; set; } = new List<TemplateChecklistGrowthData>();

    }
}
