using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemConfigurationController : ControllerBase
    {
        private readonly ISystemConfigurationService _configurationService;

        public SystemConfigurationController(ISystemConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSystemConfiguration()
        {
            var config = await _configurationService.GetSystemConfigurationAsync();
            return Ok(config);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSystemConfiguration([FromBody] Domain.Entities.SystemConfiguration systemConfiguration)
        {
            var result = await _configurationService.UpdateSystemConfigurationAsync(systemConfiguration);
            if (result.Error == 0)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSystemConfiguration([FromBody] Domain.Entities.SystemConfiguration systemConfiguration)
        {
            var result = await _configurationService.CreateSystemConfigurationAsync(systemConfiguration);
            if (result.Error == 0)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPatch("change-status")]
        public async Task<IActionResult> ChangeStatus()
        {
            var result = await _configurationService.ChangeStatus();
            if (result)
            {
                return Ok(new { Message = "Status changed successfully." });
            }
            return BadRequest(new { Message = "Failed to change status." });
        }

    }
}
