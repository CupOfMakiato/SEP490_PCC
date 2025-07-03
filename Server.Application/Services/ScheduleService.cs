using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Schedule;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IUnitOfWork unitOfWork, IMapper mapper, IScheduleRepository scheduleRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<Result<ViewScheduleDTO>> CreateSchedule(AddScheduleDTO schedule)
        {
            var existingConsultant = await _unitOfWork.ConsultantRepository.GetByIdAsync(schedule.ConsultantId);

            if (existingConsultant is null)
            {
                return new Result<ViewScheduleDTO>
                {
                    Error = 1,
                    Message = "Consultant not found",
                    Data = null
                };
            }

            var scheduleMapper = _mapper.Map<Schedule>(schedule);

            await _unitOfWork.ScheduleRepository.AddAsync(scheduleMapper);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewScheduleDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Add new schedule successfully" : "Add new schedule fail",
                Data = _mapper.Map<ViewScheduleDTO>(scheduleMapper)
            };
        }

        public async Task<Result<List<ViewScheduleDTO>>> GetSchedulesAsync(Guid consultantId)
        {
            var scheduleMapper = _mapper.Map<List<ViewScheduleDTO>>(await _scheduleRepository.GetSchedulesAsync(consultantId));

            return new Result<List<ViewScheduleDTO>>
            {
                Error = 0,
                Message = "View schedules successfully",
                Data = scheduleMapper
            };
        }

        public async Task<Result<bool>> SoftDeleteSchedule(Guid scheduleId)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(scheduleId);

            if (schedule is null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Schedule not found",
                    Data = false
                };
            }

            _scheduleRepository.SoftRemove(schedule);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Delete schedule successfully" : "Delete schedule failed",
                Data = result > 0
            };
        }

        public async Task<Result<ViewScheduleDTO>> UpdateSchedule(UpdateScheduleDTO schedule)
        {
            var scheduleObj = await _scheduleRepository.GetByIdAsync(schedule.Id);

            if (scheduleObj is null)
            {
                return new Result<ViewScheduleDTO>
                {
                    Error = 1,
                    Message = "Schedule not found",
                    Data = null
                };
            }

            _mapper.Map(schedule, scheduleObj);

            _scheduleRepository.Update(scheduleObj);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewScheduleDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Update schedule successfully" : "Update schedule failed",
                Data = _mapper.Map<ViewScheduleDTO>(scheduleObj)
            };
        }
    }
}
