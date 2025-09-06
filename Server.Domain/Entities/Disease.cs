using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Disease : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Symptoms { get; set; }
        public string TreatmentOptions { get; set; }
        public bool PregnancyRelated { get; set; }
        public string RiskLevel { get; set; }
        public string TypeOfDesease { get; set; }
        public ICollection<DiseaseGrowthData> DiseaseGrowthData { get; set; } = new List<DiseaseGrowthData>();
        public ICollection<FoodDiseaseWarning> FoodDiseaseWarning { get; set; } = new List<FoodDiseaseWarning>();
    }
}
