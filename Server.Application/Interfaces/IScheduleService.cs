using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Schedule;

namespace Server.Application.Interfaces
{
    public interface IScheduleService
    {
        public Task<Result<List<ViewScheduleDTO>>> GetSchedulesAsync(Guid consultantId);
        public Task<Result<ViewScheduleDTO>> GetScheduleByIdAsync(Guid scheduleId);
        public Task<Result<bool>> SoftDeleteSchedule(Guid scheduleId);
        public Task<Result<ViewScheduleDTO>> CreateSchedule(AddScheduleDTO schedule);
        public Task<Result<ViewScheduleDTO>> UpdateSchedule(UpdateScheduleDTO schedule);
    }
}
