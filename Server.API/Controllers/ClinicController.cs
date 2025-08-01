using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllClinics()
        {
            var result = await _clinicService.GetClinicsAsync();

            return Ok(result);
        }
        [HttpGet("view-all-clinics-by-name")]
        public async Task<IActionResult> ViewClinicsByName(string name)
        {
            var result = await _clinicService.GetClinicByNameAsync(name);

            return Ok(result);
        }


        [HttpGet("view-clinic-by-id/{clinicId}")]
        public async Task<IActionResult> ViewClinicById(Guid clinicId)
        {
            var clinic = await _clinicService.GetClinicByIdAsync(clinicId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(clinic);
        }

        [HttpPost("create-clinic")]
        public async Task<IActionResult> CreateClinic(AddClinicDTO addClinicDTO)
        {
            var result = await _clinicService.CreateClinic(addClinicDTO);

            return Ok(result);
        }

        [HttpPut("update-clinic")]
        public async Task<IActionResult> UpdateClinic(UpdateClinicDTO updateClinicDTO)
        {
            var result = await _clinicService.UpdateClinic(updateClinicDTO);

            return Ok(result);
        }

        [HttpDelete("soft-delete-clinic/{clinicId}")]
        public async Task<IActionResult> SoftDeleteClinic(Guid clinicId)
        {
            var result = await _clinicService.SoftDeleteClinic(clinicId);

            return Ok(result);
        }

        [HttpPut("approve-clinic/{clinicId}")]
        public async Task<IActionResult> ApproveClinic(Guid clinicId)
        {
            var result = await _clinicService.ApproveClinic(clinicId);

            return Ok(result);
        }

        [HttpPut("reject-clinic/{clinicId}")]
        public async Task<IActionResult> RejectClinic(Guid clinicId)
        {
            var result = await _clinicService.RejectClinic(clinicId);

            return Ok(result);
        }
    }
}
