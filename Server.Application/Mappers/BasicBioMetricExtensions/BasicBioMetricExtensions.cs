using Server.Application.Abstractions.RequestAndResponse.BasicBioMetric;
using Server.Application.DTOs.BasicBioMetric;
using Server.Application.DTOs.Journal;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Mappers.BasicBioMetricExtensions
{
    public static class BasicBioMetricExtensions
    {
        public static BasicBioMetric ToBBM(this CreateBasicBioMetricDTO CreateBasicBioMetricDTO)
        {
            return new BasicBioMetric
            {
                Id = CreateBasicBioMetricDTO.Id,
                GrowthDataId = CreateBasicBioMetricDTO.GrowthDataId,
                WeightKg = CreateBasicBioMetricDTO.WeightKg,
                HeightCm = CreateBasicBioMetricDTO.HeightCm,
                SystolicBP = CreateBasicBioMetricDTO.SystolicBP,
                DiastolicBP = CreateBasicBioMetricDTO.DiastolicBP,
                HeartRateBPM = CreateBasicBioMetricDTO.HeartRateBPM,
                BloodSugarLevelMgDl = CreateBasicBioMetricDTO.BloodSugarLevelMgDl,
                Notes = CreateBasicBioMetricDTO.Notes

            };
        }
        public static CreateBasicBioMetricDTO ToCreateBasicBioMetricDTO(this CreateBasicBioMetricRequest CreateBasicBioMetricRequest)
        {
            return new CreateBasicBioMetricDTO
            {
                Id = (Guid)CreateBasicBioMetricRequest.Id,
                GrowthDataId = CreateBasicBioMetricRequest.GrowthDataId,
                WeightKg = CreateBasicBioMetricRequest.WeightKg,
                HeightCm = CreateBasicBioMetricRequest.HeightCm,
                SystolicBP = CreateBasicBioMetricRequest.SystolicBP,
                DiastolicBP = CreateBasicBioMetricRequest.DiastolicBP,
                HeartRateBPM = CreateBasicBioMetricRequest.HeartRateBPM,
                BloodSugarLevelMgDl = CreateBasicBioMetricRequest.BloodSugarLevelMgDl,
                Notes = CreateBasicBioMetricRequest.Notes
            };
        }
        public static EditBasicBioMetricDTO ToEditBasicBioMetricDTO(this EditBasicBioMetricRequest EditBasicBioMetricRequest)
        {
            return new EditBasicBioMetricDTO
            {
                Id = EditBasicBioMetricRequest.Id,
                //GrowthDataId = EditBasicBioMetricRequest.GrowthDataId,
                WeightKg = EditBasicBioMetricRequest.WeightKg,
                HeightCm = EditBasicBioMetricRequest.HeightCm,
                SystolicBP = EditBasicBioMetricRequest.SystolicBP,
                DiastolicBP = EditBasicBioMetricRequest.DiastolicBP,
                HeartRateBPM = EditBasicBioMetricRequest.HeartRateBPM,
                BloodSugarLevelMgDl = EditBasicBioMetricRequest.BloodSugarLevelMgDl,
                Notes = EditBasicBioMetricRequest.Notes
            };
        }
    }
}
