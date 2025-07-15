using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Interfaces;
using Server.Application;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.UserChecklist;

namespace Server.API.Controllers
{
    [Route("api/custom-checklist")]
    [ApiController]
    public class CustomChecklistController : ControllerBase
    {
        private readonly ICustomChecklistService _customChecklistService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;

        public CustomChecklistController(IUnitOfWork unitOfWork, IClaimsService claimsService,
            ICustomChecklistService customChecklistService)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
            _customChecklistService = customChecklistService;
        }
        [HttpGet("view-all-active-custom-checklists")]
        [ProducesResponseType(200, Type = typeof(Result<List<ViewCustomChecklistDTO>>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllActiveCustomChecklists()
        {
            var result = await _customChecklistService.ViewAllActiveCustomChecklists();
            return Ok(result);
        }
        [HttpGet("view-custom-checklist-by-id")]
        [ProducesResponseType(200, Type = typeof(Result<ViewCustomChecklistDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewCustomChecklistById(Guid id)
        {
            var result = await _customChecklistService.ViewCustomChecklistById(id);
            return Ok(result);
        }
        [HttpGet("view-all-completed-custom-checklists")]
        [ProducesResponseType(200, Type = typeof(Result<List<ViewCustomChecklistDTO>>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllCompletedCustomChecklists()
        {
            var result = await _customChecklistService.ViewAllCompleteChecklist();
            return Ok(result);
        }
        [HttpGet("view-all-incomplete-custom-checklists")]
        [ProducesResponseType(200, Type = typeof(Result<List<ViewCustomChecklistDTO>>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllInCompleteCustomChecklists()
        {
            var result = await _customChecklistService.ViewAllInCompleteChecklist();
            return Ok(result);
        }
    }
}
