using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.TailoredCheckupReminder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface ITailoredCheckupReminderService
    {
        //view
        Task<Result<List<ViewTailoredCheckupReminderDTO>>> ViewAllReminders();
        Task<Result<ViewTailoredCheckupReminderDTO>> ViewCustomChecklistById(Guid id);
        Task<Result<List<ViewTailoredCheckupReminderDTO>>> ViewRemindersByGrowthData(Guid growthDataId);
        Task<Result<List<ViewTailoredCheckupReminderDTO>>> ViewUpcomingRemindersByGrowthData(Guid growthDataId);
        Task<Result<List<ViewTailoredCheckupReminderDTO>>> ViewOverdueRemindersByGrowthData(Guid growthDataId);
        Task<Result<List<ViewTailoredCheckupReminderDTO>>> ViewCompletedRemindersByGrowthData(Guid growthDataId);
        Task<Result<List<ViewTailoredCheckupReminderDTO>>> ViewRemindersByTrimester(Guid growthDataId, int trimester);
        //create
        Task<Result<object>> CreateNewTailoredCheckupReminder(CreateTailoredCheckupReminderDTO CreateTailoredCheckupReminderDTO);
        //edit
        Task<Result<object>> EditTailoredCheckupReminder(EditTailoredCheckupReminderDTO EditTailoredCheckupReminderDTO);
        Task<Result<object>> MarkReminderAsScheduled(Guid ReminderId);
        Task<Result<object>> MarkReminderAsComplete(Guid ReminderId);
        //delete
        Task<Result<object>> DeleteReminder(Guid ReminderId);
        // send reminder
        Task SendEmergencyBiometricAlert(Guid biometricId);
    }
}
