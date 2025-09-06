using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Domain.Enums;
using Server.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Repositories
{
    public class TailoredCheckupReminderRepository : GenericRepository<TailoredCheckupReminder>, ITailoredCheckupReminderRepository
    {
        private readonly AppDbContext _dbContext;

        public TailoredCheckupReminderRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _dbContext = dbContext;
        }
        public async Task<List<TailoredCheckupReminder>> GetAllTailoredCheckupReminders()
        {
            return await _dbContext.TailoredCheckupReminder
                .Include(c => c.GrowthData)
                    .ThenInclude(g => g.GrowthDataCreatedBy)
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }
        public async Task<List<TailoredCheckupReminder>> GetAllActiveTailoredCheckupReminders()
        {
            return await _dbContext.TailoredCheckupReminder
                .Include(c => c.GrowthData)
                    .ThenInclude(g => g.GrowthDataCreatedBy)
                .Where(c => !c.IsDeleted && c.IsActive)
                .ToListAsync();
        }
        public async Task<TailoredCheckupReminder?> GetTailoredCheckupReminderById(Guid id)
        {
            return await _dbContext.TailoredCheckupReminder
                .Include(c => c.GrowthData)
                    .ThenInclude(g => g.GrowthDataCreatedBy)
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }
        public async Task<List<TailoredCheckupReminder>> GetAllTailoredCheckupRemindersByGrowthData(Guid growthDataId)
        {
            return await _dbContext.TailoredCheckupReminder
                .Include(c => c.GrowthData)
                    .ThenInclude(g => g.GrowthDataCreatedBy)
                .Where(c => !c.IsDeleted &&
                       c.GrowthDataId == growthDataId)
                       //&& c.IsActive)
                .ToListAsync();
        }
        public async Task<List<TailoredCheckupReminder>> GetOverdueRemindersByGrowthData(Guid growthDataId, DateTime currentDate)
        {
            return await _dbContext.TailoredCheckupReminder
                .Include(c => c.GrowthData)
                    .ThenInclude(g => g.GrowthDataCreatedBy)
                .Where(r => !r.IsDeleted &&
                            r.GrowthDataId == growthDataId &&
                            r.ScheduledDate < currentDate &&
                            r.IsActive)
                .ToListAsync();
        }
        public async Task<List<TailoredCheckupReminder>> GetUpcomingRemindersByGrowthData(Guid growthDataId, DateTime currentDate)
        {
            return await _dbContext.TailoredCheckupReminder
                .Include(c => c.GrowthData)
                    .ThenInclude(g => g.GrowthDataCreatedBy)
                .Where(r => !r.IsDeleted &&
                            r.GrowthDataId == growthDataId &&
                            r.ScheduledDate > currentDate &&
                            r.IsActive)
                .OrderBy(r => r.ScheduledDate)
                .ToListAsync();
        }

        public async Task<List<TailoredCheckupReminder>> GetCompletedRemindersByGrowthData(Guid growthDataId, DateTime currentDate)
        {
            return await _dbContext.TailoredCheckupReminder
                .Include(c => c.GrowthData)
                    .ThenInclude(g => g.GrowthDataCreatedBy)
                .Where(r => !r.IsDeleted &&
                            r.GrowthDataId == growthDataId &&
                            r.ScheduledDate < currentDate &&
                            r.IsActive)
                .ToListAsync();
        }

        public async Task<TailoredCheckupReminder?> GetActiveReminderByGrowthDataAndWeek(Guid growthDataId, int week)
        {
            return await _dbContext.TailoredCheckupReminder
                .Where(r => r.GrowthDataId == growthDataId
                            && r.IsActive
                            && r.RecommendedStartWeek == week)
                .OrderByDescending(r => r.CreationDate)
                .FirstOrDefaultAsync();
        }



        public async Task<List<TailoredCheckupReminder>> GetRemindersByTrimester(Guid growthDataId, int trimester)
        {
            int startWeek = trimester switch 
            { 
                1 => 1, 
                2 => 14, 
                3 => 28, 
                _ => 1 
            };
            int endWeek = trimester switch 
            { 
                1 => 13, 
                2 => 27, 
                3 => 42, 
                _ => 42 
            };

            return await _dbContext.TailoredCheckupReminder
                .Include(c => c.GrowthData)
                    .ThenInclude(g => g.GrowthDataCreatedBy)
                .Where(r => !r.IsDeleted &&
                            r.GrowthDataId == growthDataId &&
                            (
                                (r.RecommendedStartWeek >= startWeek && r.RecommendedStartWeek <= endWeek) ||
                                (r.RecommendedEndWeek >= startWeek && r.RecommendedEndWeek <= endWeek)
                            ))
                .ToListAsync();
        }

    }
}
