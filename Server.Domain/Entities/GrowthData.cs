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
        //public int Height { get; set; } // might remove
        public float PreWeight { get; set; } // Weight before pregnancy
        public DateTime FirstDayOfLastMenstrualPeriod { get; set; }
        public int GestationalAgeInWeeks { get; set; } = 40;
        public DateTime EstimatedDueDate { get; set; }
        public IEnumerable<FoodRecommendationHistory> FoodRecommendationHistories { get; set; }
        public GrowthDataStatus Status { get; set; } = GrowthDataStatus.Active; // can go inactive if user has second prenancy
        public User GrowthDataCreatedBy { get; set; }
        public ICollection<DiseaseGrowthData> DiseaseGrowthData { get; set; } = new List<DiseaseGrowthData>();
        public ICollection<Journal> Journals { get; set; } = new List<Journal>();
        public BasicBioMetric BasicBioMetric { get; set; } // Basic biometrics like weight, height, blood pressure, etc. // 1 - 1
        public ICollection<TrimesterChecklist> TrimesterChecklists { get; set; } = new List<TrimesterChecklist>();
        public ICollection<CheckupReminder> CheckupReminders { get; set; } = new List<CheckupReminder>();

        //public Fetus Fetus { get; set; } // this is static data
        public int GetGestationalAgeInWeeks()
        {
            var weeks = (EstimatedDueDate.Date - FirstDayOfLastMenstrualPeriod.Date).Days / 7;
            return Math.Clamp(weeks, 1, 40);
        }
        public int GetCurrentGestationalAgeInWeeks(DateTime currentDate)
        {
            var weeks = (currentDate.Date - FirstDayOfLastMenstrualPeriod.Date).Days / 7;
            return Math.Clamp(weeks, 1, 40);
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
