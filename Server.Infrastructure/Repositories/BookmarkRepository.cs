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
        public async Task<List<Bookmark>> GetAllBookmarkedBlogByUserId(Guid userId)
        {
            return await _dbContext.Bookmark
                .Include(b => b.Blog)
                .Where(c => !c.IsDeleted && c.UserId == userId)
                .ToListAsync();
        }

        // Get all bookmarks by user and blog
        public async Task<Bookmark?> GetByUserAndBlog(Guid userId, Guid blogId)
        {
            return await _dbContext.Bookmark
                .Include(b => b.Blog)
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(b => b.UserId == userId && b.BlogId == blogId);
        }
        public async Task<int> CountBookmarksByBlogId(Guid blogId)
        {
            return await _dbContext.Bookmark
                .Include(b => b.Blog)
                .Where(c => !c.IsDeleted)
                .CountAsync(b => b.BlogId == blogId);
        }
    }
}
