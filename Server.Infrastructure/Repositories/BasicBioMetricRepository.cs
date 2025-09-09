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
    public class BasicBioMetricRepository : GenericRepository<BasicBioMetric>, IBasicBioMetricRepository
    {
        private readonly AppDbContext _dbContext;

        public BasicBioMetricRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _dbContext = dbContext;
        }
        public async Task<List<BasicBioMetric>> GetAllBasicBioMetrics()
        {
            return await _dbContext.BasicBioMetric
                .ToListAsync();
        }
        public async Task<BasicBioMetric> GetBasicBioMetricById(Guid bbmId)
        {
            return await _dbContext.BasicBioMetric
                .Where(a => a.Id == bbmId)
                .FirstOrDefaultAsync();
        }
        public async Task<List<BasicBioMetric>> GetAllRecentBiometrics(DateTime lastCheckTime)
        {
            return await _dbContext.BasicBioMetric
                .Where(b => b.ModificationDate >= lastCheckTime)
                .Include(b => b.GrowthData)
                .ThenInclude(g => g.GrowthDataCreatedBy)
                .AsNoTracking()
                .ToListAsync();
        }


    }
}
