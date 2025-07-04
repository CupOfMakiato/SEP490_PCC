using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.DailySchedule;
using Server.Application.Interfaces;
using Server.Application.Services;

namespace Server.API.Controllers
{
    [Route("api/daily-schedule")]
    [ApiController]
    public class DailyScheduleController : ControllerBase
    {
        private readonly IDailyScheduleService _dailyScheduleService;

        public DailyScheduleController(IDailyScheduleService dailyScheduleService)
        {
            _dailyScheduleService = dailyScheduleService;
        }

        [HttpGet("view-daily-schedule-by-id/{dailyScheduleId}")]
        public async Task<IActionResult> GetDailyScheduleByIdAsync(Guid dailyScheduleId)
        {
            var result = await _dailyScheduleService.GetDailyScheduleByIdAsync(dailyScheduleId);

            return Ok(result.Data);
        }

        [HttpPost("create-daily-schedule")]
        public async Task<IActionResult> CreateDailyScheduleAsync([FromBody] AddDailyScheduleDTO dailySchedule)
        {
            var result = await _dailyScheduleService.CreateDailySchedule(dailySchedule);

            return Ok(result.Data);
        }

        [HttpPut("update-daily-schedule")]
        public async Task<IActionResult> UpdateDailyScheduleAsync([FromBody] UpdateDailyScheduleDTO dailySchedule)
        {
            var result = await _dailyScheduleService.UpdateDailySchedule(dailySchedule);

            return Ok(result.Data);
        }

        [HttpDelete("soft-delete-daily-schedule/{dailyScheduleId}")]
        public async Task<IActionResult> SoftDeleteDailyScheduleAsync(Guid dailyScheduleId)
        {
            var result = await _dailyScheduleService.SoftDeleteDailySchedule(dailyScheduleId);

            return Ok(result.Data);
        }
    }
}
