using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Attendance;
using Server.Application.DTOs.Clinic;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Domain.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Server.Application.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IUnitOfWork unitOfWork, IMapper mapper, IAttendanceRepository attendanceRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _attendanceRepository = attendanceRepository;
        }

        public async Task<Result<ViewAttendanceDTO>> CreateAttendance(AddAttendanceDTO attendance)
        {
            var consultant = await _unitOfWork.ConsultantRepository.GetByIdAsync(attendance.ConsultantId);

            if (consultant == null)
            {
                return new Result<ViewAttendanceDTO>
                {
                    Error = 1,
                    Message = "Consultant not found.",
                    Data = null
                };
            }

            var clinic = await _unitOfWork.ClinicRepository.GetClinicByIdAsync(attendance.ClinicId);

            if (clinic == null)
            {
                return new Result<ViewAttendanceDTO>
                {
                    Error = 1,
                    Message = "Clinic not found.",
                    Data = null
                };
            }

            var dailySchedule = await _unitOfWork.DailyScheduleRepository
                .GetDailyScheduleForAttendanceAsync(attendance.ClinicId, attendance.Date);

            if (dailySchedule == null || dailySchedule.StartTime == null)
            {
                return new Result<ViewAttendanceDTO>
                {
                    Error = 1,
                    Message = "No schedule found for this consultant and date.",
                    Data = null
                };
            }

            var startTime = dailySchedule.StartTime.Value;

            AttendanceStatus status;

            if (attendance.CheckInTime > startTime.Add(TimeSpan.FromMinutes(15)))
            {
                status = AttendanceStatus.Absent;
            }
            else if (attendance.CheckInTime > startTime)
            {
                status = AttendanceStatus.Late;
            }
            else
            {
                status = AttendanceStatus.Present;
            }

            var attendanceEntity = _mapper.Map<Attendance>(attendance);

            attendanceEntity.Status = status;

            await _attendanceRepository.AddAsync(attendanceEntity);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewAttendanceDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Attendance recorded successfully." : "Failed to record attendance.",
                Data = _mapper.Map<ViewAttendanceDTO>(attendanceEntity)
            };
        }

        public async Task<Result<List<ViewAttendanceDTO>>> GetAttendancesByConsultantIdAsync(Guid consultantId)
        {
            var result = _mapper.Map<List<ViewAttendanceDTO>>(await _attendanceRepository.GetAttendancesByConsultantIdAsync(consultantId));

            return new Result<List<ViewAttendanceDTO>>
            {
                Error = 0,
                Message = "View all attendances successfully",
                Data = result
            };
        }
    }
}
