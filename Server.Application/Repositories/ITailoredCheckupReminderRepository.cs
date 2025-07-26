using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface ITailoredCheckupReminderRepository : IGenericRepository<TailoredCheckupReminder>
    {
        Task<List<TailoredCheckupReminder>> GetAllTailoredCheckupReminders();
        Task<TailoredCheckupReminder?> GetTailoredCheckupReminderById(Guid id);
        Task<List<TailoredCheckupReminder>> GetAllTailoredCheckupRemindersByGrowthData(Guid growthDataId);
        Task<List<TailoredCheckupReminder>> GetOverdueRemindersByGrowthData(Guid growthDataId, DateTime currentDate);
        Task<List<TailoredCheckupReminder>> GetUpcomingRemindersByGrowthData(Guid growthDataId, DateTime currentDate);
        Task<List<TailoredCheckupReminder>> GetCompletedRemindersByGrowthData(Guid growthDataId, DateTime currentDate);
        Task<List<TailoredCheckupReminder>> GetRemindersByTrimester(Guid growthDataId, int trimester);
    }
}
