using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Interfaces;
using Server.Application;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.UserChecklist;
using Server.Application.Services;
using Server.Application.DTOs.TemplateChecklist;

namespace Server.API.Controllers
{
    [Route("api/template-checklist")]
    [ApiController]
    public class TemplateChecklistController : ControllerBase
    {
        private readonly ITemplateChecklistService _templateChecklistService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;

        public TemplateChecklistController(IUnitOfWork unitOfWork, IClaimsService claimsService,
            ITemplateChecklistService templateChecklistService)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
            _templateChecklistService = templateChecklistService;
        }
        [HttpGet("view-all-template-checklists")]
        [ProducesResponseType(200, Type = typeof(Result<List<ViewTemplateChecklistDTO>>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllTemplateChecklists(Guid growthDataId)
        {
            var result = await _templateChecklistService.ViewAllTemplateChecklists(growthDataId);
            return Ok(result);
        }
    }
}
