using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.CustomChecklist
{
    public class EditCustomChecklistInfoDTO
    {
        public Guid Id { get; set; }
        //public Guid? GrowthDataId { get; set; }
        public string? TaskName { get; set; }
        public int? Trimester { get; set; } // 1, 2, 3
    }
}
