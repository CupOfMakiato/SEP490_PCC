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

        public async Task<Schedule> GetScheduleByIdAsync(Guid id)
        {
            return await _context.Schedule.Include(s => s.Consultant)
                                          .Include(s => s.BookedByUser)
                                          .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task<List<Schedule>> GetSchedulesAsync(Guid consultantId)
        {
            return await _context.Schedule.Where(s => s.ConsultantId == consultantId && !s.IsDeleted)
                                          .ToListAsync();
        }
    }
}
