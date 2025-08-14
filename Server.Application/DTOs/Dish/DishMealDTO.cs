using Server.Domain.Enums;

namespace Server.Application.DTOs.Dish
{
    public class DishMealDTO
    {
        public Guid MealId { get; set; }
        public MealType MealType { get; set; } //Breakfast, Lunch, Snack, etc.
    }
}
