using Microsoft.Extensions.Logging;
using Server.Application.HangfireInterface;
using Server.Application.Interfaces;
using Server.Domain.Entities;
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

        public async Task SendEmergencyBiometricAlert(DateTime lastCheckTime)
        {
            var biometrics = await _unitOfWork.BasicBioMetricRepository.GetAllRecentBiometrics(lastCheckTime);

            foreach (var bio in biometrics)
            {
                if (IsAbnormal(bio))
                {
                    var email = bio.GrowthData?.GrowthDataCreatedBy?.Email;
                    if (string.IsNullOrEmpty(email))
                    {
                        _logger.LogWarning($"Biometric {bio.Id}: email is null or empty.");
                        continue;
                    }

                    await _emailService.SendEmergencyBiometricAlert(
                        email,
                        "Emergency Consultation Recommended",
                        $"Your recent biometric reading (BMI {bio.GetBMI()}, BP {bio.SystolicBP}/{bio.DiastolicBP}, Sugar {bio.BloodSugarLevelMgDl}) indicates abnormal values. Please book a consultation immediately."
                    );

                    _logger.LogInformation($"[Hangfire] Sent emergency biometric email to {email} for BasicBioMetric ID: {bio.Id}");
                }
            }
        }
        private static DateTime _lastCheckTime = DateTime.UtcNow.AddMinutes(-5);

        public async Task RunEmergencyBiometricJob()
        {
            await SendEmergencyBiometricAlert(_lastCheckTime);

            _lastCheckTime = DateTime.UtcNow;
        }


        // will check this stats again
        private bool IsAbnormal(BasicBioMetric bio)
        {
            if (bio.SystolicBP.HasValue && bio.DiastolicBP.HasValue)
            {
                if (bio.SystolicBP > 140 || bio.DiastolicBP > 90) // Hypertension
                    return true;
                if (bio.SystolicBP < 90 || bio.DiastolicBP < 60) // Hypotension
                    return true;
            }

            if (bio.BloodSugarLevelMgDl.HasValue)
            {
                if (bio.BloodSugarLevelMgDl > 180 || bio.BloodSugarLevelMgDl < 70) // Diabetes risk or hypoglycemia
                    return true;
            }

            if (bio.HeartRateBPM.HasValue && (bio.HeartRateBPM < 50 || bio.HeartRateBPM > 120))
                return true;

            // BMI check (extreme under/overweight)
            var bmi = bio.GetBMI();
            if (bmi < 18.5 || bmi > 35)
                return true;

            return false;
        }


    }
}
