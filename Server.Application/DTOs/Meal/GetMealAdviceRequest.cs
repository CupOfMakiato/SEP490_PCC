using Server.Domain.Enums;

namespace Server.Application.DTOs.Meal
{
    public class GetMealAdviceRequest
    {
        public int Stage { get; set; }
        public MealType MealType { get; set; }
        public int NumberOfDishes { get; set; }
        public Guid? FavouriteDishId { get; set; }
    }
}
