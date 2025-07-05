using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.GrowthData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface IGrowthDataService
    {

        // view
        Task<Result<List<ViewGrowthDataDTO>>> ViewAllGrowthDatas();
        Task<Result<ViewGrowthDataDTO>> ViewGrowthDataById(Guid growthdataId);
        Task<Result<ViewGrowthDataDTO>> ViewGrowthDataWithCurrentWeek(Guid userId, DateTime currentDate);
        Task<Result<ViewGrowthDataDTO>> ViewGrowthDataByUserId(Guid userId);
        // create
        Task<Result<object>> CreateNewGrowthDataProfile(CreateNewGrowthDataProfileDTO CreateNewGrowthDataProfileDTO);
        // edit 
        Task<Result<object>> EditGrowthDataProfile(EditGrowthDataProfileDTO EditGrowthDataProfileDTO);
        // delete
        Task<Result<object>> DeleteGrowthData(Guid growthDataId);
    }
}
