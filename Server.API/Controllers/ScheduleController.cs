using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.Schedule;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet("view-all-schedules/{consultantId}")]
        public async Task<IActionResult> GetAllSchedules(Guid consultantId)
        {
            var result = await _scheduleService.GetSchedulesAsync(consultantId);

            return Ok(result);
        }

        [HttpPost("create-schedule")]
        public async Task<IActionResult> CreateSchedule(AddScheduleDTO addScheduleDTO)
        {
            var result = await _scheduleService.CreateSchedule(addScheduleDTO);

            return Ok(result);
        }

        [HttpPut("update-clinic")]
        public async Task<IActionResult> UpdateSchedule(UpdateScheduleDTO updateScheduleDTO)
        {
            var result = await _scheduleService.UpdateSchedule(updateScheduleDTO);

            return Ok(result);
        }

        [HttpDelete("delete-schedule/{scheduleId}")]
        public async Task<IActionResult> SoftDeleteSchedule(Guid scheduleId)
        {
            var result = await _scheduleService.SoftDeleteSchedule(scheduleId);

            return Ok(result);
        }
    }
}
