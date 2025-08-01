using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class TemplateChecklistGrowthData
    {
        public Guid GrowthDataId { get; set; }
        public GrowthData GrowthData { get; set; }
        public Guid TemplateChecklistId { get; set; }
        public TemplateChecklist TemplateChecklist { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedDate { get; set; }
    }
}
