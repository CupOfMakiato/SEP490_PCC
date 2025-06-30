using Microsoft.AspNetCore.Mvc;
using Server.Application.Interfaces;
using Server.Application.Services;

namespace Server.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodRecommendationHistoryController : ControllerBase
    {
        private readonly IFoodRecommendationHistoryService _foodRecommendationHistoryService;

        public FoodRecommendationHistoryController(IFoodRecommendationHistoryService foodRecommendationHistoryService)
        {
            _foodRecommendationHistoryService = foodRecommendationHistoryService;
        }

        //[HttpGet("/DailyRecommendation")]
        //public async Task<IActionResult> GetDailyRecommendation()
        //{
        //    await _foodRecommendationHistoryService
        //}
    }
}