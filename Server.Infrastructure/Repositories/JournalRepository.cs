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
    public class JournalRepository : GenericRepository<Journal>, IJournalRepository
    {
        private readonly AppDbContext _dbContext;

        public JournalRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Journal>> GetAllJournals()
        {
            return await _dbContext.Journal
                .Include(j => j.JournalCreatedBy)
                .Include(j => j.JournalSymptoms)
                    .ThenInclude(js => js.RecordedSymptom)
                .Include(j => j.Media)
                .Where(j => !j.IsDeleted)
                .ToListAsync();
        }
        public async Task<Journal> GetJournalById(Guid id)
        {
            return await _dbContext.Journal
                .Include(j => j.JournalCreatedBy)
                .Include(j => j.JournalSymptoms)
                    .ThenInclude(js => js.RecordedSymptom)
                .Include(j => j.Media)
                .FirstOrDefaultAsync(j => j.Id == id && !j.IsDeleted);
        }

        public async Task<List<Journal>> GetJournalsByGrowthDataId(Guid growthDataId)
        {
            return await _dbContext.Journal
                .Include(j => j.JournalCreatedBy)
                .Include(j => j.JournalSymptoms)
                    .ThenInclude(js => js.RecordedSymptom)
                .Include(j => j.Media)
                .Where(j => j.GrowthDataId == growthDataId && !j.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Journal>> GetJournalsByUserIdWithGrowthData(Guid growthDataId, Guid userId)
        {
            return await _dbContext.Journal
                .Include(j => j.JournalCreatedBy)
                .Include(j => j.JournalSymptoms)
                    .ThenInclude(js => js.RecordedSymptom)
                .Include(j => j.Media)
                .Where(j => j.CreatedBy == userId
                && j.GrowthDataId == growthDataId
                && !j.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Journal>> GetJournalFromGrowthDataByWeekAndTrimester(Guid growthDataId, int week, int trimester)
        {
            return await _dbContext.Journal
                .Include(j => j.JournalCreatedBy)
                .Include(j => j.JournalSymptoms)
                    .ThenInclude(js => js.RecordedSymptom)
                .Include(j => j.Media)
                .Where(j => j.CurrentWeek == week 
                && j.CurrentTrimester == trimester 
                && j.GrowthDataId == growthDataId
                && !j.IsDeleted)
                .ToListAsync();
        }
        public async Task<List<Journal>> GetJournalFromGrowthDataByWeek(Guid growthDataId, int week)
        {
            return await _dbContext.Journal
                .Include(j => j.JournalCreatedBy)
                .Include(j => j.JournalSymptoms)
                    .ThenInclude(js => js.RecordedSymptom)
                .Include(j => j.Media)
                .Where(j => j.CurrentWeek == week
                && j.GrowthDataId == growthDataId
                && !j.IsDeleted)
                .ToListAsync();
        }
    }
}
