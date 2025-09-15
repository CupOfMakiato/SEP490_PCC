using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.RecommendedCheckupReminder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface IRecommendedCheckupReminderService
    {
        Task<Result<List<ViewRecommendedCheckupReminderDTO>>> ViewAllReminders(Guid growthDataId);
        Task<Result<ViewRecommendedCheckupReminderDTO>> LinkCheckupToGrowthData(Guid checkupId, Guid growthDataId, DateTime? scheduledDate = null);
        Task LinkAllCheckupsToGrowthData(Guid growthDataId);
    }
}
