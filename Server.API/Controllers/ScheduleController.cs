using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.Schedule;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        //private readonly IScheduleService _scheduleService;

        //public ScheduleController(IScheduleService scheduleService)
        //{
        //    _scheduleService = scheduleService;
        //}

        //[HttpGet("view-schedule-by-id/{scheduleId}")]
        //public async Task<IActionResult> GetScheduleById(Guid scheduleId)
        //{
        //    var result = await _scheduleService.GetScheduleById(scheduleId);

        //    return Ok(result);
        //}

        //[HttpPost("create-schedule")]
        //public async Task<IActionResult> CreateSchedule([FromBody] AddScheduleDTO schedule)
        //{
        //    var result = await _scheduleService.CreateSchedule(schedule);

        //    return Ok(result);
        //}

        //[HttpDelete("soft-delete-schedule/{scheduleId}")]
        //public async Task<IActionResult> SoftDeleteSchedule(Guid scheduleId)
        //{
        //    var result = await _scheduleService.SoftDeleteSchedule(scheduleId);

        //    return Ok(result);
        //}

        //[HttpPut("update-schedule")]
        //public async Task<IActionResult> UpdateSchedule([FromBody] UpdateScheduleDTO schedule)
        //{
        //    var result = await _scheduleService.UpdateSchedule(schedule);

        //    return Ok(result);
        //}
    }
}
