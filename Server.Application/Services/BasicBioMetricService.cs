using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.BasicBioMetric;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.GrowthData;
using Server.Application.DTOs.Journal;
using Server.Application.Interfaces;
using Server.Application.Mappers.BasicBioMetricExtensions;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Services
{
    public class BasicBioMetricService : IBasicBioMetricService
    {
        private readonly IBasicBioMetricRepository _basicBioMetricRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;
        private readonly ICurrentTime _currentTime;
        private readonly ITailoredCheckupReminderService _tailoredCheckupReminderService;
        private readonly INotificationService _notificationService;

        public BasicBioMetricService(IUnitOfWork unitOfWork, IMapper mapper, IBasicBioMetricRepository basicBioMetricRepository,
            IClaimsService claimsService, ICurrentTime currentTime, ITailoredCheckupReminderService tailoredCheckupReminderService, INotificationService notificationService)
        {
            _basicBioMetricRepository = basicBioMetricRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;
            _currentTime = currentTime;
            _tailoredCheckupReminderService = tailoredCheckupReminderService;
            _notificationService = notificationService;
        }
        public async Task<Result<List<ViewBasicBioMetricDTO>>> ViewAllBasicBioMetrics()
        {
            var BBMs = await _unitOfWork.BasicBioMetricRepository.GetAllBasicBioMetrics();

            var result = _mapper.Map<List<ViewBasicBioMetricDTO>>(BBMs);

            return new Result<List<ViewBasicBioMetricDTO>>
            {
                Error = 0,
                Message = "View all BBMs successfully",
                Data = result
            };
        }
        public async Task<Result<ViewBasicBioMetricDTO>> ViewBasicBioMetricById(Guid bbmId)
        {
            var BBM = await _unitOfWork.BasicBioMetricRepository.GetBasicBioMetricById(bbmId);

            // Check if blog exists
            if (BBM == null)
            {
                return new Result<ViewBasicBioMetricDTO>
                {
                    Error = 1,
                    Message = "BBM not found",
                    Data = null
                };
            }

            var result = _mapper.Map<ViewBasicBioMetricDTO>(BBM);

            return new Result<ViewBasicBioMetricDTO>
            {
                Error = 0,
                Message = "View BBM successfully",
                Data = result
            };
        }
        public async Task<Result<object>> CreateBasicBioMetric(CreateBasicBioMetricDTO CreateBasicBioMetricDTO)
        {
            var user = _claimsService.GetCurrentUserId;
            var today = _currentTime.GetCurrentTime().Date;

            var growthData = await _unitOfWork.GrowthDataRepository.GetGrowthDataById(CreateBasicBioMetricDTO.GrowthDataId);
            if (growthData == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Growth data not found.",
                    Data = null
                };
            }
            if (growthData.BasicBioMetric != null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Basic biometric already exists for this growth data.",
                    Data = null
                };
            }
            var bbm = CreateBasicBioMetricDTO.ToBBM();
            bbm.CreatedBy = user;
            bbm.CreationDate = today;

            await _unitOfWork.BasicBioMetricRepository.AddAsync(bbm);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0
                    ? "BBM created successfully."
                    : "Failed to create BBM.",
                Data = null
            };
        }
        public async Task<Result<object>> EditBasicBioMetric(EditBasicBioMetricDTO dto)
        {
            var user = _claimsService.GetCurrentUserId;
            var today = _currentTime.GetCurrentTime().Date;


            var bbm = await _unitOfWork.BasicBioMetricRepository.GetBasicBioMetricById(dto.Id);
            
            if (bbm == null)
            {
                return new Result<object> { Error = 1, Message = "BBM not found." };
            }
            if ((dto.SystolicBP.HasValue && !dto.DiastolicBP.HasValue) ||
            (!dto.SystolicBP.HasValue && dto.DiastolicBP.HasValue))
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "You must provide both Systolic and Diastolic BP values together.",
                    Data = null
                };
            }
            bbm.WeightKg = dto.WeightKg ?? bbm.WeightKg;
            bbm.HeightCm = dto.HeightCm ?? bbm.HeightCm;
            bbm.SystolicBP = dto.SystolicBP;
            bbm.DiastolicBP = dto.DiastolicBP;
            bbm.HeartRateBPM = dto.HeartRateBPM;
            bbm.BloodSugarLevelMgDl = dto.BloodSugarLevelMgDl;
            bbm.Notes = dto.Notes;
            bbm.ModificationBy = user;
            bbm.ModificationDate = today;
            _unitOfWork.BasicBioMetricRepository.Update(bbm);

            var latestJournal = await _unitOfWork.JournalRepository.GetLatestJournalByGrowthDataId(bbm.GrowthDataId);
            if (latestJournal != null)
            {
                latestJournal.CurrentWeight = dto.WeightKg ?? latestJournal.CurrentWeight;
                latestJournal.SystolicBP = dto.SystolicBP;
                latestJournal.DiastolicBP = dto.DiastolicBP;
                latestJournal.HeartRateBPM = dto.HeartRateBPM;
                latestJournal.BloodSugarLevelMgDl = dto.BloodSugarLevelMgDl;
                latestJournal.ModificationBy = user;
                latestJournal.ModificationDate = today;

                _unitOfWork.JournalRepository.Update(latestJournal);
            }

            var result = await _unitOfWork.SaveChangeAsync();

            if (result > 0)
            {
                int? recordedWeek = latestJournal?.CurrentWeek; 
                await _tailoredCheckupReminderService.SendEmergencyBiometricAlert(bbm.Id, recordedWeek);

                var growthData = await _unitOfWork.GrowthDataRepository.GetActiveGrowthDataById(bbm.GrowthDataId);
                var userId = growthData.GrowthDataCreatedBy?.Id;
                var notification = new Notification
                {
                    Id = Guid.NewGuid(),
                    Message = "Your health metrics (BBM) were updated successfully.",
                    CreatedBy = userId,
                    IsSent = true,
                    IsRead = false,
                    CreationDate = _currentTime.GetCurrentTime()
                };
                await _notificationService.CreateNotification(notification, bbm, "BBM");

            }

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "BBM and latest journal updated successfully." : "Failed to update.",
                Data = null
            };
        }

        public async Task<Result<object>> DeleteBasicBioMetric(Guid bbmId)
        {
            var bbm = await _unitOfWork.BasicBioMetricRepository.GetBasicBioMetricById(bbmId);
            if (bbm == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "BBM not found.",
                    Data = null
                };
            }

            _unitOfWork.BasicBioMetricRepository.SoftRemove(bbm);
            var result = await _unitOfWork.SaveChangeAsync();
            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "BBM deleted successfully." : "Failed to delete BBM.",
                Data = null
            };
        }
    }
}
