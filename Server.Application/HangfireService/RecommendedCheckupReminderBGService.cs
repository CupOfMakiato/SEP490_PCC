using Microsoft.Extensions.Logging;
using Server.Application.HangfireInterface;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Application.Services;
using Server.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.HangfireService
{
    public class RecommendedCheckupReminderBGService : IRecommendedCheckupReminderBGService
    {
        private readonly ICurrentTime _currentTime;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRecommendedCheckupReminderRepository _recommendedCheckupReminderRepository;
        private readonly ILogger<RecommendedCheckupReminderBGService> _logger;
        private readonly IEmailService _emailService;
        private readonly INotificationService _notificationService;
        private readonly IClaimsService _claimsService;

        public RecommendedCheckupReminderBGService(
            IUnitOfWork unitOfWork,
            ICurrentTime currentTime,
            ILogger<RecommendedCheckupReminderBGService> logger,
            IEmailService emailService,
            IRecommendedCheckupReminderRepository recommendedCheckupReminderRepository,
            INotificationService notificationService,
            IClaimsService claimsService)
        {
            _recommendedCheckupReminderRepository = recommendedCheckupReminderRepository;
            _unitOfWork = unitOfWork;
            _currentTime = currentTime;
            _logger = logger;
            _emailService = emailService;
            _notificationService = notificationService;
            _claimsService = claimsService;
        }

        /// <summary>
        /// Creates reminder links for a new GrowthData if none exist.
        /// </summary>
        public async Task EnsureRemindersForGrowthData(GrowthData growthData, string userEmail)
        {
            var existingLinks = await _recommendedCheckupReminderRepository
                .GetRecommendedCheckupsByGrowthDataId(growthData.Id);

            if (existingLinks.Any())
            {
                _logger.LogInformation($"GrowthData {growthData.Id} already has reminders, skipping generation.");
                return;
            }

            var templates = await _recommendedCheckupReminderRepository.GetAllActiveRecommendedCheckups();

            foreach (var template in templates)
            {
                // Store schedule date as NOW (not based on start week)
                var link = new RecommendedCheckupGrowthData
                {
                    GrowthDataId = growthData.Id,
                    RecommendedCheckupId = template.Id,
                    ScheduledDate = DateTime.UtcNow.Date,
                    IsCompleted = false,
                    CompletedDate = null
                };

                await _unitOfWork.RecommendedCheckupReminderRepository.AddCheckupLink(link);
            }

            await _unitOfWork.SaveChangeAsync();
            _logger.LogInformation($"Reminders generated for GrowthData {growthData.Id}");
        }

        /// <summary>
        /// Recurring job that processes and sends reminders.
        /// Sends reminder exactly 1 week before the recommended start week.
        /// </summary>
        public async Task ProcessDueReminders()
        {
            var now = DateTime.UtcNow.Date;

            var allReminders = await _recommendedCheckupReminderRepository.GetAllActiveCheckupLinks();
            

            foreach (var reminder in allReminders)
            {
                if (reminder.IsCompleted)
                    continue;

                var checkup = reminder.RecommendedCheckup
                              ?? await _recommendedCheckupReminderRepository.GetRecommendedCheckupById(reminder.RecommendedCheckupId);

                if (checkup?.RecommendedStartWeek == null)
                    continue;

                var growthData = await _unitOfWork.GrowthDataRepository.GetGrowthDataById(reminder.GrowthDataId);
                if (growthData == null || growthData.FirstDayOfLastMenstrualPeriod == default)
                    continue;

                var recommendedStartDate = growthData.FirstDayOfLastMenstrualPeriod
                    .AddDays(checkup.RecommendedStartWeek.Value * 7);

                var reminderSendDate = recommendedStartDate.AddDays(-7);

                _logger.LogInformation(
                    $"Evaluating reminder {reminder.RecommendedCheckupId}: " +
                    $"RecommendedStartDate={recommendedStartDate}, ReminderSendDate={reminderSendDate}, Now={now}");

                if (now.Date < reminderSendDate.Date)
                {
                    _logger.LogInformation($"Reminder {reminder.RecommendedCheckupId}: Not yet due.");
                    continue;
                }
                if (reminder.IsCompleted)
                {
                    continue;
                }


                var userEmail = growthData?.GrowthDataCreatedBy?.Email;
                if (string.IsNullOrEmpty(userEmail))
                {
                    _logger.LogWarning($"Reminder {reminder.RecommendedCheckupId}: User email is missing, skipping.");
                    continue;
                }

                var reason = checkup.Title ?? "Recommended checkup";

                try
                {
                    await _emailService.SendUpcomingRecommendedCheckupReminder(userEmail, reason);

                    reminder.IsCompleted = true;
                    reminder.CompletedDate = now;
                    await _unitOfWork.SaveChangeAsync();

                    _logger.LogInformation($"Reminder {reminder.RecommendedCheckupId} sent and marked completed.");


                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error sending reminder {reminder.RecommendedCheckupId} for GrowthData {reminder.GrowthDataId}");
                }


                var userId = growthData?.GrowthDataCreatedBy?.Id;
                var startweek = reminder?.RecommendedCheckup?.RecommendedStartWeek;
                var notiReminderId = reminder?.RecommendedCheckup?.Id;
                if (userId == null)
                {
                    _logger.LogWarning($"Reminder {notiReminderId}: User not found, cannot create notification.");
                    continue;
                }

                var notification = new Notification
                {
                    Id = Guid.NewGuid(),
                    Message = $"We recommended that you should schedule for an upcoming consultation soon for the week {startweek}",
                    CreatedBy = userId.Value,  
                    IsSent = true,
                    IsRead = false,
                    CreationDate = DateTime.UtcNow.Date
                };

                if (reminder == null)
                {
                    _logger.LogWarning($"Reminder not found, cannot create notification.");
                    continue;
                }
                await _notificationService.CreateNotification(notification, reminder, "RecommendedCheckupReminder");

            }

            await _unitOfWork.SaveChangeAsync();

        }

    }

}