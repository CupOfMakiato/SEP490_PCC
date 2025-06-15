using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Allergy : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid AllergyCategoryId { get; set; }
        public string CommonSymptoms { get; set; }
        public string PregnancyRisk { get; set; }

        public AllergyCategory AllergyCategory { get; set; }
        public ICollection<UserAllergy> UserAllergy { get; set; } = new List<UserAllergy>();
        public ICollection<FoodAllergy> FoodAllergy { get; set; } = new List<FoodAllergy>();


    }
}
