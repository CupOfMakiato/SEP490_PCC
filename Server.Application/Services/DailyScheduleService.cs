using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.DailySchedule;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class DailyScheduleService : IDailyScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDailyScheduleRepository _dailyScheduleRepository;

        public DailyScheduleService(IUnitOfWork unitOfWork, IMapper mapper, IDailyScheduleRepository dailyScheduleRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dailyScheduleRepository = dailyScheduleRepository;
        }

        public async Task<Result<ViewDailyScheduleDTO>> CreateDailySchedule(AddDailyScheduleDTO dailySchedule)
        {
            var existingClinicWorkRule = await _unitOfWork.ClinicWorkRuleRepository.GetByIdAsync(dailySchedule.ClinicWorkRuleId);

            if (existingClinicWorkRule is null)
            {
                return new Result<ViewDailyScheduleDTO>
                {
                    Error = 1,
                    Message = "Clinic work rule not found",
                    Data = null
                };
            }

            var dailyScheduleMapper = _mapper.Map<DailySchedule>(dailySchedule);

            await _dailyScheduleRepository.AddAsync(dailyScheduleMapper);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewDailyScheduleDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Add new daily schedule successfully" : "Add new daily schedule fail",
                Data = _mapper.Map<ViewDailyScheduleDTO>(dailyScheduleMapper)
            };
        }

        public async Task<Result<ViewDailyScheduleDTO>> GetDailyScheduleByIdAsync(Guid dailyScheduleId)
        {
            var dailyScheduleMapper = _mapper.Map<ViewDailyScheduleDTO>(
                await _dailyScheduleRepository.GetByIdAsync(dailyScheduleId));

            return new Result<ViewDailyScheduleDTO>
            {
                Error = dailyScheduleMapper is null ? 1 : 0,
                Message = dailyScheduleMapper is null ? "Schedule not found" : "View schedule successfully",
                Data = dailyScheduleMapper
            };

        }

        public async Task<Result<bool>> SoftDeleteDailySchedule(Guid dailyScheduleId)
        {
            var dailySchedule = await _dailyScheduleRepository.GetByIdAsync(dailyScheduleId);

            if (dailySchedule is null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Daily schedule not found",
                    Data = false
                };
            }

            _dailyScheduleRepository.SoftRemove(dailySchedule);

            var result = _unitOfWork.SaveChangeAsync().Result;
            
            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Soft delete daily schedule successfully" : "Soft delete daily schedule fail",
                Data = result > 0
            };
        }

        public async Task<Result<ViewDailyScheduleDTO>> UpdateDailySchedule(UpdateDailyScheduleDTO DailySchedule)
        {
            var dailyScheduleObj = await _dailyScheduleRepository.GetByIdAsync(DailySchedule.Id);

            if (dailyScheduleObj is null)
            {
                return new Result<ViewDailyScheduleDTO>
                {
                    Error = 1,
                    Message = "Daily schedule not found",
                    Data = null
                };
            }

            _mapper.Map(DailySchedule, dailyScheduleObj);

            _dailyScheduleRepository.Update(dailyScheduleObj);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewDailyScheduleDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Update daily schedule successfully" : "Update daily schedule fail",
                Data = _mapper.Map<ViewDailyScheduleDTO>(dailyScheduleObj)
            };
        }
    }
}
