using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.GrowthData;
using Server.Application.Interfaces;
using Server.Application.Mappers.GrowthDataExtentions;
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
            var currentdate = _currentTime.GetCurrentTime().Date;
            var growthdatas = await _unitOfWork.GrowthDataRepository.GetAllGrowthData();

            var result = _mapper.Map<List<ViewGrowthDataDTO>>(growthdatas);
            for (int i = 0; i < result.Count; i++)
            {
                var entity = growthdatas[i]; 
                var dto = result[i];         

                dto.CurrentGestationalAgeInWeeks = entity.GetCurrentGestationalAgeInWeeks(currentdate);
                dto.CurrentTrimester = entity.GetCurrentTrimester(currentdate);
                dto.GestationalAgeInWeeks = entity.GetGestationalAgeInWeeks();
            }
            return new Result<List<ViewGrowthDataDTO>>
            {
                Error = 0,
                Message = "View all growthdatas successfully",
                Data = result
            };
        }

        public async Task<Result<ViewGrowthDataDTO>> ViewGrowthDataWithCurrentWeek(Guid userId, DateTime currentDate)
        {
            var growth = await _unitOfWork.GrowthDataRepository.GetGrowthDataFromUserWithCurrentWeek(userId, currentDate);

            if (growth == null)
            {
                return new Result<ViewGrowthDataDTO>
                {
                    Error = 1,
                    Message = "Growth data not found",
                    Data = null
                };
            }

            var result = _mapper.Map<ViewGrowthDataDTO>(growth);
            result.CurrentGestationalAgeInWeeks = growth.GetCurrentGestationalAgeInWeeks(currentDate);
            result.CurrentTrimester = growth.GetCurrentTrimester(currentDate);
            result.GestationalAgeInWeeks = growth.GetGestationalAgeInWeeks();

            return new Result<ViewGrowthDataDTO>
            {
                Error = 0,
                Message = "View growth data with current week successfully",
                Data = result
            };
        }

        public async Task<Result<ViewGrowthDataDTO>> ViewGrowthDataById(Guid growthdataId)
        {
            var currentDate = _currentTime.GetCurrentTime().Date;
            var growthData = await _unitOfWork.GrowthDataRepository.GetGrowthDataById(growthdataId);

            if (growthData == null)
            {
                return new Result<ViewGrowthDataDTO>
                {
                    Error = 1,
                    Message = "Growth data not found",
                    Data = null
                };
            }

            var result = _mapper.Map<ViewGrowthDataDTO>(growthData);

            result.CurrentGestationalAgeInWeeks = growthData.GetCurrentGestationalAgeInWeeks(currentDate);
            result.CurrentTrimester = growthData.GetCurrentTrimester(currentDate);
            result.GestationalAgeInWeeks = growthData.GetGestationalAgeInWeeks();

            return new Result<ViewGrowthDataDTO>
            {
                Error = 0,
                Message = "View growth data by id successfully",
                Data = result
            };
        }
        public async Task<Result<ViewGrowthDataDTO>> ViewGrowthDataByUserId(Guid userId)
        {
            var currentDate = _currentTime.GetCurrentTime().Date;
            var growthData = await _unitOfWork.GrowthDataRepository.GetActiveGrowthDataByUserId(userId);

            if (growthData == null)
            {
                return new Result<ViewGrowthDataDTO>
                {
                    Error = 1,
                    Message = "Growth data not found",
                    Data = null
                };
            }

            var result = _mapper.Map<ViewGrowthDataDTO>(growthData);

            result.CurrentGestationalAgeInWeeks = growthData.GetCurrentGestationalAgeInWeeks(currentDate);
            result.CurrentTrimester = growthData.GetCurrentTrimester(currentDate);
            result.GestationalAgeInWeeks = growthData.GetGestationalAgeInWeeks();

            return new Result<ViewGrowthDataDTO>
            {
                Error = 0,
                Message = "View growth data by user id successfully",
                Data = result
            };
        }

        // only create new when profile Inactive
        public async Task<Result<object>> CreateNewGrowthDataProfile(CreateNewGrowthDataProfileDTO CreateNewGrowthDataProfileDTO)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(CreateNewGrowthDataProfileDTO.UserId);
            if (user == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not exist!",
                    Data = null
                };
            }

            var today = _currentTime.GetCurrentTime().Date;

            // Check for existing active profile that is not due yet
            var activeProfile = await _unitOfWork.GrowthDataRepository.GetGrowthDataFromUserWithCurrentWeek(CreateNewGrowthDataProfileDTO.UserId, today);
            if (activeProfile != null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "You already have an active pregnancy profile that has not yet reached its due date.",
                    Data = null
                };
            }

            // Create new GrowthData
            var estimatedDueDate = CreateNewGrowthDataProfileDTO.FirstDayOfLastMenstrualPeriod.AddDays(280);

            var growthData = CreateNewGrowthDataProfileDTO.ToGrowthData(_currentTime);
            growthData.Id = Guid.NewGuid();
            growthData.PreWeight = CreateNewGrowthDataProfileDTO.PreWeight ?? growthData.PreWeight;
            growthData.FirstDayOfLastMenstrualPeriod = CreateNewGrowthDataProfileDTO.FirstDayOfLastMenstrualPeriod;
            growthData.EstimatedDueDate = estimatedDueDate;
            growthData.GestationalAgeInWeeks = 40;
            growthData.Status = GrowthDataStatus.Active;

            await _unitOfWork.GrowthDataRepository.AddAsync(growthData);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0
                    ? "Growth data profile created successfully."
                    : "Failed to create growth data profile.",
                Data = null
            };
        }

        public async Task<Result<object>> EditGrowthDataProfile(EditGrowthDataProfileDTO EditGrowthDataProfileDTO)
        {
            var growthData = await _unitOfWork.GrowthDataRepository.GetActiveGrowthDataById(EditGrowthDataProfileDTO.Id);
            if (growthData == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Growth data profile not found",
                    Data = null
                };
            }

            var today = _currentTime.GetCurrentTime().Date;
            growthData.FirstDayOfLastMenstrualPeriod = EditGrowthDataProfileDTO.FirstDayOfLastMenstrualPeriod ?? growthData.FirstDayOfLastMenstrualPeriod;
            growthData.EstimatedDueDate = EditGrowthDataProfileDTO.EstimatedDueDate ?? growthData.EstimatedDueDate;
            growthData.PreWeight = EditGrowthDataProfileDTO.PreWeight ?? growthData.PreWeight;

            // If LMP has changed then recalculate EDD and gestational age
            if (EditGrowthDataProfileDTO.FirstDayOfLastMenstrualPeriod.HasValue &&
                EditGrowthDataProfileDTO.FirstDayOfLastMenstrualPeriod.Value != growthData.FirstDayOfLastMenstrualPeriod)
            {
                growthData.FirstDayOfLastMenstrualPeriod = EditGrowthDataProfileDTO.FirstDayOfLastMenstrualPeriod.Value;
                growthData.EstimatedDueDate = growthData.FirstDayOfLastMenstrualPeriod.AddDays(280);
                growthData.GestationalAgeInWeeks = growthData.GetCurrentGestationalAgeInWeeks(today);
            }
            // If EDD was changed directly (LMP stayed the same)
            else if (EditGrowthDataProfileDTO.EstimatedDueDate.HasValue &&
                     EditGrowthDataProfileDTO.EstimatedDueDate.Value != growthData.EstimatedDueDate)
            {
                growthData.EstimatedDueDate = EditGrowthDataProfileDTO.EstimatedDueDate.Value;
                growthData.GestationalAgeInWeeks = growthData.GetCurrentGestationalAgeInWeeks(today);
            }

            //growthData.Status = growthData.EstimatedDueDate < today
            //    ? GrowthDataStatus.Inactive
            //    : GrowthDataStatus.Active;


            _unitOfWork.GrowthDataRepository.Update(growthData);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Growth data profile updated successfully." : "Failed to update.",
                Data = null
            };
        }
        public async Task<Result<object>> DeleteGrowthData(Guid growthDataId)
        {
            var existingData = await _unitOfWork.GrowthDataRepository.GetGrowthDataById(growthDataId);
            if (existingData == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "GrowthData not found",
                    Data = null
                };
            }

            _unitOfWork.GrowthDataRepository.SoftRemove(existingData);

            // Save the changes
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "GrowthData deleted successfully" : "Failed to delete GrowthData",
                Data = null
            };
        }

    }
}
