using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IAttendanceRepository : IGenericRepository<Attendance>
    {
        public Task<List<Attendance>> GetAttendancesByConsultantIdAsync(Guid consultantId);
    }
}
