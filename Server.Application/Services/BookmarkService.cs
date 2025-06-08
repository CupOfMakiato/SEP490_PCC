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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;

        public BookmarkService(IBookmarkRepository bookmarkRepository, IUnitOfWork unitOfWork, IClaimsService claimsService)
        {
            _bookmarkRepository = bookmarkRepository;
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
        }
        public async Task BookmarkABlog(Guid blogId)
        {
            var userId = _claimsService.GetCurrentUserId;

            var bookmark = await _bookmarkRepository.IsBlogBookmarkedByUser(userId, blogId);

            if (bookmark == null)
            {
                // Create new
                bookmark = new Bookmark
                {
                    BlogId = blogId,
                    UserId = userId,
                    BookmarkedAt = DateTime.UtcNow
                };
                await _bookmarkRepository.AddAsync(bookmark);
            }
            else if (bookmark.IsDeleted)
            {
                // Reactivate (undo soft delete)
                bookmark.IsDeleted = false;
                bookmark.BookmarkedAt = DateTime.UtcNow;
            }
            else
            {
                // Soft delete (unbookmark)
                bookmark.IsDeleted = true;
            }

            await _unitOfWork.SaveChangeAsync();
        }

        
    }
}
