using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.API.Validations.CategoryValidations;
using Server.Application.Abstractions.RequestAndResponse.Category;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Category;
using Server.Application.Interfaces;
using Server.Application.Mappers.CategoryExtensions;
using Server.WebAPI.Validations.CategoryValidations;

namespace Server.WebAPI.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet("view-all-categories")]
        [ProducesResponseType(200, Type = typeof(Result<ViewCategoryDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryService.ViewAllCategories();

            return Ok(result);
        }

        [HttpGet("view-all-active-categories")]
        [ProducesResponseType(200, Type = typeof(Result<List<ViewCategoryDTO>>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> GetAllActiveCategories()
        {
            var result = await _categoryService.ViewAllActiveCategories();

            return Ok(result);
        }

        [HttpGet("view-all-categories-by-name")]
        [ProducesResponseType(200, Type = typeof(Result<ViewCategoryDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewCategoryByName(string name)
        {
            var result = await _categoryService.ViewCategoryByName(name);

            return Ok(result);
        }


        [HttpGet("view-category-by-id")]
        [ProducesResponseType(200, Type = typeof(ViewCategoryDTO))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewcategoryById(Guid categoryId)
        {
            var category = await _categoryService.ViewCategoryById(categoryId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpPost("add-new-category")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> AddNewCategory([FromForm] AddNewCategoryRequest req)
        {
            var validator = new AddNewCategoryRequestValidator();
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

            var categoryMapper = req.ToAddCategoryDTO();
            var result = await _categoryService.AddNewCategory(categoryMapper);

            return Ok(result);
        }

        [HttpPut("edit-category")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> EditCategory([FromForm] EditCategoryRequest req)
        {
            var validator = new EditCategoryRequestValidator();
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
            var categoryMapper = req.ToEditCategoryDTO();
            var result = await _categoryService.EditCategory(categoryMapper);
            return Ok(result);
        }

        [HttpDelete("delete-category")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            var category = await _categoryService.DeleteCategory(categoryId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }
    }
}
