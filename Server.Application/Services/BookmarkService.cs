using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Blog;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Services
{
    public class BookmarkService : IBookmarkService
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        public BookmarkService(IBookmarkRepository bookmarkRepository)
        {
            _bookmarkRepository = bookmarkRepository;
        }
        //public async Task ToggleBookmark(Guid userId, Guid blogId)
        //{
        //    var bookmark = await _bookmarkRepository.GetByUserAndBlog(userId, blogId);

        //    if (bookmark != null)
        //    {
        //        await _bookmarkRepository.RE(bookmark);
        //    }
        //    else
        //    {
        //        var newBookmark = new Bookmark
        //        {
        //            UserId = userId,
        //            BlogId = blogId
        //        };
        //        await _bookmarkRepository.AddAsync(newBookmark);
        //    }
        //}
    }
}
