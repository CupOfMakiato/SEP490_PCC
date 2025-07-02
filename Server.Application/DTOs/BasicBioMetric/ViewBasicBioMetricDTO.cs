using Server.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.DTOs.BasicBioMetric
{
    public class ViewBasicBioMetricDTO
    {
        public Guid Id { get; set; }
        // Biometrics
        public float WeightKg { get; set; }
        public float HeightCm { get; set; }
        public float BMI { get; set; } // calculated
        // Blood Pressure and Heart Rate
        public int? SystolicBP { get; set; }        // e.g., 120 mmHg // ap suat tam thu
        public int? DiastolicBP { get; set; }       // e.g., 80 mmHg // ap suat tam truong
        public int? HeartRateBPM { get; set; }      // e.g., 75 bpm
        // Sugar Levels
        public float? BloodSugarLevelMgDl { get; set; } // bloog sugar level in mg/dL // duong huyet
        public string? Notes { get; set; } // like side effects of medication, etc.
        public GetUserDTO? CreatedByUser { get; set; }
    }
}
