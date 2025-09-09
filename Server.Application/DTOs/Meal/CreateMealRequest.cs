using Server.Domain.Enums;

namespace Server.Application.DTOs.Meal
{
    public class CreateMealRequest
    {
        public List<DishMealDTO> DishMeals{ get; set; }
        public MealType MealType { get; set; }
    }
}
  