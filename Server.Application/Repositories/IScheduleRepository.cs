using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IScheduleRepository : IGenericRepository<Schedule>
    {
        public Task<List<Schedule>> GetSchedulesAsync(Guid consultantId);
        public Task<Schedule> GetScheduleByIdAsync(Guid id);
    }
}
