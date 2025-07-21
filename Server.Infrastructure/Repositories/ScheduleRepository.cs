using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
    {
        private readonly AppDbContext _context;

        public ScheduleRepository(AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(context, timeService, claimsService)
        {
            _context = context;
        }

        public Task<Schedule> GetScheduleByIdAsync(Guid scheduleId)
        {
            return _context.Schedule
                .Include(s => s.Slot)
                .FirstOrDefaultAsync(s => s.Id == scheduleId
                                        && !s.IsDeleted);
        }
    }
}
