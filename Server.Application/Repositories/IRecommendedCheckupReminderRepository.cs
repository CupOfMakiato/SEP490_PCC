using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface IRecommendedCheckupReminderRepository : IGenericRepository<RecommendedCheckup>
    {
        Task<List<RecommendedCheckup>> GetAllRecommendedCheckups();
        Task<List<RecommendedCheckup>> GetAllActiveRecommendedCheckups();
        Task<RecommendedCheckup> GetRecommendedCheckupById(Guid id);
        Task<List<RecommendedCheckup>> GetAllCompletedRecommendedCheckups();
        Task<List<RecommendedCheckup>> GetAllInCompleteRecommendedCheckups();
        Task<List<RecommendedCheckup>> GetRecommendedCheckupsByGrowthDataId(Guid growthDataId);
        Task AddCheckupLink(RecommendedCheckupGrowthData link);
        Task<RecommendedCheckupGrowthData?> GetCheckupLinkById(Guid linkId);
        Task UpdateCheckupLink(RecommendedCheckupGrowthData link);
        Task<List<RecommendedCheckupGrowthData>> GetAllDueReminders(DateTime notifyThreshold);
        Task<List<RecommendedCheckupGrowthData>> GetAllActiveCheckupLinks();

    }
}
