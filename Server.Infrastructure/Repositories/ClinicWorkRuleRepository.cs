using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class ClinicWorkRuleRepository : GenericRepository<ClinicWorkRule>, IClinicWorkRuleRepository
    {
        private readonly AppDbContext _context;

        public ClinicWorkRuleRepository(AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService) :
            base(context, timeService, claimsService)
        {
            _context = context;
        }

        public async Task<(List<DayOfWeek> DayOffs, int TotalWorkingDays)> CalDaysOffAndTotalWorkingDaysAsync(Guid clinicId)
        {
            var clinicWorkRule = await _context.ClinicWorkRule
                .Include(c => c.DailySchedules)
                .FirstOrDefaultAsync(c => c.ClinicId == clinicId && !c.IsDeleted);

            if (clinicWorkRule?.DailySchedules == null)
                return (new List<DayOfWeek>(), 0);

            var daysOff = clinicWorkRule.DailySchedules
                .Where(d => !d.IsWorking)
                .Select(d => d.Day)
                .ToList();

            var totalWorkingDays = clinicWorkRule.DailySchedules
                .Count(d => d.IsWorking);

            return (daysOff, totalWorkingDays);
        }

        public async Task<ClinicWorkRule> GetClinicWorkRuleAsync(Guid clinicId)
        {
            return await _context.ClinicWorkRule
                .Include(c => c.DailySchedules)
                .FirstOrDefaultAsync(c => c.ClinicId == clinicId && !c.IsDeleted);
        }
    }
}
