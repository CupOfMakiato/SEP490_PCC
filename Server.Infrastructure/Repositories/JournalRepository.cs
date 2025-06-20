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
                .Include(j => j.Media)
                .Where(j => !j.IsDeleted)
                .ToListAsync();
        }
        public async Task<Journal> GetJournalById(Guid id)
        {
            return await _dbContext.Journal
                .Include(j => j.JournalCreatedBy)
                .Include(j => j.Media)
                .FirstOrDefaultAsync(j => j.Id == id && !j.IsDeleted);
        }

        public Task<List<Journal>> GetJournalsByGrowthDataId(Guid growthDataId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Journal>> GetJournalsByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Journal>> GetJournalsByWeekAndTrimester(int week, int trimester)
        {
            throw new NotImplementedException();
        }
    }
}
