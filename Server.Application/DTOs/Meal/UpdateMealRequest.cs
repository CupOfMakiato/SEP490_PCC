using Server.Application.DTOs.Dish;
using Server.Domain.Enums;

namespace Server.Application.DTOs.Meal
{
    public class UpdateMealRequest
    {
        public MealType MealType { get; set; }
        public List<DishMealDTO> DishMeals { get; set; }
    }
}
