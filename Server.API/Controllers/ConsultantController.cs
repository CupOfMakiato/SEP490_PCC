using Microsoft.AspNetCore.Mvc;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Consultant;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/consultant")]
    [ApiController]
    public class ConsultantController : ControllerBase
    {
        private readonly IConsultantService _consultantService;

        public ConsultantController(IConsultantService consultantService)
        {
            _consultantService = consultantService;
        }

        [HttpGet("view-all-consultants")]
        [ProducesResponseType(200, Type = typeof(Result<ViewConsultantDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> GetAllConsultants()
        {
            var result = await _consultantService.GetConsultantsAsync();

            return Ok(result);
        }
        [HttpGet("view-all-consultants-by-name")]
        [ProducesResponseType(200, Type = typeof(Result<ViewConsultantDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewConsultantsByName(string name)
        {
            var result = await _consultantService.GetConsultantByNameAsync(name);

            return Ok(result);
        }


        [HttpGet("view-consultant-by-id/{consultantId}")]
        [ProducesResponseType(200, Type = typeof(ViewConsultantDTO))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewConsultantById(Guid consultantId)
        {
            var consultant = await _consultantService.GetConsultantByIdAsync(consultantId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(consultant);
        }

        [HttpPost("create-consultant")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> CreateConsultant(AddConsultantDTO addConsultantDTO)
        {
            var result = await _consultantService.CreateConsultant(addConsultantDTO);

            return Ok(result);
        }

        [HttpPut("update-consultant")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> UpdateConsultant(UpdateConsultantDTO updateConsultantDTO)
        {
            var result = await _consultantService.UpdateConsultant(updateConsultantDTO);

            return Ok(result);
        }
    }
}
