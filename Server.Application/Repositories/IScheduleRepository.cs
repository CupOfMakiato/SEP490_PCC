using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IScheduleRepository : IGenericRepository<Schedule>
    {
        public Task<Schedule> GetScheduleByIdAsync(Guid scheduleId);
        public Task<Schedule> GetScheduleAvailableByIdAsync(Guid scheduleId);
    }
}
