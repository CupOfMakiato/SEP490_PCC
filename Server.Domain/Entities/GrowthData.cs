using Server.Domain.Enums;
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
        //public DateTime DateOfPregnancy { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public DateTime FirstDayOfLastMenstrualPeriod { get; set; }
        public int GestationalAgeInWeeks { get; set; } = 40;
        public DateTime EstimatedDueDate { get; set; }
        public IEnumerable<FoodRecommendationHistory> FoodRecommendationHistories { get; set; }
        public GrowthDataStatus Status { get; set; } = GrowthDataStatus.Active; // can go inactive if user has second prenancy
        public User GrowthDataCreatedBy { get; set; }
        public ICollection<DiseaseGrowthData> DiseaseGrowthData { get; set; } = new List<DiseaseGrowthData>();
        public Journal Journal { get; set; }
        //public Fetus Fetus { get; set; }

        public int GetCurrentGestationalAgeInWeeks(DateTime currentDate)
        {
            var weeks = (currentDate.Date - FirstDayOfLastMenstrualPeriod.Date).Days / 7;
            return Math.Clamp(weeks, 0, 40);
        }

        public int GetCurrentTrimester(DateTime currentDate)
        {
            int currentWeek = GetCurrentGestationalAgeInWeeks(currentDate);
            return currentWeek switch
            {
                < 14 => 1,
                < 28 => 2,
                _ => 3
            };
        }
    }
}
