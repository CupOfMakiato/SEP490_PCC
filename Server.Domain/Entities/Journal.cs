﻿using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class Journal : BaseEntity
    {
        public Guid GrowthDataId { get; set; }
        public int CurrentWeek { get; set; }
        public int CurrentTrimester { get; set; }
        public string Note { get; set; }
        public float CurrentWeight { get; set; }
        //public Symptom Symptoms { get; set; } = Symptom.None;
        public Mood MoodNotes { get; set; } = Mood.Normal;

        public GrowthData GrowthData { get; set; }
        public User JournalCreatedBy { get; set; }

        // List of images
        public ICollection<Media> Media { get; set; } = new List<Media>();
        public ICollection<Food> DoctorRecommedFoods { get; set; }
        public ICollection<Nutrient> DoctorRecommedNutrients { get; set; }
        public ICollection<JournalSymptom> JournalSymptoms { get; set; } = new List<JournalSymptom>();

    }
}
