using Server.Domain.Enums;

namespace Server.Domain.Entities
{
    public class HistoryDish
    {
        public Guid DishesRecommendationHistoryId { get; set; }
        public DishesRecommendationHistory DishesRecommendationHistory { get; set; }

        public Guid DishId { get; set; }
        public Dish Dish { get; set; }

        public MealType MealType { get; set; } //Breakfast, Lunch, Snack, etc.
    }
}
