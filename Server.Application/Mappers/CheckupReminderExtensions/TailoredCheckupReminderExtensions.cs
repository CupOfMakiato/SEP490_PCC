using Server.Application.Abstractions.RequestAndResponse.CheckupReminder;
using Server.Application.DTOs.CustomChecklist;
using Server.Application.DTOs.TailoredCheckupReminder;
using Server.Domain.Entities;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Mappers.CheckupReminderExtensions
{
    public static class TailoredCheckupReminderExtensions
    {
        public static TailoredCheckupReminder ToTailoredReminder(this CreateTailoredCheckupReminderDTO CreateTailoredCheckupReminderDTO)
        {
            return new TailoredCheckupReminder
            {
                Id = Guid.NewGuid(),
                GrowthDataId = CreateTailoredCheckupReminderDTO.GrowthDataId,
                Title = CreateTailoredCheckupReminderDTO.Title,
                Description = CreateTailoredCheckupReminderDTO.Description,
                RecommendedStartWeek = CreateTailoredCheckupReminderDTO.RecommendedStartWeek,
                RecommendedEndWeek = CreateTailoredCheckupReminderDTO.RecommendedEndWeek,
                Type = CreateTailoredCheckupReminderDTO.Type,
                ScheduledDate = CreateTailoredCheckupReminderDTO.ScheduledDate,
                CompletedDate = CreateTailoredCheckupReminderDTO.ScheduledDate,
                CheckupStatus = CheckupStatus.NotScheduled,
                Note = CreateTailoredCheckupReminderDTO.Note,
                IsActive = true,
            };
        }
        public static CreateTailoredCheckupReminderDTO ToCreateTailoredReminderDTO(this CreateNewTailoredCheckupReminderRequest CreateNewTailoredCheckupReminderRequest)
        {
            return new CreateTailoredCheckupReminderDTO
            {
                GrowthDataId = CreateNewTailoredCheckupReminderRequest.GrowthDataId,
                Title = CreateNewTailoredCheckupReminderRequest.Title,
                Description = CreateNewTailoredCheckupReminderRequest.Description,
                RecommendedStartWeek = CreateNewTailoredCheckupReminderRequest.RecommendedStartWeek ?? CreateNewTailoredCheckupReminderRequest.RecommendedStartWeek,
                RecommendedEndWeek = CreateNewTailoredCheckupReminderRequest.RecommendedEndWeek ?? CreateNewTailoredCheckupReminderRequest.RecommendedEndWeek,
                Type = CreateNewTailoredCheckupReminderRequest.Type,
                Note = CreateNewTailoredCheckupReminderRequest.Note ?? CreateNewTailoredCheckupReminderRequest.Note,
            };
        }
        public static EditTailoredCheckupReminderDTO ToEditTailoredReminderDTO(this EditTailoredCheckupReminderRequest EditTailoredCheckupReminderRequest)
        {
            return new EditTailoredCheckupReminderDTO
            {
                Id = EditTailoredCheckupReminderRequest.Id,
                Title = EditTailoredCheckupReminderRequest.Title,
                Description = EditTailoredCheckupReminderRequest.Description,
                RecommendedStartWeek = EditTailoredCheckupReminderRequest.RecommendedStartWeek,
                RecommendedEndWeek = EditTailoredCheckupReminderRequest.RecommendedEndWeek,
                Type = EditTailoredCheckupReminderRequest.Type ?? EditTailoredCheckupReminderRequest.Type,
                ScheduledDate = EditTailoredCheckupReminderRequest.ScheduledDate,
                CompletedDate = EditTailoredCheckupReminderRequest.CompletedDate,
                CheckupStatus = EditTailoredCheckupReminderRequest.CheckupStatus ?? EditTailoredCheckupReminderRequest.CheckupStatus,
                Note = EditTailoredCheckupReminderRequest.Note,
                IsActive = EditTailoredCheckupReminderRequest.IsActive,
            };
        }
    }
}
