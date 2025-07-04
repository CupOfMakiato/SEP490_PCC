﻿using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        // View
        Task<List<Blog>> GetAllBlogs();
        Task<Blog> GetBlogById(Guid id);
        Task<List<Blog>> GetBookmarkedBlogsByUserId(Guid userId);
        Task<List<Blog>> GetBlogsByUserId(Guid userId);
        Task<List<Blog>> GetBlogsWithHealthCategory();
        Task<List<Blog>> GetBlogsWithNutrientCategory();
    }
}
