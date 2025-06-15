using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class DiseaseGrowthData
    {
        public Guid DiseaseId { get; set; }
        public Guid GrowDataId { get; set; }
        public DateTime DiseaseTime { get; set; }

        public Disease Disease { get; set; }
        public GrowthData GrowthData { get; set; }
    }
}
