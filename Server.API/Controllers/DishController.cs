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
        public async Task<IActionResult> CreateDish(CreateDishRequest request)
        {
            if (request == null)
                return BadRequest("Dish must not be null");
            if (request.foodList == null)
                return BadRequest("Foodlist must not be null");
            if(string.IsNullOrWhiteSpace(request.DishName))
                return BadRequest("Dish name must not be null or empty");   
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
            if(request.DishName == null)
                return BadRequest("Dish name must not be null or empty");
            var result = await _dishService.UpdateDish(request);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("update-food-in-dish")]
        public async Task<IActionResult> UpdateFoodInDish([FromBody] UpdateFoodInDishRequest request)
        {
            if (request.FoodId == Guid.Empty)
                return BadRequest("Food Id is null or empty");

            if (request.DishId == Guid.Empty)
                return BadRequest("Dish Id is null or empty");

            if (string.IsNullOrWhiteSpace(request.Unit))
                return BadRequest("Unit is null or empty");

            if (request.Amount <= 0)
                return BadRequest("Amount must be greater than zero");
            try
            {
                var result = await _dishService.UpdateFoodInDish(request);
                if (result.Error == 1)
                    return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }            
        }

        [HttpPut("delete-food-in-dish-by-food-id")]
        public async Task<IActionResult> DeleteFoodInDishByFoodId([FromQuery] Guid dishId, Guid foodId)
        {
            if (foodId == Guid.Empty)
                return BadRequest("Food Id is null or empty");

            if (dishId == Guid.Empty)
                return BadRequest("Dish Id is null or empty");

            try
            {
                var result = await _dishService.DeleteFoodInDishByFoodId(dishId, foodId);
                if (result.Error == 1)
                    return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }    
        }

        [HttpPut("add-dish-image")]
        public async Task<IActionResult> AddDishImage([FromForm] AddDishImageRequest request)
        {
            if (request == null)
                return BadRequest("Request must not be null");

            if (request.dishId == Guid.Empty)
                return BadRequest("Dish Id is required");

            if (request.Image == null)
                return BadRequest("Image file is required");

            // Validate file type
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(request.Image.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(fileExtension))
                return BadRequest("Invalid file type. Only .jpg, .jpeg, and .png files are allowed");

            // Validate file size (e.g., max 5MB)
            if (request.Image.Length > 5 * 1024 * 1024)
                return BadRequest("File size exceeds maximum limit of 5MB");

            try
            {
                var result = await _dishService.AddDishImage(request);
                if (result.Error == 1)
                    return BadRequest(result.Message);

                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update-dish-image")]
        public async Task<IActionResult> UpdateDishImage([FromForm] AddDishImageRequest request)
        {
            if (request == null)
                return BadRequest("Request must not be null");

            if (request.dishId == Guid.Empty)
                return BadRequest("Dish Id is required");

            if (request.Image is not null)
            {
                // Validate file type
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                var fileExtension = Path.GetExtension(request.Image.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(fileExtension))
                    return BadRequest("Invalid file type. Only .jpg, .jpeg, and .png files are allowed");

                // Validate file size (e.g., max 5MB)
                if (request.Image.Length > 5 * 1024 * 1024)
                    return BadRequest("File size exceeds maximum limit of 5MB");
            }            

            try
            {
                var result = await _dishService.AddDishImage(request);
                if (result.Error == 1)
                    return BadRequest("Update fail");

                return Ok(new { Message = "Update succes", Data = result.Data });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
