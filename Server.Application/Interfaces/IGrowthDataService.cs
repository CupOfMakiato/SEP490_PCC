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
        // create
        Task<Result<object>> CreateNewGrowthDataProfile(CreateNewGrowthDataProfileDTO createNewGrowthDataProfileDTO);
    }
}
