using CloudinaryDotNet.Actions;
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
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        private readonly AppDbContext _dbContext;

        public BlogRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Blog>> GetAllBlogs()
        {
            return await _dbContext.Blog
                .Include(c => c.BlogCreatedBy)
                .Include(c => c.BlogTags)
                    .ThenInclude(bt => bt.Tag)
                .Include(c => c.Comment)
                .Include(c => c.Media)
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<Blog> GetBlogById(Guid id)
        {
            return await _dbContext.Blog
                .Include(c => c.BlogCreatedBy)
                .Include(c => c.BlogTags)
                    .ThenInclude(bt => bt.Tag)
                .Include(c => c.Comment)
                .Include(c => c.Media)
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }
    }
}