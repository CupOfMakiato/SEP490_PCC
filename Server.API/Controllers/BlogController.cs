using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("view-blogs-from-user")]
        [ProducesResponseType(200, Type = typeof(Result<ViewBlogDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewBlogsByUserId(Guid userId)
        {
            var result = await _blogService.ViewBlogsByUserId(userId);
            return Ok(result);
        }

        [Authorize(Roles = "Clinic,HealthExpert,NutrientSpecialist")]
        [HttpPost("upload-blog")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> UploadBlog([FromForm] UploadNewBlogRequest req)
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

        [Authorize(Roles = "HealthExpert,NutrientSpecialist")]
        [HttpPut("approve-blog")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ApproveBlog(Guid blogId, Guid approvedByUserId)
        {
            var result = await _blogService.ApproveBlog(blogId, approvedByUserId);
            return Ok(result);
        }

        //[Authorize(Policy = "NutrientSpecialist")]
        //[HttpPut("approve-nutrient-category-blog")]
        //[ProducesResponseType(200, Type = typeof(Result<object>))]
        //[ProducesResponseType(400, Type = typeof(Result<object>))]
        //public async Task<IActionResult> ApproveNutrientBlog(Guid blogId, Guid approvedByUserId)
        //{
        //    var result = await _blogService.ApproveNutrientBlog(blogId, approvedByUserId);
        //    return Ok(result);
        //}

        //[Authorize(Policy = "HealthExpert")]
        //[HttpPut("approve-health-category-blog")]
        //[ProducesResponseType(200, Type = typeof(Result<object>))]
        //[ProducesResponseType(400, Type = typeof(Result<object>))]
        //public async Task<IActionResult> ApproveHealthBlog(Guid blogId, Guid approvedByUserId)
        //{
        //    var result = await _blogService.ApproveHealthBlog(blogId, approvedByUserId);
        //    return Ok(result);
        //}

        [Authorize(Roles = "HealthExpert,NutrientSpecialist")]
        [HttpPut("reject-blog")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ApproveBlog(Guid blogId, Guid approvedByUserId, string? rejectionReason)
        {
            var result = await _blogService.RejectBlog(blogId, approvedByUserId, rejectionReason);
            return Ok(result);
        }

        [Authorize(Policy = "Clinic")]
        [HttpPut("edit-blog")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> EditBlog([FromForm] EditBlogRequest req)
        {
            var validator = new EditBlogRequestValidator();
            var validatorResult = validator.Validate(req);
            if (!validatorResult.IsValid)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = "Invalid input!",
                    Data = validatorResult.Errors.Select(x => x.ErrorMessage),
                });
            }

            var blogMapper = req.ToEditBlogDTO();

            var result = await _blogService.EditBlog(blogMapper);

            return Ok(result);
        }

        [HttpDelete("delete-blog")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> DeleteBlog(Guid blogId)
        {
            var result = await _blogService.DeleteBlog(blogId);
            return Ok(result);
        }

    }
}
