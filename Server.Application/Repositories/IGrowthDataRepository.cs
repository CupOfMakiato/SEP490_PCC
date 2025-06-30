using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface IGrowthDataRepository : IGenericRepository<GrowthData>
    {
        Task<List<GrowthData>> GetAllGrowthData();
        Task<GrowthData> GetGrowthDataById(Guid growthDataId);
        Task<GrowthData> GetActiveGrowthDataById(Guid growthDataId);
        Task<GrowthData> GetGrowthDataFromUserWithCurrentWeek(Guid userId, DateTime currentDate);
        Task<GrowthData> GetGrowthDataWithCurrentWeek(Guid growthDataId, DateTime currentDate);
        Task<GrowthData> GetGrowthDataByUserId(Guid userId);
        Task<GrowthData> GetActiveGrowthDataByUserId(Guid userId);
    }
}
