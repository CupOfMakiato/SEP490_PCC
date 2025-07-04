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
                .Include(g => g.Journals)
                .Include(g => g.BasicBioMetric)
                .Where(g => !g.IsDeleted)
                .ToListAsync();
        }
        public async Task<GrowthData> GetGrowthDataById(Guid growthDataId)
        {
            return await _dbContext.GrowthData
                .Include(g => g.GrowthDataCreatedBy)
                .Include(g => g.Journals)
                .Include(g => g.BasicBioMetric)
                .FirstOrDefaultAsync(g => g.Id == growthDataId
                && !g.IsDeleted);
        }
        public async Task<GrowthData> GetActiveGrowthDataById(Guid growthDataId)
        {
            return await _dbContext.GrowthData
                .Include(g => g.GrowthDataCreatedBy)
                .Include(g => g.Journals)
                .Include(g => g.BasicBioMetric)
                .FirstOrDefaultAsync(g => g.Id == growthDataId
                && g.Status == GrowthDataStatus.Active
                && !g.IsDeleted);
        }

        public async Task<GrowthData> GetGrowthDataWithCurrentWeek(Guid growthDataId, DateTime currentDate)
        {
            return await _dbContext.GrowthData
                .Include(g => g.GrowthDataCreatedBy)
                .Include(g => g.Journals)
                .Include(g => g.BasicBioMetric)
                .FirstOrDefaultAsync(g => g.Id == growthDataId && !g.IsDeleted);
        }
        public async Task<GrowthData> GetGrowthDataFromUserWithCurrentWeek(Guid userId, DateTime currentDate)
        {
            return await _dbContext.GrowthData
                .Include(g => g.GrowthDataCreatedBy)
                .Include(g => g.Journals)
                .Include(g => g.BasicBioMetric)
                .FirstOrDefaultAsync(g => g.GrowthDataCreatedBy.Id == userId 
                && g.Status == GrowthDataStatus.Active 
                && g.EstimatedDueDate >= currentDate 
                && !g.IsDeleted);
        }

        public async Task<GrowthData> GetGrowthDataByUserId(Guid userId)
        {
            return await _dbContext.GrowthData
                .Include(g => g.GrowthDataCreatedBy)
                .Include(g => g.Journals)
                .Include(g => g.BasicBioMetric)
                .FirstOrDefaultAsync(g => g.GrowthDataCreatedBy.Id == userId && !g.IsDeleted);
        }

        public async Task<GrowthData> GetActiveGrowthDataByUserId(Guid userId)
        {
            return await _dbContext.GrowthData
                .Include(g => g.GrowthDataCreatedBy)
                .Include(g => g.Journals)
                .Include(g => g.BasicBioMetric)
                .AsSplitQuery()
                .SingleAsync(g => 
                    g.GrowthDataCreatedBy.Id == userId 
                    && !g.IsDeleted
                    && g.Status == GrowthDataStatus.Active);
        }
    }
}
