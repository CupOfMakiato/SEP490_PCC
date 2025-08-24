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
                var abnormalDetails = GetAbnormalitiesSummary(bio);

                if (abnormalDetails.Any())
                {
                    var email = bio.GrowthData?.GrowthDataCreatedBy?.Email;
                    if (string.IsNullOrEmpty(email))
                    {
                        _logger.LogWarning($"Biometric {bio.Id}: email is null or empty.");
                        continue;
                    }

                    // Build a combined message
                    var subject = "Emergency Biometric Alert";
                    var message = "We detected the following abnormal readings:\n" +
                                  string.Join("\n", abnormalDetails);

                    var reminder = new TailoredCheckupReminder
                    {
                        Id = Guid.NewGuid(),
                        GrowthDataId = bio.GrowthDataId,
                        Title = subject,
                        Description = message,
                        CheckupStatus = CheckupStatus.NotScheduled,
                        Type = CheckupType.Emergency,
                        CreatedBy = bio.GrowthData?.CreatedBy,
                        CreationDate = _currentTime.GetCurrentTime(),
                        IsActive = true
                    };

                    await _unitOfWork.TailoredCheckupReminderRepository.AddAsync(reminder);
                    await _unitOfWork.SaveChangeAsync();

                    await _emailService.SendEmergencyBiometricAlert(
                        email,
                        subject,
                        message
                    );

                    _logger.LogInformation(
                        $"[Hangfire] Created combined emergency reminder & sent email to {email} for biometric ID: {bio.Id}, reminder ID: {reminder.Id}"
                    );
                }
            }
        }

        // what is abnormal readings, ref at diag lab
        private List<string> GetAbnormalitiesSummary(BasicBioMetric bio)
        {
            var issues = new List<string>();

            // --- Blood Pressure ---
            if (bio.SystolicBP.HasValue && bio.DiastolicBP.HasValue)
            {
                var sys = bio.SystolicBP.Value;
                var dia = bio.DiastolicBP.Value;

                if (sys >= 180 || dia >= 120)
                    issues.Add($"Blood Pressure {sys}/{dia} mmHg which is Hypertensive Crisis (Seek emergency care)");
                else if (sys >= 160 || dia >= 100)
                    issues.Add($"Blood Pressure {sys}/{dia} mmHg which is Hypertension Stage 2");
                else if (sys >= 140 || dia >= 90)
                    issues.Add($"Blood Pressure {sys}/{dia} mmHg which is Hypertension Stage 1");
                else if (sys < 90 || dia < 60)
                    issues.Add($"Blood Pressure {sys}/{dia} mmHg which is Hypotension (Low Blood Pressure)");
            }

            // --- Blood Sugar (Gestational Diabetes references, fasting only) ---
            if (bio.BloodSugarLevelMgDl.HasValue)
            {
                var sugar = bio.BloodSugarLevelMgDl.Value;

                // Always treat as fasting
                if (sugar > 95)
                    issues.Add($"Blood Sugar {sugar} mg/dL (when fasting) which is above pregnancy safe range (over 95 mg/dL) predicting a possible gestational diabetes");
                else if (sugar < 70)
                    issues.Add($"Blood Sugar {sugar} mg/dL (when fasting) which is Hypoglycemia risk");
            }

            // --- Heart Rate ---
            if (bio.HeartRateBPM.HasValue)
            {
                var hr = bio.HeartRateBPM.Value;
                if (hr > 120)
                    issues.Add($"Heart Rate {hr} bpm which is Tachycardia (High Heart Rate)");
                else if (hr < 50)
                    issues.Add($"Heart Rate {hr} bpm which is Bradycardia (Low Heart Rate)");
            }

            // --- BMI ---
            try
            {
                var bmi = bio.GetBMI();
                if (bmi < 18.5f)
                    issues.Add($"BMI {bmi:F1} which is Underweight");
                else if (bmi > 35f)
                    issues.Add($"BMI {bmi:F1} which is Obese");
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "BMI calculation failed for BasicBioMetric ID {BiometricId}", bio.Id);
            }

            return issues;
        }

        private static DateTime _lastCheckTime = DateTime.UtcNow.AddMinutes(-5);

        public async Task RunEmergencyBiometricJob()
        {
            await SendEmergencyBiometricAlert(_lastCheckTime);
            _lastCheckTime = DateTime.UtcNow;
        }



    }
}
