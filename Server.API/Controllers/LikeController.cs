using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Abstractions.Shared;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/like")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;
        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost("toggle/{blogId}")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> BookmarkBlog(Guid blogId)
        {
            try
            {
                await _likeService.LikeABlog(blogId);
                return Ok(new Result<object>
                {
                    Error = 0,
                    Message = "Like action completed successfully",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = "Failed to like/Unlike blog",
                    Data = ex.Message
                });
            }
        }
    }
}
