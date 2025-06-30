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
        /// <summary>
        /// Lưu thông tin thức ăn dưới dạng json
        /// </summary>
        public string Source { get; set; } //Json - Nếu mà có tư vấn viên thì thêm vô Id của nó
        public string Reason { get; set; } = string.Empty;

        [ForeignKey("GrowthDataId")]
        public Guid GrowthDataId { get; set; }
        public GrowthData GrowthData { get; set; }
        public List<FoodRecommendationHistoryVersion> Versions { get; set; }

        public int PregnancyWeek()
        {
            if (Versions is null)
            {
                throw new ArgumentNullException(nameof(Versions));
            }

            var lastedVersion = Versions?.OrderByDescending(v => v.Version).FirstOrDefault();
            var pregnancyWeek = (int)((DateTime.Now - lastedVersion.FirstDateOfPregnancy).TotalDays / 7);
            return pregnancyWeek;
        }
    }
}
