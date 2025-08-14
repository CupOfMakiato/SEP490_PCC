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

        [HttpGet("view-dish-by-id")]
        public async Task<IActionResult> GetDishByIdAsync([FromQuery] Guid dishId)
        {
            var result = await _dishService.GetDishByIdAsync(dishId);
            if (result.Error == 1)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpGet("view-all-dishes")]
        public async Task<IActionResult> GetDishsAsync()
        {
            var result = await _dishService.GetDishsAsync();
            if (result.Error == 1)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("soft-delete-dish-by-id")]
        public async Task<IActionResult> SoftDeleteDish([FromQuery] Guid dishId)
        {
            var result = await _dishService.SoftDeleteDish(dishId);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("delete-dish-by-id")]
        public async Task<IActionResult> DeleteDish([FromQuery] Guid dishId)
        {
            var result = await _dishService.DeleteDish(dishId);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("add-dish")]
        public async Task<IActionResult> CreateDish([FromBody] CreateDishRequest request)
        {
            if (request == null)
                return BadRequest("Dish must not be null");
            if (request.foodList == null)
                return BadRequest("Foodlist must not be null");
            var result = await _dishService.CreateDish(request);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("update-dish")]
        public async Task<IActionResult> UpdateDish([FromBody] UpdateDishRequest request)
        {
            if (request == null)
                return BadRequest("Dish must not be null");
            if (request.foodList == null)
                return BadRequest("Foodlist must not be null");
            var result = await _dishService.UpdateDish(request);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
