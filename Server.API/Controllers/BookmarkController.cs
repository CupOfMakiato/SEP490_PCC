using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Abstractions.Shared;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/bookmark")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly IBookmarkService _bookmarkService;
        public BookmarkController(IBookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }

        [HttpPost("bookmark/{blogId}")]
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
