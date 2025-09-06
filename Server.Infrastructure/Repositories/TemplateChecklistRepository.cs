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
    public class TemplateChecklistRepository : GenericRepository<TemplateChecklist>, ITemplateChecklistRepository
    {
        private readonly AppDbContext _dbContext;

        public TemplateChecklistRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _dbContext = dbContext;
        }
        public async Task<List<TemplateChecklist>> GetAllTemplateChecklists()
        {
            return await _dbContext.TemplateChecklist
                .Include(c => c.TemplateChecklistGrowthDatas)
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }
        public async Task<List<TemplateChecklist>> GetAllActiveTemplateChecklists()
        {
            return await _dbContext.TemplateChecklist
                .Include(c => c.TemplateChecklistGrowthDatas)
                .Where(c => c.IsActive && !c.IsDeleted)
                .ToListAsync();
        }
        public async Task<List<TemplateChecklist>> GetAllInActiveTemplateChecklists()
        {
            return await _dbContext.TemplateChecklist
                .Include(c => c.TemplateChecklistGrowthDatas)
                .Where(c => c.IsActive == false && !c.IsDeleted)
                .ToListAsync();
        }
        public async Task<TemplateChecklist> GetTemplateChecklistById(Guid id)
        {
            return await _dbContext.TemplateChecklist
                .Include(c => c.TemplateChecklistGrowthDatas)
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<List<TemplateChecklist>> GetAllCompletedTemplateChecklists()
        {
            return await _dbContext.TemplateChecklist
                .Include(c => c.TemplateChecklistGrowthDatas)
                .Where(c => c.IsActive && !c.IsDeleted &&
                            c.TemplateChecklistGrowthDatas.Any(gd => gd.IsCompleted))
                .ToListAsync();
        }

        public async Task<List<TemplateChecklist>> GetAllInCompleteTemplateChecklists()
        {
            return await _dbContext.TemplateChecklist
                .Include(c => c.TemplateChecklistGrowthDatas)
                .Where(c => c.IsActive && !c.IsDeleted &&
                            c.TemplateChecklistGrowthDatas.Any(gd => !gd.IsCompleted))
                .ToListAsync();
        }

        public async Task<List<TemplateChecklist>> GetTemplateChecklistsByGrowthDataId(Guid growthDataId)
        {
            return await _dbContext.TemplateChecklist
                .Include(c => c.TemplateChecklistGrowthDatas)
                .Where(c => c.IsActive && !c.IsDeleted &&
                            c.TemplateChecklistGrowthDatas.Any(gd => gd.GrowthDataId == growthDataId))
                .ToListAsync();
        }

        public async Task<List<TemplateChecklist>> GetTemplateChecklistsByTrimester(int trimester, Guid userId)
        {
            return await _dbContext.TemplateChecklist
                .Include(c => c.TemplateChecklistGrowthDatas)
                .Where(
                c => c.Trimester == trimester && c.IsActive && !c.IsDeleted &&
                c.CreatedBy == userId)
                .ToListAsync();
        }
    }
}
