using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class FoodRecommendationHistory : BaseEntity
    {
        public DateTime RecommededAt { get; set; } = DateTime.Now;
        public string Source { get; set; } //Json - Nếu mà có tư vấn viên thì thêm vô Id của nó
        public string Reason { get; set; } = string.Empty;
        //public string Feedback { get; set; } //chưa cần 
        public int PregnancyWeek { get; set; }
        //public User FoodRecommendationHistoryCreatedBy { get; set; }
        [ForeignKey("GrowthDataId")]
        public Guid GrowthDataId { get; set; }
        public GrowthData GrowthData { get; set; }
    }
}
