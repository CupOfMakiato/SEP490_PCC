using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class FoodAllergy
    {
        public Guid FoodId { get; set; }
        public Guid AllergyId { get; set; }
        public bool ContainsAllergen { get; set; }
        public string AllergenLevel { get; set; }
        public string Description { get; set; }

        public Food Food { get; set; }
        public Allergy Allergy { get; set; }
    }
}
