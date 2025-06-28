using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Clinic;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/clinic")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicService _clinicService;

        public ClinicController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        [HttpGet("view-all-clinics")]
        [ProducesResponseType(200, Type = typeof(Result<ViewClinicDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> GetAllClinics()
        {
            var result = await _clinicService.GetClinicsAsync();

            return Ok(result);
        }
        [HttpGet("view-all-clinics-by-name")]
        [ProducesResponseType(200, Type = typeof(Result<ViewClinicDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewClinicsByName(string name)
        {
            var result = await _clinicService.GetClinicByNameAsync(name);

            return Ok(result);
        }


        [HttpGet("view-clinic-by-id/{clinicId}")]
        [ProducesResponseType(200, Type = typeof(ViewClinicDTO))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewClinicById(Guid clinicId)
        {
            var clinic = await _clinicService.GetClinicByIdAsync(clinicId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(clinic);
        }

        [HttpPost("create-clinic")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> CreateClinic(AddClinicDTO addClinicDTO)
        {
            var result = await _clinicService.CreateClinic(addClinicDTO);

            return Ok(result);
        }

        [HttpPut("update-clinic")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> UpdateClinic(UpdateClinicDTO updateClinicDTO)
        {
            var result = await _clinicService.UpdateClinic(updateClinicDTO);

            return Ok(result);
        }
    }
}
