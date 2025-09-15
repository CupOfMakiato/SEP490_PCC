using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class FoodDisease
    {
        public Guid DiseaseId { get; set; }
        public Guid FoodId { get; set; }
        public FoodDiseaseStatus Status { get; set; }
        public string Description { get; set; }
        public Disease Disease { get; set; }
        public Food Food { get; set; }
    }
}
