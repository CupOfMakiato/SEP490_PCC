using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class DailyScheduleRepository : GenericRepository<DailySchedule>, IDailyScheduleRepository
    {
        private readonly AppDbContext _context;

        public DailyScheduleRepository(AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(context, timeService, claimsService)
        {
            _context = context;
        }

        public async Task<DailySchedule?> GetDailyScheduleForAttendanceAsync(Guid clinicId, DayOfWeek dayOfWeek)
        {
            return await _context.DailySchedule
                .Include(ds => ds.ClinicWorkRule)
                .Where(ds => ds.ClinicWorkRule.ClinicId == clinicId
                             && ds.Day == dayOfWeek
                             && ds.ClinicWorkRule.DailySchedules.Any(s => s.ClinicWorkRuleId == ds.ClinicWorkRuleId))
                .FirstOrDefaultAsync();
        }
    }
}
