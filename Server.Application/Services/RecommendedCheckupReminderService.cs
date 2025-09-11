using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.RecommendedCheckupReminder;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Services
{
    public class RecommendedCheckupReminderService : IRecommendedCheckupReminderService
    {
        private readonly IRecommendedCheckupReminderRepository _recommendedCheckupReminderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;
        public RecommendedCheckupReminderService(
        IRecommendedCheckupReminderRepository recommendedCheckupReminderRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IClaimsService claimsService)
        {
            _recommendedCheckupReminderRepository = recommendedCheckupReminderRepository; // Correct assignment
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;
        }

        private ViewRecommendedCheckupReminderDTO MapReminderDTO(RecommendedCheckup reminder, Guid growthDataId)
        {
            var link = reminder.RecommendedCheckupGrowthDatas
                .FirstOrDefault(x => x.GrowthDataId == growthDataId);

            return new ViewRecommendedCheckupReminderDTO
            {
                Id = reminder.Id,
                GrowthDataId = growthDataId,
                Title = reminder.Title,
                Description = reminder.Description,
                Note = reminder.Note,
                Type = reminder.Type,
                RecommendedStartWeek = reminder.RecommendedStartWeek,
                RecommendedEndWeek = reminder.RecommendedEndWeek,
                ScheduledDate = link?.ScheduledDate,
                IsCompleted = link?.IsCompleted ?? false,
                CompletedDate = link?.CompletedDate,
                IsActive = reminder.IsActive
            };
        }

        public async Task<Result<List<ViewRecommendedCheckupReminderDTO>>> ViewAllReminders(Guid growthDataId)
        {
            var reminders = await _recommendedCheckupReminderRepository.GetAllActiveRecommendedCheckups();

            var result = reminders
                .Select(c => MapReminderDTO(c, growthDataId))
                .ToList();

            return new Result<List<ViewRecommendedCheckupReminderDTO>>
            {
                Error = 0,
                Message = "Retrieved recommended checkup reminders successfully",
                Data = result
            };
        }
        public async Task<Result<ViewRecommendedCheckupReminderDTO>> LinkCheckupToGrowthData(
        Guid checkupId,
        Guid growthDataId,
        DateTime? scheduledDate = null)
        {
            var checkup = await _recommendedCheckupReminderRepository.GetRecommendedCheckupById(checkupId);
            if (checkup == null)
            {
                return new Result<ViewRecommendedCheckupReminderDTO>
                {
                    Error = 1,
                    Message = $"Checkup {checkupId} not found.",
                    Data = null
                };
            }

            var existingLink = checkup.RecommendedCheckupGrowthDatas
                .FirstOrDefault(x => x.GrowthDataId == growthDataId);

            if (existingLink != null)
            {
                return new Result<ViewRecommendedCheckupReminderDTO>
                {
                    Error = 1,
                    Message = "This GrowthData is already linked to the Checkup.",
                    Data = MapReminderDTO(checkup, growthDataId)
                };
            }

            var newLink = new RecommendedCheckupGrowthData
            {
                GrowthDataId = growthDataId,
                RecommendedCheckupId = checkupId,
                ScheduledDate = scheduledDate,
                IsCompleted = false,
                CompletedDate = null
            };

            checkup.RecommendedCheckupGrowthDatas.Add(newLink);

            _recommendedCheckupReminderRepository.Update(checkup);
            await _unitOfWork.SaveChangeAsync();

            return new Result<ViewRecommendedCheckupReminderDTO>
            {
                Error = 0,
                Message = "Checkup successfully linked to GrowthData.",
                Data = MapReminderDTO(checkup, growthDataId)
            };
        }

        public async Task LinkAllCheckupsToGrowthData(Guid growthDataId)
        {

            // Get all system-defined active recommended checkups
            var allCheckups = await _recommendedCheckupReminderRepository.GetAllActiveRecommendedCheckups();

            foreach (var checkup in allCheckups)
            {
                // Initialize collection if null
                if (checkup.RecommendedCheckupGrowthDatas == null)
                {
                    checkup.RecommendedCheckupGrowthDatas = new List<RecommendedCheckupGrowthData>();
                }

                var alreadyLinked = checkup.RecommendedCheckupGrowthDatas
                    .Any(x => x.GrowthDataId == growthDataId);

                if (!alreadyLinked)
                {
                    var newLink = new RecommendedCheckupGrowthData
                    {
                        GrowthDataId = growthDataId,
                        RecommendedCheckupId = checkup.Id,
                        ScheduledDate = DateTime.Now.Date,
                        IsCompleted = false,
                        CompletedDate = null
                    };

                    checkup.RecommendedCheckupGrowthDatas.Add(newLink);
                    _recommendedCheckupReminderRepository.Update(checkup);
                }
            
            }

            await _unitOfWork.SaveChangeAsync();
        }


    }
}