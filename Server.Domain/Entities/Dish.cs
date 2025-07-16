namespace Server.Domain.Entities
{
    public class Dish : BaseEntity
    {
        public List<DishMeal> DishMeals { get; set; }
        public List<HistoryDish> HistoryDish { get; set; } = new List<HistoryDish>();
        public List<FoodDish> Foods { get; set; }
    }
}
