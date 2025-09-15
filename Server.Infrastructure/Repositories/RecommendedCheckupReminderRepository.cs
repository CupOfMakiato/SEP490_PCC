using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Repositories
{
    public class RecommendedCheckupReminderRepository : GenericRepository<RecommendedCheckup>, IRecommendedCheckupReminderRepository
    {
        private readonly AppDbContext _dbContext;

        public RecommendedCheckupReminderRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _dbContext = dbContext;
        }
        public async Task<List<RecommendedCheckup>> GetAllRecommendedCheckups()
        {
            return await _dbContext.RecommendedCheckup
                .Include(c => c.RecommendedCheckupGrowthDatas)
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }
        public async Task<List<RecommendedCheckup>> GetAllActiveRecommendedCheckups()
        {
            return await _dbContext.RecommendedCheckup
                .Include(c => c.RecommendedCheckupGrowthDatas)
                .Where(c => c.IsActive && !c.IsDeleted)
                .ToListAsync();
        }
        public async Task<List<RecommendedCheckup>> GetAllInActiveRecommendedCheckups()
        {
            return await _dbContext.RecommendedCheckup
                .Include(c => c.RecommendedCheckupGrowthDatas)
                .Where(c => c.IsActive == false && !c.IsDeleted)
                .ToListAsync();
        }
        public async Task<RecommendedCheckup> GetRecommendedCheckupById(Guid id)
        {
            return await _dbContext.RecommendedCheckup
                .Include(c => c.RecommendedCheckupGrowthDatas)
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<List<RecommendedCheckup>> GetAllCompletedRecommendedCheckups()
        {
            return await _dbContext.RecommendedCheckup
                .Include(c => c.RecommendedCheckupGrowthDatas)
                .Where(c => c.IsActive && !c.IsDeleted &&
                            c.RecommendedCheckupGrowthDatas.Any(gd => gd.IsCompleted))
                .ToListAsync();
        }

        public async Task<List<RecommendedCheckup>> GetAllInCompleteRecommendedCheckups()
        {
            return await _dbContext.RecommendedCheckup
                .Include(c => c.RecommendedCheckupGrowthDatas)
                .Where(c => c.IsActive && !c.IsDeleted &&
                            c.RecommendedCheckupGrowthDatas.Any(gd => !gd.IsCompleted))
                .ToListAsync();
        }

        public async Task<List<RecommendedCheckup>> GetRecommendedCheckupsByGrowthDataId(Guid growthDataId)
        {
            return await _dbContext.RecommendedCheckup
                .Include(c => c.RecommendedCheckupGrowthDatas)
                .Where(c => c.IsActive && !c.IsDeleted &&
                            c.RecommendedCheckupGrowthDatas.Any(gd => gd.GrowthDataId == growthDataId))
                .ToListAsync();
        }
        public async Task AddCheckupLink(RecommendedCheckupGrowthData link)
        {
            await _dbContext.RecommendedCheckupGrowthData.AddAsync(link);
        }

        public async Task<RecommendedCheckupGrowthData?> GetCheckupLinkById(Guid linkId)
        {
            return await _dbContext.RecommendedCheckupGrowthData
                .FirstOrDefaultAsync(x => x.RecommendedCheckupId == linkId);
        }

        public Task UpdateCheckupLink(RecommendedCheckupGrowthData link)
        {
            _dbContext.RecommendedCheckupGrowthData.Update(link);
            return Task.CompletedTask;
        }
        public async Task<List<RecommendedCheckupGrowthData>> GetAllDueReminders(DateTime notifyThreshold)
        {
            return await _dbContext.RecommendedCheckupGrowthData
                .Where(r => !r.IsCompleted && r.ScheduledDate.HasValue && r.ScheduledDate <= notifyThreshold)
                .ToListAsync();
        }

        public async Task<List<RecommendedCheckupGrowthData>> GetAllActiveCheckupLinks()
        {
            return await _dbContext.RecommendedCheckupGrowthData
                .Include(r => r.RecommendedCheckup)
                .Include(r => r.GrowthData)
                    .ThenInclude(g => g.GrowthDataCreatedBy)
                .Where(r => !r.IsCompleted && !r.RecommendedCheckup.IsDeleted && r.RecommendedCheckup.IsActive)
                .ToListAsync();
        }

    }
}
