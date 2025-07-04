using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.DailySchedule;

namespace Server.Application.Interfaces
{
    public interface IDailyScheduleService
    {
        public Task<Result<ViewDailyScheduleDTO>> GetDailyScheduleByIdAsync(Guid dailyScheduleId);
        public Task<Result<bool>> SoftDeleteDailySchedule(Guid dailyScheduleId);
        public Task<Result<ViewDailyScheduleDTO>> CreateDailySchedule(AddDailyScheduleDTO dailySchedule);
        public Task<Result<ViewDailyScheduleDTO>> UpdateDailySchedule(UpdateDailyScheduleDTO DailySchedule);
    }
}
