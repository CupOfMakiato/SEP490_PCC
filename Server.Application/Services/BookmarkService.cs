using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.Bookmark;
using Server.Application.DTOs.Like;
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
        private readonly IMapper _mapper;

        public BookmarkService(IBookmarkRepository bookmarkRepository,
            IUnitOfWork unitOfWork, IClaimsService claimsService, IMapper mapper)
        {
            _bookmarkRepository = bookmarkRepository;
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
            _mapper = mapper;
        }
        public async Task<Result<List<ViewAllBookmarkDTO>>> ViewAllBookmarkedBlogFromUser(Guid userId)
        {
            var likes = await _bookmarkRepository.GetAllBookmarkedBlogFromUser(userId);
            var result = _mapper.Map<List<ViewAllBookmarkDTO>>(likes);
            return new Result<List<ViewAllBookmarkDTO>>
            {
                Error = 0,
                Message = "Retrieved bookmarked blogs successfully",
                Data = result
            };
        }
        public async Task BookmarkABlog(Guid blogId)
        {
            var userId = _claimsService.GetCurrentUserId;

            var bookmark = await _bookmarkRepository.IsBlogBookmarkedByUser(blogId, userId);

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
        public async Task<Result<object>> SoftDeleteBookmark(Guid blogId)
        {
            var userId = _claimsService.GetCurrentUserId;

            var bookmark = await _bookmarkRepository.IsBlogBookmarkedByUser(blogId, userId);

            if (bookmark == null || bookmark.IsDeleted)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Bookmark already deleted"
                };
            }

            bookmark.IsDeleted = true;
            await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = 0,
                Message = "Bookmark removed successfully"
            };
        }


    }
}
