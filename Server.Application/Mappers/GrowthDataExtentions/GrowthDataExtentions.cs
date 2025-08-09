using Org.BouncyCastle.Asn1.Ocsp;
using Server.Application.Abstractions.RequestAndResponse.Blog;
using Server.Application.Abstractions.RequestAndResponse.GrowthData;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.GrowthData;
using Server.Application.Interfaces;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Mappers.GrowthDataExtentions
{
    public static class GrowthDataExtentions
    {
        public static GrowthData ToGrowthData(this CreateNewGrowthDataProfileDTO CreateNewGrowthDataProfileDTO, ICurrentTime currentTime)
        {
            var today = currentTime.GetCurrentTime().Date;
            var growthData = new GrowthData
            {
                Id = CreateNewGrowthDataProfileDTO.Id,
                PreWeight = (float)CreateNewGrowthDataProfileDTO.PreWeight,
                FirstDayOfLastMenstrualPeriod = CreateNewGrowthDataProfileDTO.FirstDayOfLastMenstrualPeriod,
                EstimatedDueDate = CreateNewGrowthDataProfileDTO.FirstDayOfLastMenstrualPeriod.AddDays(280),
                CreatedBy = CreateNewGrowthDataProfileDTO.UserId,
            };

            growthData.GestationalAgeInWeeks = growthData.GetCurrentGestationalAgeInWeeks(today);

            return growthData;
        }

        public static CreateNewGrowthDataProfileDTO ToCreateNewGrowthDataProfileDTO(this CreateNewGrowthDataProfileRequest CreateNewGrowthDataProfileDTORequest)
        {
            return new CreateNewGrowthDataProfileDTO
            {
                Id = (Guid)CreateNewGrowthDataProfileDTORequest.Id,
                UserId = CreateNewGrowthDataProfileDTORequest.UserId,
                FirstDayOfLastMenstrualPeriod = CreateNewGrowthDataProfileDTORequest.FirstDayOfLastMenstrualPeriod,
                PreWeight = CreateNewGrowthDataProfileDTORequest.PreWeight,
            };
        }

        public static EditGrowthDataProfileDTO ToEditGrowthDataProfileDTO(this EditGrowthDataProfileRequest req, ICurrentTime currentTime)
        {
            DateTime? estimatedDueDate = req.EstimatedDueDate;

            if (!estimatedDueDate.HasValue && req.FirstDayOfLastMenstrualPeriod.HasValue)
            {
                estimatedDueDate = req.FirstDayOfLastMenstrualPeriod.Value.AddDays(280);
            }

            return new EditGrowthDataProfileDTO
            {
                Id = req.Id ?? Guid.Empty,
                PreWeight = req.PreWeight,
                FirstDayOfLastMenstrualPeriod = req.FirstDayOfLastMenstrualPeriod,
                EstimatedDueDate = estimatedDueDate
            };
        }

        public static bool IsValidGestationalAge(this EditGrowthDataProfileDTO dto, ICurrentTime currentTime)
        {
            if (!dto.FirstDayOfLastMenstrualPeriod.HasValue || !dto.EstimatedDueDate.HasValue)
                return true; // or false depending on how strict you want to be

            var today = currentTime.GetCurrentTime().Date;
            var tempEntity = new GrowthData
            {
                FirstDayOfLastMenstrualPeriod = dto.FirstDayOfLastMenstrualPeriod.Value,
                EstimatedDueDate = dto.EstimatedDueDate.Value
            };

            var ga = tempEntity.GetCurrentGestationalAgeInWeeks(today);
            return ga >= 0 && ga <= 42;
        }

        public static bool IsValidDueDateRange(this EditGrowthDataProfileDTO dto)
        {
            if (!dto.FirstDayOfLastMenstrualPeriod.HasValue || !dto.EstimatedDueDate.HasValue)
                return true; // or false depending on your rules

            var calculatedEDD = dto.FirstDayOfLastMenstrualPeriod.Value.AddDays(280);
            return dto.EstimatedDueDate.Value >= calculatedEDD.AddDays(-14) &&
                   dto.EstimatedDueDate.Value <= calculatedEDD.AddDays(14);
        }

        public static bool IsValidLMPDate(this EditGrowthDataProfileDTO dto, ICurrentTime currentTime)
        {
            if (!dto.FirstDayOfLastMenstrualPeriod.HasValue)
                return true; // or false based on business rules

            var today = currentTime.GetCurrentTime().Date;
            var maxLMPDate = today.AddDays(-7);   // 1 week ago
            var minLMPDate = today.AddDays(-294); // 42 weeks ago

            return dto.FirstDayOfLastMenstrualPeriod.Value >= minLMPDate &&
                   dto.FirstDayOfLastMenstrualPeriod.Value <= maxLMPDate;
        }

        public static bool IsValidWeight(this EditGrowthDataProfileDTO dto)
        {
            return dto.PreWeight.HasValue && dto.PreWeight > 0 && dto.PreWeight < 300;
        }

        public static int GetCurrentTrimester(this EditGrowthDataProfileDTO dto, ICurrentTime currentTime)
        {
            if (!dto.FirstDayOfLastMenstrualPeriod.HasValue || !dto.EstimatedDueDate.HasValue)
                return 0;

            var today = currentTime.GetCurrentTime().Date;
            var tempEntity = new GrowthData
            {
                FirstDayOfLastMenstrualPeriod = dto.FirstDayOfLastMenstrualPeriod.Value,
                EstimatedDueDate = dto.EstimatedDueDate.Value
            };

            return tempEntity.GetCurrentTrimester(today);
        }

        public static int GetCurrentGestationalAgeInWeeks(this EditGrowthDataProfileDTO dto, ICurrentTime currentTime)
        {
            if (!dto.FirstDayOfLastMenstrualPeriod.HasValue || !dto.EstimatedDueDate.HasValue)
                return 0;

            var today = currentTime.GetCurrentTime().Date;
            var tempEntity = new GrowthData
            {
                FirstDayOfLastMenstrualPeriod = dto.FirstDayOfLastMenstrualPeriod.Value,
                EstimatedDueDate = dto.EstimatedDueDate.Value
            };

            return tempEntity.GetCurrentGestationalAgeInWeeks(today);
        }
    }
}
