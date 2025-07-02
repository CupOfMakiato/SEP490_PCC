using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class BasicBioMetric : BaseEntity
    {
        public Guid GrowthDataId { get; set; }
        public GrowthData GrowthData { get; set; }

        // Biometrics
        public float WeightKg { get; set; }         
        public float HeightCm { get; set; }
        // Blood Pressure and Heart Rate
        public int? SystolicBP { get; set; }        // e.g., 120 mmHg // ap suat tam thu
        public int? DiastolicBP { get; set; }       // e.g., 80 mmHg // ap suat tam truong
        public int? HeartRateBPM { get; set; }      // e.g., 75 bpm
        // Sugar Levels
        public float? BloodSugarLevelMgDl { get; set; } // bloog sugar level in mg/dL // duong huyet
        public string? Notes { get; set; } // like side effects of medication, etc.
        public User BasicBioMetricCreatedBy{ get; set; }

        public float GetBMI()
        {
            if (HeightCm <= 0)
                throw new InvalidOperationException("Height must be greater than zero to calculate BMI.");

            // Convert height from cm to meters
            float heightInMeters = HeightCm / 100f;

            // Calculate BMI = weight (kg) / [height (m)]²
            float bmi = WeightKg / (heightInMeters * heightInMeters);

            if (float.IsNaN(bmi) || float.IsInfinity(bmi))
                throw new InvalidOperationException("BMI calculation resulted in an invalid number.");

            return bmi;
        }
    }
}
