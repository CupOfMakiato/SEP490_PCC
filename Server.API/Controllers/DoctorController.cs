using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.Doctor;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("view-doctor-by-id/{doctorId}")]
        public async Task<IActionResult> GetDoctorByIdAsync(Guid doctorId)
        {
            var result = await _doctorService.GetDoctorByIdAsync(doctorId);

            return Ok(result.Data);
        }

        [HttpPost("create-doctor")]
        public async Task<IActionResult> CreateDoctorAsync([FromBody] AddDoctorDTO doctor)
        {
            var result = await _doctorService.CreateDoctor(doctor);

            return Ok(result.Data);
        }

        [HttpPut("update-doctor")]
        public async Task<IActionResult> UpdateDoctorAsync([FromBody] UpdateDoctorDTO doctor)
        {
            var result = await _doctorService.UpdateDoctor(doctor);

            return Ok(result.Data);
        }

        [HttpDelete("soft-delete-doctor/{doctorId}")]
        public async Task<IActionResult> SoftDeleteDoctorAsync(Guid doctorId)
        {
            var result = await _doctorService.SoftDeleteDoctor(doctorId);

            return Ok(result.Data);
        }
    }
}
