using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.API.Validations.Blog;
using Server.API.Validations.GrowthData;
using Server.Application.Abstractions.RequestAndResponse.Blog;
using Server.Application.Abstractions.RequestAndResponse.GrowthData;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.GrowthData;
using Server.Application.Interfaces;
using Server.Application.Mappers.GrowthDataExtentions;
using Server.Application.Services;

namespace Server.API.Controllers
{
    [Route("api/growthdata")]
    [ApiController]
    public class GrowthDataController : ControllerBase
    {
        private readonly IGrowthDataService _growthDataService;
        private readonly ICurrentTime _currentTime;
        private readonly IMapper _mapper;
        public GrowthDataController(IGrowthDataService growthDataService, IMapper mapper, ICurrentTime currentTime)
        {
            _growthDataService = growthDataService;
            _mapper = mapper;
            _currentTime = currentTime;
        }
        [HttpGet("view-all-growthdata")]
        [ProducesResponseType(200, Type = typeof(Result<ViewGrowthDataDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllGrowthDatas()
        {
            var result = await _growthDataService.ViewAllGrowthDatas();
            return Ok(result);
        }
        [HttpGet("view-growthdata-by-id")]
        [ProducesResponseType(200, Type = typeof(ViewGrowthDataDTO))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewGrowthDataById(Guid growthdataId)
        {
            var result = await _growthDataService.ViewGrowthDataById(growthdataId);
            return Ok(result);
        }
        [HttpGet("view-growthdata-with-current-week/{userId}/{currentDate}")]
        [ProducesResponseType(200, Type = typeof(ViewGrowthDataDTO))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewGrowthDataWithCurrentWeek(Guid userId, DateTime currentDate)
        {
            var result = await _growthDataService.ViewGrowthDataWithCurrentWeek(userId, currentDate);
            return Ok(result);
        }

        [HttpPost("create-new-growthdata-profile")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> CreateNewGrowthDataProfile([FromForm] CreateNewGrowthDataProfileRequest req)
        {
            var validator = new CreateNewGrowthDataProfileRequestValidator();
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


            req.Id = Guid.NewGuid();

            var dataMapper = req.ToCreateNewGrowthDataProfileDTO();
            var result = await _growthDataService.CreateNewGrowthDataProfile(dataMapper);

            return Ok(result);
        }

        [HttpPut("edit-growthdata-profile")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> EditGrowthDataProfile([FromForm] EditGrowthDataProfileRequest req)
        {
            var validator = new EditNewGrowthDataProfileRequestValidator(_currentTime);
            var validationResult = validator.Validate(req);

            if (!validationResult.IsValid)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = "Validation failed!",
                    Data = validationResult.Errors.Select(x => x.ErrorMessage)
                });
            }

            var dto = req.ToEditGrowthDataProfileDTO(_currentTime);
            var result = await _growthDataService.EditGrowthDataProfile(dto);

            return Ok(result);
        }

    }
}
