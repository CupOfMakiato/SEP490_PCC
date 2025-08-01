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
            var consultant = await _unitOfWork.ConsultantRepository
                .GetConsultantByIdAsync(schedule.ConsultantId);

            if (consultant == null)
            {
                return new Result<ViewScheduleDTO>
                {
                    Error = 1,
                    Message = "Didn't find any consultant, please try again!",
                    Data = null
                };
            }

            var clinic = await _unitOfWork.ClinicRepository
                .GetClinicByIdAsync(consultant.ClinicId);

            if (clinic == null)
            {
                return new Result<ViewScheduleDTO>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = null
                };
            }

            if (!clinic.IsActive)
            {
                return new Result<ViewScheduleDTO>
                {
                    Error = 1,
                    Message = "Clinic is not active, cannot create schedule.",
                    Data = null
                };
            }

            //var overlappingSlotExists = await _unitOfWork.ConsultantRepository.HasOverlappingScheduleAsync
            //                            (
            //                                schedule.ConsultantId,
            //                                schedule.Slot.StartTime,
            //                                schedule.Slot.EndTime,
            //                                schedule.Slot.DayOfWeek
            //                            );

            //if (overlappingSlotExists)
            //{
            //    return new Result<ViewScheduleDTO>
            //    {
            //        Error = 1,
            //        Message = "The schedule overlaps with an existing schedule.",
            //        Data = null
            //    };
            //}

            var slotEntity = _mapper.Map<Slot>(schedule.Slot);

            slotEntity.IsAvailable = true;

            await _unitOfWork.SlotRepository.AddAsync(slotEntity);

            var slotSaveResult = await _unitOfWork.SaveChangeAsync();

            if (slotSaveResult <= 0)
            {
                return new Result<ViewScheduleDTO>
                {
                    Error = 1,
                    Message = "Failed to create slot.",
                    Data = null
                };
            }

            var scheduleEntity = new Schedule
            {
                SlotId = slotEntity.Id,
                //ConsultantId = schedule.ConsultantId
            };
            await _scheduleRepository.AddAsync(scheduleEntity);

            var scheduleSaveResult = await _unitOfWork.SaveChangeAsync();

            if (scheduleSaveResult <= 0)
            {
                return new Result<ViewScheduleDTO>
                {
                    Error = 1,
                    Message = "Failed to create schedule.",
                    Data = null
                };
            }

            return new Result<ViewScheduleDTO>
            {
                Error = 0,
                Message = "Schedule and slot created successfully.",
                Data = _mapper.Map<ViewScheduleDTO>(scheduleEntity)
            };
        }

        public async Task<Result<ViewScheduleDTO>> GetScheduleById(Guid scheduleId)
        {
            var result = _mapper.Map<ViewScheduleDTO>
                (await _scheduleRepository.GetScheduleByIdAsync(scheduleId));

            return new Result<ViewScheduleDTO>
            {
                Error = 0,
                Message = "View schedule successfully",
                Data = result
            };
        }

        public async Task<Result<bool>> SoftDeleteSchedule(Guid scheduleId)
        {
            var schedule = await _scheduleRepository.GetScheduleByIdAsync(scheduleId);

            if (schedule == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any schedule, please try again!",
                    Data = false
                };
            }

            //var consultant = await _unitOfWork.ConsultantRepository
            //    .GetConsultantByIdAsync(schedule.ConsultantId.Value);

            //if (consultant == null)
            //{
            //    return new Result<bool>
            //    {
            //        Error = 1,
            //        Message = "Didn't find any consultant, please try again!",
            //        Data = false
            //    };
            //}

            //var clinic = await _unitOfWork.ClinicRepository
            //    .GetClinicByIdAsync(consultant.ClinicId);

            //if (clinic == null)
            //{
            //    return new Result<bool>
            //    {
            //        Error = 1,
            //        Message = "Didn't find any clinic, please try again!",
            //        Data = false
            //    };
            //}

            //if (!clinic.IsActive)
            //{
            //    return new Result<bool>
            //    {
            //        Error = 1,
            //        Message = "Clinic is not active, cannot remove schedule.",
            //        Data = false
            //    };
            //}

            _unitOfWork.SlotRepository.SoftRemove(schedule.Slot);

            _scheduleRepository.SoftRemove(schedule);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Remove schedule successfully" : "Remove schedule fail",
                Data = result > 0
            };
        }

        public async Task<Result<ViewScheduleDTO>> UpdateSchedule(UpdateScheduleDTO schedule)
        {
            var scheduleObj = await _scheduleRepository.GetScheduleByIdAsync(schedule.Id);

            if (scheduleObj is null)
            {
                return new Result<ViewScheduleDTO>
                {
                    Error = 1,
                    Message = "Didn't find any schedule, please try again!",
                    Data = null
                };
            }

            //var consultant = await _unitOfWork.ConsultantRepository
            //    .GetConsultantByIdAsync(scheduleObj.ConsultantId.Value);

            //if (consultant == null)
            //{
            //    return new Result<ViewScheduleDTO>
            //    {
            //        Error = 1,
            //        Message = "Didn't find any consultant, please try again!",
            //        Data = null
            //    };
            //}

            //var clinic = await _unitOfWork.ClinicRepository
            //    .GetClinicByIdAsync(consultant.ClinicId);

            //if (clinic == null)
            //{
            //    return new Result<ViewScheduleDTO>
            //    {
            //        Error = 1,
            //        Message = "Didn't find any clinic, please try again!",
            //        Data = null
            //    };
            //}

            //if (!clinic.IsActive)
            //{
            //    return new Result<ViewScheduleDTO>
            //    {
            //        Error = 1,
            //        Message = "Clinic is not active, cannot update schedule.",
            //        Data = null
            //    };
            //}

            //var overlappingSlotExists = await _unitOfWork.ConsultantRepository.HasOverlappingScheduleAsync
            //                        (
            //                            scheduleObj.ConsultantId.Value,
            //                            schedule.Slot.StartTime,
            //                            schedule.Slot.EndTime,
            //                            schedule.Slot.DayOfWeek
            //                        );

            //if (overlappingSlotExists)
            //{
            //    return new Result<ViewScheduleDTO>
            //    {
            //        Error = 1,
            //        Message = "The schedule overlaps with an existing schedule.",
            //        Data = null
            //    };
            //}

            _mapper.Map(schedule, scheduleObj);

            _scheduleRepository.Update(scheduleObj);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewScheduleDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Update schedule successfully" : "Update schedule fail",
                Data = _mapper.Map<ViewScheduleDTO>(scheduleObj)
            };
        }
    }
}
