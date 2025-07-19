using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Bookmark;
using Server.Application.DTOs.Like;
using Server.Application.Interfaces;
using Server.Application.Services;
using Server.WebAPI.Services;

namespace Server.API.Controllers
{
    [Route("api/bookmark")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly IBookmarkService _bookmarkService;
        private readonly IClaimsService _claimsService;
        public BookmarkController(IBookmarkService bookmarkService, IClaimsService claimsService)
        {
            _bookmarkService = bookmarkService;
            _claimsService = claimsService;
        }
        [HttpGet("view-all-bookmarked-blogs")]
        [ProducesResponseType(200, Type = typeof(Result<List<ViewAllBookmarkDTO>>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllBookmarkedBlogFromUser()
        {
            var userId = _claimsService.GetCurrentUserId;
            var result = await _bookmarkService.ViewAllBookmarkedBlogFromUser(userId);
            return Ok(result);
        }
        [HttpPost("toggle/{blogId}")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> BookmarkBlog(Guid blogId)
        {
            try
            {
                await _bookmarkService.BookmarkABlog(blogId);
                return Ok(new Result<object>
                {
                    Error = 0,
                    Message = "Bookmark action completed successfully",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = "Failed to bookmark/unbookmark blog",
                    Data = ex.Message
                });
            }
        }
    }
}
