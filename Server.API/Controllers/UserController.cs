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

        [HttpGet("view-user-by-id")]
        [ProducesResponseType(200, Type = typeof(Result<GetUserDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))] 
        public async Task<IActionResult> ViewUserById(Guid id)
        {
            var result = await _userService.ViewUserById(id);
            return Ok(result);
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
        public async Task<IActionResult> EditUserProfile([FromBody] EditUserDTO editUserDTO)
        {
            var result = await _userService.EditUserProfile(editUserDTO);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("get-allergies-and-diseases-by-userid")]
        [ProducesResponseType(200, Type = typeof(Result<UserDiseasesAndUserAllergiesDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> GetAllergyAndDiseaseByUserId(Guid userId)
        {
            var result = await _userService.GetAllergyAndDiseaseByUserId(userId);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("add-disease-to-user")]
        [ProducesResponseType(200, Type = typeof(Result<UserDiseasesDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> AddDiseaseToUser(Guid userId, [FromBody] UserDiseasesDTO diseasesDTO)
        {
            var result = await _userService.AddDiseaseToUser(userId, diseasesDTO);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("add-allergy-to-user")]
        [ProducesResponseType(200, Type = typeof(Result<UserAllergiesDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> AddAlleryToUser(Guid userId, [FromBody] UserAllergiesDTO allergiesDTO)
        {
            var result = await _userService.AddAlleryToUser(userId, allergiesDTO);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("remove-disease-from-user")]
        [ProducesResponseType(200, Type = typeof(Result<bool>))]
        [ProducesResponseType(400, Type = typeof(Result<bool>))]
        public async Task<IActionResult> RemoveDiseaseFromUser(Guid userId, Guid diseaseId)
        {
            var result = await _userService.RemoveDiseaseFromUser(userId, diseaseId);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("remove-allergy-from-user")]
        [ProducesResponseType(200, Type = typeof(Result<bool>))]
        [ProducesResponseType(400, Type = typeof(Result<bool>))]
        public async Task<IActionResult> RemoveAllergyFromUser(Guid userId, Guid allergyId)
        {
            var result = await _userService.RemoveAllergyFromUser(userId, allergyId);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("update-disease-to-user")]
        [ProducesResponseType(200, Type = typeof(Result<UserDiseasesDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> UpdateDiseaseToUser(Guid userId, [FromBody] UserDiseasesDTO diseasesDTO)
        {
            var result = await _userService.UpdateDiseaseToUser(userId, diseasesDTO);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("update-allergy-to-user")]
        [ProducesResponseType(200, Type = typeof(Result<UserAllergiesDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> UpdateAlleryToUser(Guid userId, [FromBody] UserAllergiesDTO allergiesDTO)
        {
            var result = await _userService.UpdateAlleryToUser(userId, allergiesDTO);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }



    }
}
