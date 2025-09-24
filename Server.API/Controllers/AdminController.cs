using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Admin;
using Server.Application.DTOs.User;
using Server.Application.Interfaces;
using Server.Application.Services;

namespace Server.API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly PasswordService _passwordService;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly HttpClient _httpClient;
        private readonly IAdminService _adminService;

        public AdminController(PasswordService passwordService,
            IAuthService authService, IUserService userService,
            IEmailService emailService, HttpClient httpClient,
            IAdminService adminService)
        {
            _passwordService = passwordService;
            _authService = authService;
            _userService = userService;
            _emailService = emailService;
            _httpClient = httpClient;
            _adminService = adminService;
        }
        //[Authorize(Policy = "Admin")]
        [HttpGet("view-all-users")]
        [ProducesResponseType(200, Type = typeof(Result<List<GetUserDTO>>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllUsers()
        {
            var result = await _adminService.ViewAllUsers();
            return Ok(result);
        }
        //[Authorize(Policy = "Admin")]
        [HttpGet("view-all-staff")]
        [ProducesResponseType(200, Type = typeof(Result<List<GetUserDTO>>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllStaff()
        {
            var result = await _adminService.ViewAllStaff();
            return Ok(result);
        }
        //[Authorize(Policy = "Admin")]
        [HttpGet("view-all-clinics")]
        [ProducesResponseType(200, Type = typeof(Result<List<GetUserDTO>>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllClinics()
        {
            var result = await _adminService.ViewAllClinics();
            return Ok(result);
        }
        //[Authorize(Policy = "Admin")]
        [HttpPost("create-health-expert-account")]
        [ProducesResponseType(200, Type = typeof(Result<GetUserDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> CreateHealthExpertAccount([FromForm] CreateAccountDTO CreateAccountDTO)
        {
            try
            {
                var result = await _adminService.CreateHealthExpertAccount(CreateAccountDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = ex.Message,
                    Data = null
                });
            }
        }
        //[Authorize(Policy = "Admin")]
        [HttpPost("create-nutrient-specialist-account")]
        [ProducesResponseType(200, Type = typeof(Result<GetUserDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> CreateNutrientSpecialistAccount([FromForm] CreateAccountDTO CreateAccountDTO)
        {
            try
            {
                var result = await _adminService.CreateNutrientSpecialistAccount(CreateAccountDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = ex.Message,
                    Data = null
                });
            }
        }
        //[Authorize(Policy = "Admin")]
        [HttpPost("create-clinic-account")]
        [ProducesResponseType(200, Type = typeof(Result<GetUserDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> CreateClinicAccount([FromForm] CreateAccountDTO CreateAccountDTO)
        {
            try
            {
                var result = await _adminService.CreateClinicAccount(CreateAccountDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = ex.Message,
                    Data = null
                });
            }
        }
        //[Authorize(Policy = "Admin")]
        [HttpPut("change-account-authorize")]
        [ProducesResponseType(200, Type = typeof(Result<EditAccountDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ChangeAccountAuthorize([FromForm] EditAccountDTO EditAccountDTO)
        {
            try
            {
                var result = await _adminService.ChangeAccountAuthorize(EditAccountDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = ex.Message,
                    Data = null
                });
            }
        }
        //[Authorize(Policy = "Admin")]
        [HttpPut("ban-account")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> BanAccount(string email)
        {
            try
            {
                var result = await _adminService.BanAccount(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = ex.Message,
                    Data = null
                });
            }
        }
        //[Authorize(Policy = "Admin")]
        [HttpPut("unban-account")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> UnBanAccount(string email)
        {
            try
            {
                var result = await _adminService.UnBanAccount(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = ex.Message,
                    Data = null
                });
            }
        }
        //[Authorize(Policy = "Admin")]
        [HttpDelete("hard-delete-account")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> HardDeleteAccount(string email)
        {
            try
            {
                await _adminService.HardDeleteAccount(email);
                return Ok(new Result<object>
                {
                    Error = 0,
                    Message = "Account has been deleted good!",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = ex.Message,
                    Data = null
                });
            }
        }
    }
}
