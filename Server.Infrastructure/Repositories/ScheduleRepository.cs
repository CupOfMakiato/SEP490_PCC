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

        public async Task<Schedule> GetScheduleByIdAsync(Guid scheduleId)
        {
            return await _context.Schedule
                .Include(s => s.Consultant).ThenInclude(c => c.Clinic)
                .Include(s => s.Slot)
                .FirstOrDefaultAsync(s => s.Id == scheduleId
                                        && !s.IsDeleted
                                        && !s.Slot.IsDeleted
                                        && s.Consultant.Clinic.IsActive);
        }

        public async Task<Schedule> GetScheduleAvailableByIdAsync(Guid scheduleId)
        {
            return await _context.Schedule
                .Include(s => s.Consultant).ThenInclude(c => c.Clinic)
                .Include(s => s.Slot)
                .FirstOrDefaultAsync(s => s.Id == scheduleId
                                    && !s.IsDeleted
                                    && s.Slot.IsAvailable
                                    && !s.Slot.IsDeleted
                                    && s.Consultant.Clinic.IsActive);
        }
    }
}
