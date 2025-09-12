using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Journal;
using Server.Application.Interfaces;
using Server.Application.Services;
using Server.Domain.Entities;

namespace Server.API.Controllers
{
    [Route("api/recommended-checkup-reminder")]
    [ApiController]
    public class RecommendedCheckupReminderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRecommendedCheckupReminderService _recommendedCheckupReminderService;

        public RecommendedCheckupReminderController(IMapper mapper, IRecommendedCheckupReminderService recommendedCheckupReminderService)
        {
            _mapper = mapper;
            _recommendedCheckupReminderService = recommendedCheckupReminderService;
        }

        [HttpGet("view-all-recommended-reminders")]
        [ProducesResponseType(200, Type = typeof(Result<List<RecommendedCheckup>>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllReminders(Guid growthDataId)
        {
            var result = await _recommendedCheckupReminderService.ViewAllReminders(growthDataId);
            return Ok(result);
        }
    }
}
