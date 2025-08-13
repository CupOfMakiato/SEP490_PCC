using Server.Domain.Enums;

namespace Server.Application.DTOs.Meal
{
    public class DishMealDTO
    {
        public Guid DishId { get; set; }
        public MealType MealType { get; set; } //Breakfast, Lunch, Snack, etc.
    }
}
