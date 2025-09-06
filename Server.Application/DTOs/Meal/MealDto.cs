using Server.Application.DTOs.Dish;
using Server.Domain.Enums;

namespace Server.Application.DTOs.Meal
{
    public class MealDto
    {
        public MealType MealType { get; set; }
        public double TotalCalories { get; set; }
        public List<DishDto> Dishes { get; set; } = new();
    }
}
