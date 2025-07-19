using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Bookmark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface IBookmarkService
    {
        Task<Result<List<ViewAllBookmarkDTO>>> ViewAllBookmarkedBlogFromUser(Guid userId);
        Task BookmarkABlog(Guid blogId);
    }
}
