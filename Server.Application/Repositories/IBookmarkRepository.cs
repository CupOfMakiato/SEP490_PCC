using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface IBookmarkRepository : IGenericRepository<Bookmark>
    {
        // view
        Task<List<Bookmark>> GetAllBookmarks();
        Task<List<Bookmark>> GetAllBookmarkedBlogByUserId(Guid userId);
        Task<Bookmark?> GetByUserAndBlog(Guid userId, Guid blogId);

        // count
        Task<int> CountBookmarksByBlogId(Guid blogId);

    }
}
