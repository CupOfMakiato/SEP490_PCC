using Server.Application.DTOs.Symptom;
using Server.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.Journal
{
    public class ViewJournalDetailDTO
    {
        public Guid Id { get; set; }
        public int CurrentWeek { get; set; }
        public int CurrentTrimester { get; set; }
        public string Note { get; set; }
        public float? CurrentWeight { get; set; }
        public int? SystolicBP { get; set; }        // e.g., 120 mmHg // ap suat tam thu
        public int? DiastolicBP { get; set; }       // e.g., 80 mmHg // ap suat tam truong
        public int? HeartRateBPM { get; set; }      // e.g., 75 bpm
        // Sugar Levels
        public float? BloodSugarLevelMgDl { get; set; } // bloog sugar level in mg/dL // duong huyet
        public List<SymptomDTO> Symptoms { get; set; }
        public string Mood { get; set; }
        public List<string> RelatedImages { get; set; }
        public List<string> UltraSoundImages { get; set; }
        public GetUserDTO? CreatedByUser { get; set; }
    }
}
