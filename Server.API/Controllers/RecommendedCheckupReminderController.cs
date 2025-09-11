using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Interfaces;

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
    }
}
