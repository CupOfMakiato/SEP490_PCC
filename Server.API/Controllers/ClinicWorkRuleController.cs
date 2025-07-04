using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.ClinicWorkRule;
using Server.Application.Interfaces;
using Server.Application.Services;

namespace Server.API.Controllers
{
    [Route("api/clinic-work-rule")]
    [ApiController]
    public class ClinicWorkRuleController : ControllerBase
    {
        private readonly IClinicWorkRuleService _clinicWorkRuleService;

        public ClinicWorkRuleController(IClinicWorkRuleService clinicWorkRuleService)
        {
            _clinicWorkRuleService = clinicWorkRuleService;
        }

        [HttpPost("create-clinic-work-rule")]
        public async Task<IActionResult> CreateClinicWorkRule([FromBody] AddClinicWorkRuleDTO clinicWorkRuleDTO)
        {
            var result = await _clinicWorkRuleService.CreateClinicWorkRule(clinicWorkRuleDTO);

            return Ok(result);
        }

        [HttpGet("get-clinic-work-rule/{clinicId}")]
        public async Task<IActionResult> GetClinicWorkRule(Guid clinicId)
        {
            var result = await _clinicWorkRuleService.GetClinicWorkRuleAsync(clinicId);

            return Ok(result);
        }

        [HttpPut("update-clinic-work-rule")]
        public async Task<IActionResult> UpdateClinicWorkRule([FromBody] UpdateClinicWorkRuleDTO clinicWorkRuleDTO)
        {
            var result = await _clinicWorkRuleService.UpdateClinicWorkRule(clinicWorkRuleDTO);

            return Ok(result);
        }

        [HttpDelete("soft-delete-clinic-work-rule/{clinicId}")]
        public async Task<IActionResult> SoftDeleteClinicWorkRule(Guid clinicId)
        {
            var result = await _clinicWorkRuleService.SoftDeleteSclinicWorkRule(clinicId);

            return Ok(result);
        }
    }
}
