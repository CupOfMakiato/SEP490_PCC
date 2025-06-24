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
        Task<GrowthData> GetGrowthDataById(Guid blogId);
        Task<GrowthData> GetActiveGrowthDataById(Guid blogId);
        Task<GrowthData> GetGrowthDataFromUserWithCurrentWeek(Guid userId, DateTime currentDate);
        Task<GrowthData> GetGrowthDataWithCurrentWeek(Guid blogId, DateTime currentDate);
        Task<GrowthData> GetGrowthDataByUserId(Guid userId);
    }
}
