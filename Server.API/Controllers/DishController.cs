using Microsoft.AspNetCore.Mvc;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Dish;
using Server.Application.Interfaces;

namespace Server.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpGet("{dishId}")]
        public async Task<IActionResult> GetDishByIdAsync(Guid dishId)
        {
            var result = await _dishService.GetDishByIdAsync(dishId);
            if (result.Error == 1)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetDishsAsync()
        {
            var result = await _dishService.GetDishsAsync();
            if (result.Error == 1)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpDelete("soft-delete/{dishId}")]
        public async Task<IActionResult> SoftDeleteDish(Guid dishId)
        {
            var result = await _dishService.SoftDeleteDish(dishId);
            if (result.Error == 1)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }

        [HttpDelete("{dishId}")]
        public async Task<IActionResult> DeleteDish(Guid dishId)
        {
            var result = await _dishService.DeleteDish(dishId);
            if (result.Error == 1)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }

        [HttpPost("CreateDish")]
        public async Task<IActionResult> CreateDish([FromBody] UpdateDishRequest request)
        {
            if (request == null)
                return BadRequest("Dish must not be null");
            if (request.foodList == null)
                return BadRequest("Foodlist must not be null");
            var result = await _dishService.CreateDish(request);
            if (result.Error == 1)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDish([FromBody] UpdateDishRequest request)
        {
            if (request == null)
                return BadRequest("Dish must not be null");
            if (request.foodList == null)
                return BadRequest("Foodlist must not be null");
            var result = await _dishService.UpdateDish(request);
            if (result.Error == 1)
                return BadRequest(result.Message);
            return Ok(result.Data);
        }
    }
}
