using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.BasicBioMetric;
using Server.Application.DTOs.Blog;
using Server.Application.Interfaces;
using Server.Application.Services;

namespace Server.API.Controllers
{
    [Route("api/basicbiometric")]
    [ApiController]
    public class BasicBioMetricController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBasicBioMetricService _basicBioMetricService;

        public BasicBioMetricController(IMapper mapper, IBasicBioMetricService basicBioMetricService)
        {
            _mapper = mapper;
            _basicBioMetricService = basicBioMetricService;
        }

        [HttpGet("view-all-bbm")]
        [ProducesResponseType(200, Type = typeof(Result<ViewBasicBioMetricDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllBasicBioMetrics()
        {
            var result = await _basicBioMetricService.ViewAllBasicBioMetrics();
            return Ok(result);
        }

        [HttpGet("view-bbm-by-id")]
        [ProducesResponseType(200, Type = typeof(Result<ViewBasicBioMetricDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewBlogById(Guid bbmId)
        {
            var result = await _basicBioMetricService.ViewBasicBioMetricById(bbmId);
            return Ok(result);
        }
    }
}
