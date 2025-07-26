using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.CustomChecklist;
using Server.Application.DTOs.TailoredCheckupReminder;
using Server.Application.DTOs.UserChecklist;
using Server.Application.Interfaces;
using Server.Application.Mappers.CheckupReminderExtensions;
using Server.Application.Repositories;
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
        public TailoredCheckupReminderService(
            ITailoredCheckupReminderRepository tailoredCheckupReminderRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ICurrentTime currentTime,
            IClaimsService claimsService)
        {
            _tailoredCheckupReminderRepository = tailoredCheckupReminderRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _currentTime = currentTime;
            _claimsService = claimsService;
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
            reminder.CreationDate = DateTime.UtcNow;

            await _unitOfWork.TailoredCheckupReminderRepository.AddAsync(reminder);
            var result = await _unitOfWork.SaveChangeAsync();
            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Add new reminder successfully" : "Add new reminder fail",
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
            reminder.ModificationBy = user;
            reminder.ModificationDate = DateTime.Now;
            _tailoredCheckupReminderRepository.Update(reminder);
            var result = await _unitOfWork.SaveChangeAsync();
            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Edit reminder successfully" : "Edit reminder fail",
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
            reminder.CompletedDate = DateTime.Now;
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
        // w.i.p
        // will write hangfire background job for reminder and send email maybe (my brain is not working right now)
    }
}
