using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.CustomChecklist;
using Server.Application.DTOs.Journal;
using Server.Application.DTOs.TailoredCheckupReminder;
using Server.Application.DTOs.UserChecklist;
using Server.Application.Interfaces;
using Server.Application.Mappers.CheckupReminderExtensions;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Services
{
    public class TailoredCheckupReminderService : ITailoredCheckupReminderService
    {
        private readonly ITailoredCheckupReminderRepository _tailoredCheckupReminderRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentTime _currentTime;
        private readonly IClaimsService _claimsService;
        private readonly IEmailService _emailService;
        private readonly INotificationService _notificationService;
        private readonly ILogger<TailoredCheckupReminderService> _logger;
        public TailoredCheckupReminderService(
            ITailoredCheckupReminderRepository tailoredCheckupReminderRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ICurrentTime currentTime,
            IClaimsService claimsService,
            IEmailService emailService,
            INotificationService notificationService)
        {
            _tailoredCheckupReminderRepository = tailoredCheckupReminderRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _currentTime = currentTime;
            _claimsService = claimsService;
            _emailService = emailService;
            _notificationService = notificationService;
        }
        public async Task<Result<List<ViewTailoredCheckupReminderDTO>>> ViewAllReminders()
        {
            var reminders = await _tailoredCheckupReminderRepository.GetAllTailoredCheckupReminders();
            var result = _mapper.Map<List<ViewTailoredCheckupReminderDTO>>(reminders);
            return new Result<List<ViewTailoredCheckupReminderDTO>>
            {
                Error = 0,
                Message = "Retrieved all reminders successfully",
                Data = result
            };
        }
        public async Task<Result<ViewTailoredCheckupReminderDTO>> ViewCustomChecklistById(Guid id)
        {
            var reminder = await _tailoredCheckupReminderRepository.GetTailoredCheckupReminderById(id);
            if (reminder == null)
            {
                return new Result<ViewTailoredCheckupReminderDTO>
                {
                    Error = 1,
                    Message = "Reminder not found",
                    Data = null
                };
            }

            return new Result<ViewTailoredCheckupReminderDTO>
            {
                Error = 0,
                Message = "Reminder retrieved successfully",
                Data = _mapper.Map<ViewTailoredCheckupReminderDTO>(reminder)
            };
        }
        public async Task<Result<List<ViewTailoredCheckupReminderDTO>>> ViewRemindersByGrowthData(Guid growthDataId)
        {
            var reminders = await _tailoredCheckupReminderRepository.GetAllTailoredCheckupRemindersByGrowthData(growthDataId);
            var result = _mapper.Map<List<ViewTailoredCheckupReminderDTO>>(reminders);
            return new Result<List<ViewTailoredCheckupReminderDTO>>
            {
                Error = 0,
                Message = "Retrieved all reminders by growthdata successfully",
                Data = result
            };
        }

        public async Task<Result<List<ViewTailoredCheckupReminderDTO>>> ViewUpcomingRemindersByGrowthData(Guid growthDataId)
        {
            var currentDate = _currentTime.GetCurrentTime();
            var reminders = await _tailoredCheckupReminderRepository.GetUpcomingRemindersByGrowthData(growthDataId, currentDate);
            var result = _mapper.Map<List<ViewTailoredCheckupReminderDTO>>(reminders);
            return new Result<List<ViewTailoredCheckupReminderDTO>>
            {
                Error = 0,
                Message = "Retrieved all upcoming reminders successfully",
                Data = result
            };
        }

        public async Task<Result<List<ViewTailoredCheckupReminderDTO>>> ViewOverdueRemindersByGrowthData(Guid growthDataId)
        {
            var currentDate = _currentTime.GetCurrentTime();
            var reminders = await _tailoredCheckupReminderRepository.GetOverdueRemindersByGrowthData(growthDataId, currentDate);
            var result = _mapper.Map<List<ViewTailoredCheckupReminderDTO>>(reminders);
            return new Result<List<ViewTailoredCheckupReminderDTO>>
            {
                Error = 0,
                Message = "Retrieved all overdued reminders successfully",
                Data = result
            };
        }

        public async Task<Result<List<ViewTailoredCheckupReminderDTO>>> ViewCompletedRemindersByGrowthData(Guid growthDataId)
        {
            var currentDate = _currentTime.GetCurrentTime();
            var reminders = await _tailoredCheckupReminderRepository.GetCompletedRemindersByGrowthData(growthDataId, currentDate);
            var result = _mapper.Map<List<ViewTailoredCheckupReminderDTO>>(reminders);
            return new Result<List<ViewTailoredCheckupReminderDTO>>
            {
                Error = 0,
                Message = "Retrieved all completed reminders successfully",
                Data = result
            };
        }

        public async Task<Result<List<ViewTailoredCheckupReminderDTO>>> ViewRemindersByTrimester(Guid growthDataId, int trimester)
        {
            var reminders = await _tailoredCheckupReminderRepository.GetRemindersByTrimester(growthDataId, trimester);
            var result = _mapper.Map<List<ViewTailoredCheckupReminderDTO>>(reminders);
            return new Result<List<ViewTailoredCheckupReminderDTO>>
            {
                Error = 0,
                Message = "Retrieved all reminders by trimester successfully",
                Data = result
            };
        }
        public async Task<Result<object>> CreateNewTailoredCheckupReminder(CreateTailoredCheckupReminderDTO CreateTailoredCheckupReminderDTO)
        {
            var user = _claimsService.GetCurrentUserId;
            if (user == null || user == Guid.Empty)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not found!",
                    Data = null
                };
            }
            var reminder = CreateTailoredCheckupReminderDTO.ToTailoredReminder();

            reminder.CreatedBy = user;
            reminder.CreationDate = DateTime.UtcNow.Date;

            await _unitOfWork.TailoredCheckupReminderRepository.AddAsync(reminder);
            var result = await _unitOfWork.SaveChangeAsync();
            if (result > 0)
            {
                var growthdata = await _unitOfWork.GrowthDataRepository.GetGrowthDataById(reminder.GrowthDataId);
                if (growthdata != null && !string.IsNullOrEmpty(growthdata.GrowthDataCreatedBy?.Email))
                {
                    await _emailService.SendNewlyCreatedCheckupReminder(growthdata.GrowthDataCreatedBy.Email);
                }

                return new Result<object>
                {
                    Error = 0,
                    Message = "Added new checkup reminder successfully",
                    Data = null
                };
            }

            return new Result<object>
            {
                Error = 1,
                Message = "Failed to add checkup reminder",
                Data = null
            };
        }
        // this is for consultant screen first
        public async Task<Result<object>> EditTailoredCheckupReminder(EditTailoredCheckupReminderDTO EditTailoredCheckupReminderDTO)
        {
            var user = _claimsService.GetCurrentUserId;
            if (user == null || user == Guid.Empty)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not found!",
                    Data = null
                };
            }
            var reminder = await _tailoredCheckupReminderRepository.GetTailoredCheckupReminderById(EditTailoredCheckupReminderDTO.Id);
            if (reminder == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Reminder not found",
                    Data = null
                };
            }
            reminder.Title = EditTailoredCheckupReminderDTO.Title ?? reminder.Title;
            reminder.Description = EditTailoredCheckupReminderDTO.Description ?? reminder.Description;
            reminder.RecommendedStartWeek = EditTailoredCheckupReminderDTO.RecommendedStartWeek ?? reminder.RecommendedStartWeek;
            reminder.RecommendedEndWeek = EditTailoredCheckupReminderDTO.RecommendedEndWeek ?? reminder.RecommendedEndWeek;
            reminder.ScheduledDate = EditTailoredCheckupReminderDTO.ScheduledDate ?? reminder.ScheduledDate;
            reminder.CompletedDate = EditTailoredCheckupReminderDTO.CompletedDate ?? reminder.CompletedDate;
            reminder.CheckupStatus = EditTailoredCheckupReminderDTO.CheckupStatus ?? reminder.CheckupStatus;
            reminder.Type = EditTailoredCheckupReminderDTO.Type ?? reminder.Type;
            reminder.ModificationBy = user;
            reminder.ModificationDate = DateTime.UtcNow;
            _tailoredCheckupReminderRepository.Update(reminder);
            var result = await _unitOfWork.SaveChangeAsync();
            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Edit reminder successfully" : "Edit reminder fail",
                Data = null
            };
        }
        public async Task<Result<object>> MarkReminderAsScheduled(Guid ReminderId)
        {
            var userId = _claimsService.GetCurrentUserId;
            if (userId == null || userId == Guid.Empty)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User not found!",
                    Data = null
                };
            }

            var reminder = await _unitOfWork.TailoredCheckupReminderRepository.GetTailoredCheckupReminderById(ReminderId);
            if (reminder == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Reminder not found!",
                    Data = null
                };
            }

            if (reminder.CheckupStatus == CheckupStatus.Scheduled)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Reminder is already marked as scheduled.",
                    Data = null
                };
            }

            reminder.CheckupStatus = CheckupStatus.Scheduled;
            reminder.ScheduledDate = _currentTime.GetCurrentTime();
            reminder.ModificationDate = _currentTime.GetCurrentTime();
            reminder.ModificationBy = userId;

            _unitOfWork.TailoredCheckupReminderRepository.Update(reminder);
            await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = 0,
                Message = "Reminder marked as scheduled successfully.",
                Data = null
            };
        }
        public async Task<Result<object>> MarkReminderAsComplete(Guid ReminderId)
        {
            var userId = _claimsService.GetCurrentUserId;
            if (userId == null || userId == Guid.Empty)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User not found!",
                    Data = null
                };
            }

            var reminder = await _unitOfWork.TailoredCheckupReminderRepository.GetTailoredCheckupReminderById(ReminderId);
            if (reminder == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Reminder not found!",
                    Data = null
                };
            }

            if (reminder.CheckupStatus == CheckupStatus.Completed)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Reminder is already marked as completed.",
                    Data = null
                };
            }

            reminder.CheckupStatus = CheckupStatus.Completed;
            reminder.CompletedDate = DateTime.UtcNow;
            reminder.ModificationDate = _currentTime.GetCurrentTime();
            reminder.ModificationBy = userId;

            _unitOfWork.TailoredCheckupReminderRepository.Update(reminder);
            await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = 0,
                Message = "Reminder marked as completed successfully.",
                Data = null
            };
        }
        public async Task<Result<object>> DeleteReminder(Guid ReminderId)
        {
            var userId = _claimsService.GetCurrentUserId;
            if (userId == null || userId == Guid.Empty)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not found!",
                    Data = null
                };
            }
            var reminder = await _unitOfWork.TailoredCheckupReminderRepository.GetTailoredCheckupReminderById(ReminderId);
            if (reminder == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Reminder not found!",
                    Data = null
                };
            }
            _unitOfWork.TailoredCheckupReminderRepository.SoftRemove(reminder);
            var result = await _unitOfWork.SaveChangeAsync();
            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Delete reminder successfully" : "Failed to delete reminder",
                Data = null
            };
        }
        public async Task SendEmergencyBiometricAlert(Guid biometricId, int? recordedWeek = null)
        {
            var bio = await _unitOfWork.BasicBioMetricRepository.GetBasicBioMetricById(biometricId);
            if (bio == null) return;

            var abnormalDetails = GetAbnormalitiesSummary(bio);
            if (!abnormalDetails.Any()) return;

            var email = bio.GrowthData?.GrowthDataCreatedBy?.Email;
            if (string.IsNullOrEmpty(email))
            {
                _logger.LogWarning($"Biometric {bio.Id}: email is null or empty.");
                return;
            }

            // Calculate gestational week
            var lmpDate = bio.GrowthData?.FirstDayOfLastMenstrualPeriod;
            var currentDate = _currentTime.GetCurrentTime().Date;
            int currentWeek = lmpDate.HasValue
                ? (int)((currentDate - lmpDate.Value).TotalDays / 7) + 1
                : 0;

            // Choose reminder week
            int reminderWeek = recordedWeek.HasValue && recordedWeek.Value > 0
                ? recordedWeek.Value
                : currentWeek;

            // Build email content
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
                CreationDate = currentDate,
                IsActive = true,

                RecommendedStartWeek = reminderWeek,
                RecommendedEndWeek = reminderWeek + 1
            };

            await _unitOfWork.TailoredCheckupReminderRepository.AddAsync(reminder);
            await _unitOfWork.SaveChangeAsync();

            await _emailService.SendEmergencyBiometricAlert(email, subject, message);
            var notification = new Notification
            {
                Id = Guid.NewGuid(),
                Message = $"System detected abnormal readings please check your email for detailed information!",
                CreatedBy = bio.GrowthData?.CreatedBy,
                IsSent = true,
                IsRead = false,
                CreationDate = DateTime.UtcNow.Date
            };

            await _notificationService.CreateNotification(notification, reminder, "TailoredCheckupReminder");

            //_logger.LogInformation(
            //    $"Created emergency reminder (Weeks {reminder.RecommendedStartWeek}-{reminder.RecommendedEndWeek}) " +
            //    $"& sent email to {email} for biometric ID: {bio.Id}, reminder ID: {reminder.Id}"
            //);
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
    }
}
