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
        Task<List<Bookmark>> GetAllBookmarkedBlogFromUser(Guid userId);

        // count
        Task<int> CountBookmarksByBlogId(Guid blogId);

        // check bookmark
        Task<Bookmark> IsBlogBookmarkedByUser(Guid blogId, Guid userId);

    }
}
