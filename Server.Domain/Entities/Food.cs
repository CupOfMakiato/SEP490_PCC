using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Food : BaseEntity
    {
        public string Name { get; set; }    
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool PregnancySafe { get; set; }
        public Guid FoodCategoryId { get; set; }
        public string SafetyNote { get; set; }
        public Guid SuggestionRuleId {  get; set; }
        public FoodCategory FoodCategory { get; set; }
        public IEnumerable<FoodVitamin> FoodVitamins { get; set; }
        public SuggestionRule SuggestionRule {  set; get; }
    }
}
