using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Application.DTOs.Meal
{
    public class GetMealResponse
    {
        public Guid Id { get; set; }
        public MealType MealType { get; set; }
        public List<DishMealDTO> DishMeals { get; set; }
    }
}
