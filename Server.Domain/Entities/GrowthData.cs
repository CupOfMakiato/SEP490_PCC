﻿using Server.Domain.Enums;
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
        public IEnumerable<DishesRecommendationHistory> FoodRecommendationHistories { get; set; }
        public GrowthDataStatus Status { get; set; } = GrowthDataStatus.Active; // can go inactive if user has second prenancy
        public User GrowthDataCreatedBy { get; set; }
        public ICollection<DiseaseGrowthData> DiseaseGrowthData { get; set; } = new List<DiseaseGrowthData>();
        public ICollection<Journal> Journals { get; set; } = new List<Journal>();
        public BasicBioMetric BasicBioMetric { get; set; } // Basic biometrics like weight, height, blood pressure, etc. // 1 - 1
        public ICollection<TailoredCheckupReminder> TailoredCheckupReminders { get; set; } = new List<TailoredCheckupReminder>();
        public ICollection<CustomChecklist> CustomChecklists { get; set; } = new List<CustomChecklist>();
        public ICollection<TemplateChecklistGrowthData> TemplateChecklistGrowthDatas { get; set; } = new List<TemplateChecklistGrowthData>();
        public ICollection<RecommendedCheckupGrowthData> RecommendedCheckupGrowthDatas { get; set; } = new List<RecommendedCheckupGrowthData>();
        //public ICollection<FetusDevelopment> FetusDevelopments { get; set; }
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
