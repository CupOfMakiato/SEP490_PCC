﻿using Server.Domain.Enums;

namespace Server.Domain.Entities
{
    public class EnergySuggestion : BaseEntity
    {
        public ActivityLevel ActivityLevel { get; set; } //Light - Moderate
        /// <summary>
        /// //Light-20-29: 1760
        /// //Light-30-49: 1730
        /// //Moderate-20-29: 2050
        /// //Moderate-30-49: 2010
        /// </summary>
        public double BaseCalories { get; set; }        
        public int Trimester { get; set; } //1 - 2 - 3
        public double AdditionalCalories { get; set; } //50 - 250 - 450
        public Guid AgeGroupId { get; set; }     
        public AgeGroup AgeGroup { get; set; }
    }
}
