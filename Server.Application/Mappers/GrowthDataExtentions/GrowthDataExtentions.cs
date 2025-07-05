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

        public static EditGrowthDataProfileDTO ToEditGrowthDataProfileDTO(this EditGrowthDataProfileRequest EditGrowthDataProfileRequest, ICurrentTime currentTime)
        {
            var estimatedDueDate = EditGrowthDataProfileRequest.EstimatedDueDate != default
                ? EditGrowthDataProfileRequest.EstimatedDueDate
                : EditGrowthDataProfileRequest.FirstDayOfLastMenstrualPeriod.AddDays(280);

            return new EditGrowthDataProfileDTO
            {
                Id = (Guid)EditGrowthDataProfileRequest.Id,
                PreWeight = EditGrowthDataProfileRequest.PreWeight,
                FirstDayOfLastMenstrualPeriod = EditGrowthDataProfileRequest.FirstDayOfLastMenstrualPeriod,
                EstimatedDueDate = estimatedDueDate,
            };
        }

        // Validation helper methods using entity logic
        public static bool IsValidGestationalAge(this EditGrowthDataProfileDTO dto, ICurrentTime currentTime)
        {
            var today = currentTime.GetCurrentTime().Date;
            var tempEntity = new GrowthData
            {
                FirstDayOfLastMenstrualPeriod = dto.FirstDayOfLastMenstrualPeriod,
                EstimatedDueDate = dto.EstimatedDueDate
            };

            var gestationalAge = tempEntity.GetCurrentGestationalAgeInWeeks(today);
            return gestationalAge >= 0 && gestationalAge <= 42;
        }

        public static bool IsValidDueDateRange(this EditGrowthDataProfileDTO dto)
        {
            var calculatedDueDate = dto.FirstDayOfLastMenstrualPeriod.AddDays(280);

            // Allow some flexibility in due date (±2 weeks from calculated)
            return dto.EstimatedDueDate >= calculatedDueDate.AddDays(-14) &&
                   dto.EstimatedDueDate <= calculatedDueDate.AddDays(14);
        }

        public static bool IsValidLMPDate(this EditGrowthDataProfileDTO dto, ICurrentTime currentTime)
        {
            var today = currentTime.GetCurrentTime().Date;
            var maxLMPDate = today.AddDays(-7); // At least 1 week ago
            var minLMPDate = today.AddDays(-294); // Not more than 42 weeks ago

            return 
                dto.FirstDayOfLastMenstrualPeriod >= minLMPDate 
                && dto.FirstDayOfLastMenstrualPeriod <= maxLMPDate
                ;
        }

        public static bool IsValidWeight(this EditGrowthDataProfileDTO dto)
        {
            return dto.PreWeight > 0 && dto.PreWeight < 300;
        }

        public static int GetCurrentTrimester(this EditGrowthDataProfileDTO dto, ICurrentTime currentTime)
        {
            var today = currentTime.GetCurrentTime().Date;
            var tempEntity = new GrowthData
            {
                FirstDayOfLastMenstrualPeriod = dto.FirstDayOfLastMenstrualPeriod,
                EstimatedDueDate = dto.EstimatedDueDate
            };

            return tempEntity.GetCurrentTrimester(today);
        }

        public static int GetCurrentGestationalAgeInWeeks(this EditGrowthDataProfileDTO dto, ICurrentTime currentTime)
        {
            var today = currentTime.GetCurrentTime().Date;
            var tempEntity = new GrowthData
            {
                FirstDayOfLastMenstrualPeriod = dto.FirstDayOfLastMenstrualPeriod,
                EstimatedDueDate = dto.EstimatedDueDate
            };

            return tempEntity.GetCurrentGestationalAgeInWeeks(today);
        }
    }
}
