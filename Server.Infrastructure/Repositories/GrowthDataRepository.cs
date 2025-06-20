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
    public class GrowthDataRepository : GenericRepository<GrowthData>, IGrowthDataRepository
    {
        private readonly AppDbContext _dbContext;
        public GrowthDataRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext, timeService, claimsService)
        {
            _dbContext = dbContext;
        }
        public async Task<List<GrowthData>> GetAllGrowthData()
        {
            return await _dbContext.GrowthData
                .Include(g => g.GrowthDataCreatedBy)
                .Include(g => g.Journal)
                .Where(g => !g.IsDeleted)
                .ToListAsync();
        }
        public async Task<GrowthData> GetGrowthDataById(Guid id)
        {
            return await _dbContext.GrowthData
                .Include(g => g.GrowthDataCreatedBy)
                .Include(g => g.Journal)
                .FirstOrDefaultAsync(g => g.Id == id && !g.IsDeleted);
        }
        public async Task<GrowthData> GetGrowthDataWithCurrentWeek(Guid userId, DateTime currentDate)
        {
            var growth = await _dbContext.GrowthData
                .Include(g => g.GrowthDataCreatedBy)
                .Include(g => g.Journal)
                .FirstOrDefaultAsync(g => g.GrowthDataCreatedBy.Id == userId && !g.IsDeleted);

            if (growth == null)
                return null;

            // Recalculate week (but don't update DB if not needed)
            growth.GestationalAgeInWeeks = growth.GetCurrentGestationalAgeInWeeks(currentDate);

            return growth;
        }
    }
}
