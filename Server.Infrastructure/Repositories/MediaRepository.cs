using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Repositories
{
    internal class MediaRepository : GenericRepository<Media>, IMediaRepository
    {
        private readonly AppDbContext _dbContext;

        public MediaRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Media>> GetAllMedias()
        {
            return await _dbContext.Media.ToListAsync();
        }

        public async Task<List<Media>> GetMediaByBlogId(Guid blogId)
        {
            return await _dbContext.Media
                .Where(a => a.BlogId == blogId
                && !a.IsDeleted
                )
                .ToListAsync();
        }

        public async Task<Media> GetMediaById(Guid id)
        {
            return await _dbContext.Media.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> GetTotalMediaCount()
        {
            return await _dbContext.Media.Where(a => !a.IsDeleted).CountAsync();
        }
    }
}
