using Server.Application.Abstractions.RequestAndResponse.Blog;
using Server.Application.Abstractions.RequestAndResponse.GrowthData;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.GrowthData;
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
        public static GrowthData ToGrowthData(this CreateNewGrowthDataProfileDTO CreateNewGrowthDataProfileDTO)
        {
            return new GrowthData
            {
                Id = CreateNewGrowthDataProfileDTO.Id,
                Height = CreateNewGrowthDataProfileDTO.Height,
                Weight = CreateNewGrowthDataProfileDTO.Weight,
                FirstDayOfLastMenstrualPeriod = CreateNewGrowthDataProfileDTO.FirstDayOfLastMenstrualPeriod,
                CreatedBy = CreateNewGrowthDataProfileDTO.UserId,
            };
        }

        public static CreateNewGrowthDataProfileDTO ToCreateNewGrowthDataProfileDTO(this CreateNewGrowthDataProfileRequest CreateNewGrowthDataProfileDTORequest)
        {
            return new CreateNewGrowthDataProfileDTO
            {
                Id = (Guid)CreateNewGrowthDataProfileDTORequest.Id,
                UserId = CreateNewGrowthDataProfileDTORequest.UserId,
                FirstDayOfLastMenstrualPeriod = CreateNewGrowthDataProfileDTORequest.FirstDayOfLastMenstrualPeriod,
                Height = CreateNewGrowthDataProfileDTORequest.Height,
                Weight = CreateNewGrowthDataProfileDTORequest.Weight,

            };
        }
    }
}
