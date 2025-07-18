using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.Attendance;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/attendance")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost("create-attendance")]
        public async Task<IActionResult> CreateAttendance([FromBody] AddAttendanceDTO attendance)
        {
            var result = await _attendanceService.CreateAttendance(attendance);

            return Ok(result);
        }

        [HttpGet("view-all-attendances-by-consultant-id/{consultantId}")]
        public async Task<IActionResult> GetAllAttendances(Guid consultantId)
        {
            var result = await _attendanceService.GetAttendancesByConsultantIdAsync(consultantId);

            return Ok(result);
        }
    }
}
