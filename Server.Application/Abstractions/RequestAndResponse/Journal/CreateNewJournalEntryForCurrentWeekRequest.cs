using Microsoft.AspNetCore.Http;
using Server.Domain.Entities;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Abstractions.RequestAndResponse.Journal
{
    public class CreateNewJournalEntryForCurrentWeekRequest
    {
        public Guid? Id { get; set; }
        public Guid UserId { get; set; }
        public Guid GrowthDataId { get; set; }
        public int CurrentWeek { get; set; }
        public string Note { get; set; } = string.Empty;
        public float CurrentWeight { get; set; }
        public int? SystolicBP { get; set; }        // e.g., 120 mmHg // ap suat tam thu
        public int? DiastolicBP { get; set; }       // e.g., 80 mmHg // ap suat tam truong
        public int? HeartRateBPM { get; set; }      // e.g., 75 bpm
        // Sugar Levels
        public float? BloodSugarLevelMgDl { get; set; } // bloog sugar level in mg/dL // duong huyet

        public List<string>? SymptomNames { get; set; } = new List<string>();
        public Mood? MoodNotes { get; set; }
        public List<IFormFile>? RelatedImages { get; set; }
        public List<IFormFile>? UltraSoundImages { get; set; }

    }
}
