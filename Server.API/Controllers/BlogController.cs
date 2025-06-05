using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.API.Validations.Blog;
using Server.Application.Abstractions.RequestAndResponse.Blog;
using Server.Application.Abstractions.RequestAndResponse.Category;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.Category;
using Server.Application.Interfaces;
using Server.Application.Mappers.BlogExtensions;
using Server.Application.Services;
using Server.WebAPI.Validations.CategoryValidations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.API.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBlogService _blogService;

        public BlogController(IMapper mapper, IBlogService blogService)
        {
            _mapper = mapper;
            _blogService = blogService;
        }
        [HttpGet("view-all-blogs")]
        [ProducesResponseType(200, Type = typeof(Result<ViewBlogDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllBlogs()
        {
            var result = await _blogService.ViewAllBlogs();
            return Ok(result);
        }

        [HttpGet("view-blog-by-id")]
        [ProducesResponseType(200, Type = typeof(Result<ViewBlogDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewBlogById(Guid blogId)
        {
            var result = await _blogService.ViewBlogById(blogId);
            return Ok(result);
        }

        [HttpPost("upload-blog")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> AddNewCategory([FromForm] UploadNewBlogRequest req)
        {
            var validator = new UploadNewBlogRequestValidator();
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

            var blogMapper = req.ToUploadBlogDTO();
            var result = await _blogService.UploadBlog(blogMapper);

            return Ok(result);
        }
    }
}
