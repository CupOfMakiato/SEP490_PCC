using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Vitamin : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public string ImageUrl { get; set; }
        public string Unit { get; set; }
        public Guid CategoryId { get; set; }
        public VitaminCategory VitaminCategory { get; set; }
        public IEnumerable<FoodVitamin> FoodVitamins { get; set; }
    }
}
