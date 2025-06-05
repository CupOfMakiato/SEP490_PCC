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
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        private readonly AppDbContext _dbContext;

        public TagRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Tag>> GetAllTags()
        {
            return await _dbContext.Tag
                .Where(c => c.Status == StatusEnums.Active)
                .Include(c => c.TagCreatedBy)
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<Tag> GetTagById(Guid id)
        {
            return await _dbContext.Tag
                .Where(c => c.Status == StatusEnums.Active)
                .Include(c => c.TagCreatedBy)
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }
        public async Task<Tag?> GetTagByName(string name)
        {
            return await _dbContext.Tag
                .FirstOrDefaultAsync(t => t.Name.ToLower() == name.ToLower() && !t.IsDeleted);
        }
    }
}
