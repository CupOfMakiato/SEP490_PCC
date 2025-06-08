using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class GrowthData : BaseEntity
    {
        public DateTime FirstDateOfPregnancy { get; set; }
        public int Week { get; set; }
        public IEnumerable<FoodRecommendationHistory> FoodRecommendationHistories { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }  
    }
}
