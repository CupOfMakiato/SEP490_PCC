using Microsoft.AspNetCore.Http;

namespace Server.Application.DTOs.Dish
{
    public class CreateDishRequest
    {
        public string DishName { get; set; }
        public IFormFile? Image { get; set; }
        public string? Description { get; set; }
        public List<FoodDishDTO> foodList {  get; set; }
    }
}
