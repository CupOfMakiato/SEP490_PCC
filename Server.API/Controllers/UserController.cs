using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.User;
using Server.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace Server.WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-current-user")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUserById()
        {
            try
            {
                var result = await _userService.GetCurrentUserById();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        [HttpPost("upload-avatar")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> UploadAvatar([FromForm] Guid userId, IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest(new Result<object>
                    {
                        Error = 1,
                        Message = "File is required"
                    });
                }
                var result = await _userService.UploadAvatar(userId, file);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = ex.Message
                });
            }

        }
        [HttpPut("edit-user-profile")]
        [ProducesResponseType(200, Type = typeof(Result<EditUserDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> EditUserProfile([FromForm] EditUserDTO editUserDTO)
        {
            var result = await _userService.EditUserProfile(editUserDTO);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
