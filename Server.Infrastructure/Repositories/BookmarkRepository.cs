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
    public class BookmarkRepository : GenericRepository<Bookmark>, IBookmarkRepository
    {
        private readonly AppDbContext _dbContext;

        public BookmarkRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Bookmark>> GetAllBookmarks()
        {
            return await _dbContext.Bookmark
                .ToListAsync();
        }
        public async Task<Bookmark> IsBlogBookmarkedByUser(Guid blogId, Guid userId)
        {
            return await _dbContext.Bookmark
                .FirstOrDefaultAsync(b => b.UserId == userId && b.BlogId == blogId);
        }
        public async Task<int> CountBookmarksByBlogId(Guid blogId)
        {
            return await _dbContext.Bookmark
                .Where(b => b.BlogId == blogId && !b.IsDeleted)
                .CountAsync();
        }
    }
}
