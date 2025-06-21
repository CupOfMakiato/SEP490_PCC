using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface IJournalRepository : IGenericRepository<Journal>
    {
        Task<List<Journal>> GetAllJournals();
        Task<Journal> GetJournalById(Guid id);
        Task<List<Journal>> GetJournalsByGrowthDataId(Guid growthDataId);
        Task<List<Journal>> GetJournalsByUserId(Guid userId);
        Task<List<Journal>> GetJournalsByWeekAndTrimester(int week, int trimester);
    }
}
