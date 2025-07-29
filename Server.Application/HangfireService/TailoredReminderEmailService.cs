using Microsoft.Extensions.Logging;
using Server.Application.HangfireInterface;
using Server.Application.Interfaces;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.HangfireService
{
    public class TailoredReminderEmailService : ITailoredReminderEmailService
    {
        private readonly ICurrentTime _currentTime;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly ILogger<TailoredReminderEmailService> _logger;
        public TailoredReminderEmailService(
            IUnitOfWork unitOfWork,
            ICurrentTime currentTime,
            IEmailService emailService,
            ILogger<TailoredReminderEmailService> logger)
        {
            _unitOfWork = unitOfWork;
            _currentTime = currentTime;
            _emailService = emailService;
            _logger = logger;
        }
        public async Task SendTailoredReminderCheckupEmail()
        {
            var today = DateTime.Now.Date;
            var reminders = await _unitOfWork.TailoredCheckupReminderRepository.GetAllActiveTailoredCheckupReminders();
            

            foreach (var reminder in reminders)
            {
                var growthdata = await _unitOfWork.GrowthDataRepository.GetGrowthDataById(reminder.GrowthDataId);
                var email = growthdata.GrowthDataCreatedBy?.Email;
                var reason = reminder.Title ?? "Checkup Reminder";

                if (string.IsNullOrEmpty(email))
                {
                    _logger.LogWarning($"Reminder {reminder.Id}: email is null or empty.");
                    continue;
                }

                switch (reminder.CheckupStatus)
                {
                    case CheckupStatus.NotScheduled:
                        //if (reminder.CreationDate == today)
                        //{
                        //    await _emailService.SendNewlyCreatedCheckupReminder(email);
                        //    _logger.LogInformation($"[Hangfire] Sent mewly created checkup reminder email to {email} for reminder ID: {reminder.Id}");
                        //}

                        //if (reminder.CreationDate <= DateTime.UtcNow.Date.AddMinutes(-1)) //test
                        if (reminder.CreationDate.AddDays(2) == today)
                        {
                            await _emailService.SendUnScheduledCheckupReminder(email);
                            _logger.LogInformation($"[Hangfire] Sent unscheduled checkup reminder email to {email} for reminder ID: {reminder.Id}");
                        }
                        break;

                    case CheckupStatus.Scheduled:
                        if (reminder.ScheduledDate > today && reminder.ScheduledDate <= today.AddDays(3))
                        //if (reminder.ModificationDate <= DateTime.UtcNow.AddMinutes(-1))
                        {
                            await _emailService.SendUpcomingCheckupReminder(email, reason);
                            _logger.LogInformation($"[Hangfire] Sent upcoming checkup reminder email to {email} for reminder ID: {reminder.Id}");
                        }
                        else if (reminder.ScheduledDate < today)
                        {
                            reminder.CheckupStatus = CheckupStatus.Missed;
                            reminder.ModificationDate = _currentTime.GetCurrentTime();
                            _unitOfWork.TailoredCheckupReminderRepository.Update(reminder);
                            // w.i.p send missed checkup reminder email
                            await _emailService.SendMissedScheduledCheckupReminder(email, reason);
                            _logger.LogInformation($"[Hangfire] Sent missed scheduled checkup reminder email to {email} for reminder ID: {reminder.Id}");
                        }
                        break;
                }
            }

            await _unitOfWork.SaveChangeAsync();
        }

    }
}
