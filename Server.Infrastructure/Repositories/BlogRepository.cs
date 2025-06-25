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
                .Include(b => b.Category)
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
                .Include(b => b.Category)
                .Include(c => c.BlogCreatedBy)
                .Include(c => c.BlogTags)
                    .ThenInclude(bt => bt.Tag)
                .Include(c => c.Comment)
                .Include(c => c.Media)
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }

        public async Task<List<Blog>> GetBookmarkedBlogsByUserId(Guid userId)
        {
            return await _dbContext.Bookmark
                .Where(b => b.UserId == userId && !b.IsDeleted)
                .Select(b => b.Blog)
                .Include(b => b.Category)
                .Include(blog => blog.BlogTags)
                .ThenInclude(bt => bt.Tag)
                .Include(b => b.BlogCreatedBy)
                .Include(b => b.Media)
                .Include(b => b.Comment)
                .Where(b => !b.IsDeleted)
                .ToListAsync();
        }
        public async Task<List<Blog>> GetBlogsByUserId(Guid userId)
        {
            return await _dbContext.Blog
                .Include(b => b.Category)
                .Include(b => b.BlogTags)
                    .ThenInclude(bt => bt.Tag)
                .Include(b => b.Media)
                .Include(b => b.Comment)
                .Include(b => b.BlogCreatedBy)
                .Where(b => !b.IsDeleted && b.CreatedBy == userId)
                .ToListAsync();
        }

        public async Task<List<Blog>> GetBlogsWithHealthCategory()
        {
            return await _dbContext.Blog
                .Include(b => b.Category)
                .Include(b => b.BlogTags)
                    .ThenInclude(bt => bt.Tag)
                .Include(b => b.BlogCreatedBy)
                .Include(b => b.Media)
                .Include(b => b.Comment)
                .Where(b =>!b.IsDeleted 
                && b.Category.CategoryName != "Pregnancy Nutrition" 
                //&& b.BlogTags.Any(bt => bt.Tag.Name == "Health")
                )
                .ToListAsync();
        }
        public async Task<List<Blog>> GetBlogsWithNutrientCategory()
        {
            return await _dbContext.Blog
                .Include(b => b.Category)
                .Include(b => b.BlogTags)
                    .ThenInclude(bt => bt.Tag)
                .Include(b => b.BlogCreatedBy)
                .Include(b => b.Media)
                .Include(b => b.Comment)
                .Where(b => !b.IsDeleted
                && b.Category.CategoryName == "Pregnancy Nutrition"
                )
                .ToListAsync();
        }



    }
}