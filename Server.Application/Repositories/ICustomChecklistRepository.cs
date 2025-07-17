using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface ICustomChecklistRepository : IGenericRepository<CustomChecklist>
    {
        Task<List<CustomChecklist>> GetAllCustomChecklists();
        Task<List<CustomChecklist>> GetAllActiveCustomChecklists();
        Task<CustomChecklist> GetCustomChecklistById(Guid id);
        Task<List<CustomChecklist>> GetCustomChecklistsByGrowthDataId(Guid growthDataId);
        Task<List<CustomChecklist>> GetCustomChecklistsByTrimester(int trimester, Guid userId);
        Task<List<CustomChecklist>> ViewAllCompletedChecklists();
        Task<List<CustomChecklist>> ViewAllInCompleteChecklists();
        Task<List<CustomChecklist>> GetAllInActiveCustomChecklists();

    }
}