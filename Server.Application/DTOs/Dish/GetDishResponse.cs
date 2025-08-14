using Server.Domain.Entities;

namespace Server.Application.DTOs.Dish
{
    public class GetDishResponse
    {
        public Guid Id { get; set; }
        public string? ImageUrl { get; set; }
        public List<DishMealDTO> DishMeals { get; set; }
        public List<GetFoodDishRequest> Foods { get; set; }
    }
}
