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
    public class LikeRepository : GenericRepository<Like>, ILikeRepository
    {
        private readonly AppDbContext _dbContext;
        public LikeRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Like>> GetAllLikes()
        {
            return await _dbContext.Like
                .ToListAsync();
        }
        public async Task<Like> IsBlogLikedByUser(Guid blogId, Guid userId)
        {
            return await _dbContext.Like
                .FirstOrDefaultAsync(b => b.UserId == userId && b.BlogId == blogId);
        }
        public async Task<int> CountLikesByBlogId(Guid blogId)
        {
            return await _dbContext.Like
                .Where(b => b.BlogId == blogId && !b.IsDeleted)
                .CountAsync();
        }
    }
}
