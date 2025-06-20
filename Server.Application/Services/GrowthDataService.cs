using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.GrowthData;
using Server.Application.Interfaces;
using Server.Application.Mappers.GrowthDataExtentions;
using Server.Application.Repositories;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Services
{
    public class GrowthDataService : IGrowthDataService
    {
        private readonly IGrowthDataRepository _growthDataRepository;
        private readonly ICurrentTime _currentTime;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        

        public GrowthDataService(IUnitOfWork unitOfWork, IMapper mapper, IGrowthDataRepository growthDataRepository, ICurrentTime currentTime)
        {
            _growthDataRepository = growthDataRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentTime = currentTime;
        }

        

        public async Task<Result<List<ViewGrowthDataDTO>>> ViewAllGrowthDatas()
        {
            var growthdatas = await _unitOfWork.GrowthDataRepository.GetAllGrowthData();

            var result = _mapper.Map<List<ViewGrowthDataDTO>>(growthdatas);

            return new Result<List<ViewGrowthDataDTO>>
            {
                Error = 0,
                Message = "View all growthdatas successfully",
                Data = result
            };
        }

        public Task<Result<ViewGrowthDataDTO>> ViewGrowthDataById(Guid growthdataId)
        {
            var growthdata = _unitOfWork.GrowthDataRepository.GetGrowthDataById(growthdataId);
            if (growthdata == null)
            {
                return Task.FromResult(new Result<ViewGrowthDataDTO>
                {
                    Error = 1,
                    Message = "Growth data not found",
                    Data = null
                });
            }
            var result = _mapper.Map<ViewGrowthDataDTO>(growthdata);
            return Task.FromResult(new Result<ViewGrowthDataDTO>
            {
                Error = 0,
                Message = "View growth data by id successfully",
                Data = result
            });
        }
        public async Task<Result<object>> CreateNewGrowthDataProfile(CreateNewGrowthDataProfileDTO createNewGrowthDataProfileDTO)
        {
            // 1. Check if user exists
            var user = await _unitOfWork.UserRepository.GetByIdAsync(createNewGrowthDataProfileDTO.UserId);
            if (user == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not exist!",
                    Data = null
                };
            }

            // 2. Check if user already has a GrowthData profile (optional)
            var existingGrowthData = await _unitOfWork.GrowthDataRepository
                .GetByIdAsync(createNewGrowthDataProfileDTO.UserId); 
            if (existingGrowthData != null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User already has a growth data profile!",
                    Data = null
                };
            }

            // 3. Calculate gestational age and EDD
            var today = _currentTime.GetCurrentTime().Date;
            int gestationalAgeInWeeks = (today - createNewGrowthDataProfileDTO.FirstDayOfLastMenstrualPeriod.Date).Days / 7;
            DateTime estimatedDueDate = createNewGrowthDataProfileDTO.FirstDayOfLastMenstrualPeriod.AddDays(280);

            // 4. Create GrowthData entity
            var growthData = createNewGrowthDataProfileDTO.ToGrowthData();
            growthData.Id = Guid.NewGuid();
            growthData.DateOfPregnancy = today;
            growthData.GestationalAgeInWeeks = gestationalAgeInWeeks;
            growthData.EstimatedDueDate = estimatedDueDate;

            //growthData.GrowthDataCreatedBy = user;
            //growthData.Fetus = new Fetus
            //{
            //    Id = Guid.NewGuid(),
            //    Week = gestationalAgeInWeeks,
            //    Trimester = growthData.CurrentTrimester(),
            //    EstimatedFetalWeight = 0,
            //    EstimatedFetalLength = 0,
            //    DevelopmentMilestones = $"Fetus is approximately {gestationalAgeInWeeks} weeks old",
            //    GrowthData = growthData
            //};

            await _unitOfWork.GrowthDataRepository.AddAsync(growthData);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Growth data profile created successfully." : "Failed to create growth data profile.",
                Data = result > 0 ? new
                {
                    growthData.Id,
                    growthData.GestationalAgeInWeeks,
                    growthData.EstimatedDueDate,
                    growthData.FirstDayOfLastMenstrualPeriod,
                    growthData.Height,
                    growthData.Weight
                } : null
            };
        }
    }
}
