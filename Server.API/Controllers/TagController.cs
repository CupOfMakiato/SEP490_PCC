using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.API.Validations.Tag;
using Server.Application.Abstractions.RequestAndResponse.Category;
using Server.Application.Abstractions.RequestAndResponse.Tag;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Tag;
using Server.Application.Interfaces;
using Server.Application.Mappers.TagExtensions;
using Server.Application.Services;
using Server.WebAPI.Validations.CategoryValidations;

namespace Server.API.Controllers
{
    [Route("api/tag")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;
        public TagController(ITagService tagService, IMapper mapper)
        {
            _tagService = tagService;
            _mapper = mapper;
        }
        [HttpGet("view-all-tags")]
        [ProducesResponseType(200, Type = typeof(Result<ViewTagDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllTags()
        {
            var result = await _tagService.ViewAllTags();
            return Ok(result);
        }

        [HttpGet("view-tag-by-id")]
        [ProducesResponseType(200, Type = typeof(Result<ViewTagDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewTagById(Guid tagId)
        {
            var result = await _tagService.ViewTagById(tagId);
            return Ok(result);
        }

        [HttpPost("add-new-tag")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> AddNewCategory([FromForm] AddNewTagRequest req)
        {
            var validator = new AddNewTagRequestValidator();
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

            var tagMapper = req.ToAddTagDTO();
            var result = await _tagService.AddNewTag(tagMapper);

            return Ok(result);
        }
    }
}
