using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.Food;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.API.Controllers
{
    [ApiController]
    [Route("api/food")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet("view-all-foods")]
        public async Task<IActionResult> Gets()
        {
            return Ok(await _foodService.GetFoodsAsync());
        }

        [HttpPut("create-warning-food-for-disease")]
        public async Task<IActionResult> CreateWarningFoodForDisease([FromBody] CreateWarningFoodForDiseaseRequest request)
        {
            if (request.DiseaseId == Guid.Empty)
                return BadRequest("DiseaseId is required");

            if (request.warningFoodDtos == null || !request.warningFoodDtos.Any())
                return BadRequest("At least one warning food is required");

            foreach (var dto in request.warningFoodDtos)
            {
                if (dto.FoodId == Guid.Empty)
                    return BadRequest("Food Id is required for each warning food");

                if (string.IsNullOrWhiteSpace(dto.Description))
                    return BadRequest("Description is required for each warning food");
            }
            try
            {
                var result = await _foodService.CreateWarningFoodForDisease(request);
                if (result.Error == 1)
                    return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }                
        }

        [HttpPut("remove-recommend-or-warning-food-for-disease")]
        public async Task<IActionResult> RemoveFoodDisease([FromBody] RemoveFoodDiseaseRequest request)
        {
            if (request.DiseaseId == Guid.Empty)
                return BadRequest("DiseaseId is required");
            if (request.FoodId == Guid.Empty)
                return BadRequest("FoodId is required");
            var result = await _foodService.RemoveFoodDisease(request);
            try
            {
                if (result.Error == 1)
                    return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }            
        }

        [HttpPut("remove-recommend-or-warning-food-for-allergy")]
        public async Task<IActionResult> RemoveFoodAllergy([FromBody] RemoveFoodAllergyRequest request)
        {
            if (request.AllergyId == Guid.Empty)
                return BadRequest("AllergyId is required");
            if (request.FoodId == Guid.Empty)
                return BadRequest("FoodId is required");
            var result = await _foodService.RemoveFoodAllergy(request);
            try
            {
                if (result.Error == 1)
                    return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("create-warning-food-for-allergy")]
        public async Task<IActionResult> CreateWarningFoodForAllergy([FromBody] CreateWarningFoodForAllergyRequest request)
        {
            if (request.AllergyId == Guid.Empty)
                return BadRequest("AllergyId is required");
            foreach (var dto in request.warningFoodDtos)
            {
                if (dto.FoodId == Guid.Empty)
                    return BadRequest("Food Id is required for each warning food");

                if (string.IsNullOrWhiteSpace(dto.Description))
                    return BadRequest("Description is required for each warning food");
            }
            var result = await _foodService.CreateWarningFoodForAllergy(request);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut("create-recommend-food-for-disease")]
        public async Task<IActionResult> CreateRecommendFoodForDisease([FromBody] CreateRecommendFoodForDiseaseRequest request)
        {
            if (request.DiseaseId == Guid.Empty)
                return BadRequest("DiseaseId is required");
            foreach (var dto in request.recommendFoodDtos)
            {
                if (dto.FoodId == Guid.Empty)
                    return BadRequest("Food Id is required for each recommend food");

                if (string.IsNullOrWhiteSpace(dto.Description))
                    return BadRequest("Description is required for each recommend food");
            }
            var result = await _foodService.CreateRecommendFoodForDisease(request);
            if (result.Error == 1)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("view-warning-foods-by-disease-ids")]
        public async Task<IActionResult> ViewWarningFoodsByDiseaseIds([FromBody] ViewWarningFoodsRequest request)
        {
            if ((request.AllergyIds == null || request.AllergyIds.Count == 0) &&
                (request.DiseaseIds == null || request.DiseaseIds.Count == 0))
            {
                return BadRequest("At least one allergy or disease ID is required.");
            }

            var result = await _foodService.GetWarningFoods(request);
            return Ok(result);
        }

        [HttpPost("view-warning-foods-by-allergiy-ids")]
        public async Task<IActionResult> ViewWarningFoodsByAllergyIds([FromBody] List<Guid> diseaseIds)
        {
            if (diseaseIds == null || diseaseIds.Count == 0)
                return BadRequest("At least one disease ID is required.");

            var result = await _foodService.GetWarningFoodsByDiseases(diseaseIds);
            return Ok(result);
        }

        [HttpPost("view-warning-foods")]
        public async Task<IActionResult> ViewWarningFoods([FromBody] List<Guid> allergyIds)
        {
            if (allergyIds == null || allergyIds.Count == 0)
                return BadRequest("At least one allergy ID is required.");

            var result = await _foodService.GetWarningFoodsByAllergies(allergyIds);
            return Ok(result);
        }

        [HttpGet("view-food-by-id")]
        public async Task<IActionResult> GetById([FromQuery] Guid foodId)
        {
            return Ok(await _foodService.GetFoodByIdAsync(foodId));
        }

        [HttpPost("add-food")]
        public async Task<IActionResult> Create(CreateFoodRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest("Name is required");

            if (string.IsNullOrWhiteSpace(request.Description))
                return BadRequest("Description is required");

            if (request.FoodCategoryId == Guid.Empty)
                return BadRequest("FoodCategoryId is required");

            try
            {
                var result = await _foodService.CreateFood(request);
                if (result.Error == 1)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update-food")]
        public async Task<IActionResult> Update([FromBody] UpdateFoodRequest request)
        {
            if (request.Id == Guid.Empty)
                return BadRequest("Food Id is null or empty");

            if (string.IsNullOrEmpty(request.Name))
                return BadRequest("Name is null or empty");

            if (string.IsNullOrEmpty(request.Description))
                return BadRequest("Description is null or empty");

            try
            {
                var result = await _foodService.UpdateFood(request);
                if (result.Error == 1)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update-food-image")]
        public async Task<IActionResult> UpdateFoodImage(UpdateFoodImageRequest request)
        {
            if (request.Id == Guid.Empty)
                return BadRequest("Food Id is null or empty");
            if (request.image is not null)
                if (request.image.Length < 0 && request.image.Length >= 5 * 1024 * 1024)
                    return
                        BadRequest("Image must be smaller than 5mb");
            try
            {
                var result = await _foodService.UpdateFoodImage(request);
                if (result.Error == 1)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update-food-nutrient")]
        public async Task<IActionResult> UpdateFoodNutrient([FromBody] UpdateFoodNutrientRequest request)
        {
            if (request.FoodId == Guid.Empty)
                return BadRequest("Food Id is null or empty");

            if (request.NutrientId == Guid.Empty)
                return BadRequest("Nutrient Id is null or empty");

            if (request.NutrientEquivalent <= 0)
                return BadRequest("NutrientEquivalent must be greater than zero");

            if (string.IsNullOrEmpty(request.Unit))
                return BadRequest("Unit is null or empty");

            if (request.AmountPerUnit <= 0)
                return BadRequest("AmountPerUnit must be greater than zero");

            if (request.TotalWeight <= 0)
                return BadRequest("TotalWeight must be greater than zero");

            try
            {
                var result = await _foodService.UpdateFoodNutrient(request);
                if (result.Error == 1)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("soft-delete-food-by-id")]
        public async Task<IActionResult> SoftDelete([FromQuery] Guid foodId)
        {
            if (foodId == Guid.Empty)
                return BadRequest("Food Id is null or empty");

            try
            {
                if (!await _foodService.SoftDeleteFood(foodId))
                    return BadRequest("Soft delete fail");

                return Ok("Soft delete success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("delete-food-by-id")]
        public async Task<IActionResult> Delete([FromQuery] Guid foodId)
        {
            if (foodId == Guid.Empty)
                return BadRequest("Food Id is null or empty");

            try
            {
                if (!await _foodService.DeleteFood(foodId))
                    return BadRequest("Soft delete fail");

                return Ok("Soft delete success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("delete-food-nutrient-by-foodId-nutrientId")]
        public async Task<IActionResult> DeleteFoodNutrient([FromQuery] RemoveFoodNutrientRequest request)
        {
            if (request.FoodId == Guid.Empty)
                return BadRequest("Food Id is null or empty");
            if (request.NutrientId == Guid.Empty)
                return BadRequest("Nutrient Id is null or empty");

            try
            {
                var result = await _foodService.RemoveFoodNutrient(request);
                if (result.Error == 1)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("add-nutrients-to-food")]
        public async Task<IActionResult> AddNutrients(AddNutrientsRequest request)
        {
            if (request.FoodId == Guid.Empty)
                return BadRequest("Food Id is null or empty");

            if (request.Nutrients == null || request.Nutrients.Count == 0)
                return BadRequest("Nutrient list cannot be null or empty");

            // Check each nutrient entry
            foreach (var nutrient in request.Nutrients)
            {
                if (!nutrient.NutrientId.HasValue || nutrient.NutrientId == Guid.Empty)
                {
                    return BadRequest("Each nutrient must have either an Id or a Name (or both).");
                }

                // You can also validate numeric values if needed
                if (nutrient.NutrientEquivalent < 0 || nutrient.AmountPerUnit < 0 || nutrient.TotalWeight < 0)
                {
                    return BadRequest("Numeric nutrient values cannot be negative.");
                }
            }

            try
            {
                var result = await _foodService.AddNutrientsByNames(request);
                if (result.Error == 1)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}