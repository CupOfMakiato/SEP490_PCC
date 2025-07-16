using Microsoft.EntityFrameworkCore;
using Server.Application.Commons;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Repositories
{
    public class CustomChecklistRepository : GenericRepository<CustomChecklist>, ICustomChecklistRepository
    {
        private readonly AppDbContext _dbContext;

        public CustomChecklistRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CustomChecklist>> GetAllCustomChecklists()
        {
            return await _dbContext.CustomChecklist
                .Include(c => c.GrowthData)
                .ToListAsync();
        }
        public async Task<List<CustomChecklist>> GetAllActiveCustomChecklists()
        {
            return await _dbContext.CustomChecklist
                .Include(c => c.GrowthData)
                .Where(c => c.IsActive && !c.IsDeleted)
                .ToListAsync();
        }
        public async Task<CustomChecklist> GetCustomChecklistById(Guid id)
        {
            return await _dbContext.CustomChecklist
                .Include(c => c.GrowthData)
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<List<CustomChecklist>> ViewAllCompletedChecklists()
        {
            return await _dbContext.CustomChecklist
                .Include(c => c.GrowthData)
                .Where(c => c.IsCompleted && c.IsActive && !c.IsDeleted)
                .ToListAsync();
        }
        public async Task<List<CustomChecklist>> ViewAllInCompleteChecklists()
        {
            return await _dbContext.CustomChecklist
                .Include(c => c.GrowthData)
                .Where(c => c.IsCompleted == false && c.IsActive && !c.IsDeleted)
                .ToListAsync();
        }
        public async Task<List<CustomChecklist>> GetCustomChecklistsByGrowthDataId(Guid growthDataId)
        {
            return await _dbContext.CustomChecklist
                .Include(c => c.GrowthData)
                .Where(c => c.GrowthDataId == growthDataId && c.IsActive && !c.IsDeleted)
                .ToListAsync();
        }
        public async Task<List<CustomChecklist>> GetCustomChecklistsByTrimester(int trimester)
        {
            return await _dbContext.CustomChecklist
                .Include(c => c.GrowthData)
                .Where(c => c.Trimester == trimester && c.IsActive && !c.IsDeleted)
                .ToListAsync();
        }
    }
}

