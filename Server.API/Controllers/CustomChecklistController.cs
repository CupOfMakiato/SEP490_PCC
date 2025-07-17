using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Interfaces;
using Server.Application;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.UserChecklist;
using Server.API.Validations.Blog;
using Server.Application.Abstractions.RequestAndResponse.Blog;
using Server.Application.DTOs.Blog;
using Server.Application.Services;
using Server.Application.Abstractions.RequestAndResponse.CustomChecklist;
using Server.Application.Mappers.CustomChecklistExtensions;
using Server.API.Validations.CustomChecklist;
using Server.Domain.Entities;

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
        [HttpGet("view-all-custom-checklists")]
        [ProducesResponseType(200, Type = typeof(Result<List<ViewCustomChecklistDTO>>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllCustomChecklists()
        {
            var result = await _customChecklistService.ViewAllCustomChecklists();
            return Ok(result);
        }
        [HttpGet("view-all-archived-custom-checklists")]
        [ProducesResponseType(200, Type = typeof(Result<List<ViewCustomChecklistDTO>>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllArchiveCustomChecklists()
        {
            var result = await _customChecklistService.ViewAllArchiveCustomChecklists();
            return Ok(result);
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
        [HttpPost("create-a-new-custom-checklist")]
        [ProducesResponseType(200, Type = typeof(Result<ViewCustomChecklistDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> CreateNewCustomChecklist([FromForm] CreateNewCustomChecklistRequest req)
        {
            var validator = new CreateNewCustomChecklistRequestValidator();
            var validatorResult = validator.Validate(req);
            if (validatorResult.IsValid == false)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = "Missing value!",
                    Data = validatorResult.Errors.Select(x => x.ErrorMessage),
                });
            }

            var checklist = req.ToCreateCustomChecklistDTO();
            var result = await _customChecklistService.CreateNewCustomChecklist(checklist);

            return Ok(result);
        }
        [HttpPut("edit-custom-checklist-info")]
        [ProducesResponseType(200, Type = typeof(Result<ViewCustomChecklistDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> UploadBlog([FromForm] EditCustomChecklistInfoRequest req)
        {
            var validator = new EditCustomChecklistInfoRequestValidator();
            var validatorResult = validator.Validate(req);
            if (validatorResult.IsValid == false)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = "Missing value!",
                    Data = validatorResult.Errors.Select(x => x.ErrorMessage),
                });
            }

            var checklist = req.ToEditCustomChecklistInfoDTO();
            var result = await _customChecklistService.EditCustomChecklistInfo(checklist);

            return Ok(result);
        }
        [HttpPut("mark-checklist-as-complete")]
        [ProducesResponseType(200, Type = typeof(Result<ViewCustomChecklistDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> MarkChecklistAsComplete(Guid ChecklistId)
        {
            var result = await _customChecklistService.MarkChecklistAsComplete(ChecklistId);
            return Ok(result);
        }
        [HttpPut("mark-checklist-as-incomplete")]
        [ProducesResponseType(200, Type = typeof(Result<ViewCustomChecklistDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> MarkChecklistAsInComplete(Guid ChecklistId)
        {
            var result = await _customChecklistService.MarkChecklistAsInComplete(ChecklistId);
            return Ok(result);
        }
        [HttpPut("archive-checklist")]
        [ProducesResponseType(200, Type = typeof(Result<ViewCustomChecklistDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ArchiveCustomChecklist(Guid ChecklistId)
        {
            var result = await _customChecklistService.ArchiveCustomChecklist(ChecklistId);
            return Ok(result);
        }
        [HttpPut("unarchive-checklist")]
        [ProducesResponseType(200, Type = typeof(Result<ViewCustomChecklistDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> UnArchiveCustomChecklist(Guid ChecklistId)
        {
            var result = await _customChecklistService.UnArchiveCustomChecklist(ChecklistId);
            return Ok(result);
        }
        [HttpDelete("delete-custom-checklist")]
        [ProducesResponseType(200, Type = typeof(Result<ViewCustomChecklistDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> DeleteCustomChecklist(Guid ChecklistId)
        {
            var result = await _customChecklistService.DeleteCustomChecklist(ChecklistId);
            return Ok(result);
        }
    }
}
    
