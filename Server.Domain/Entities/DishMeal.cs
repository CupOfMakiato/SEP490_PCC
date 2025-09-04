using Server.Domain.Enums;

namespace Server.Domain.Entities
{
    public class DishMeal
    {
        public Guid MealId { get; set; }
        public Meal Meal { get; set; }

        public Guid DishId { get; set; }
        public Dish Dish { get; set; }

    }
}
