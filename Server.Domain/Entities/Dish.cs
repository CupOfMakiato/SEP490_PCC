namespace Server.Domain.Entities
{
    public class Dish : BaseEntity
    {
        public string DishName { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public List<DishMeal> DishMeals { get; set; }
        public List<HistoryDish> HistoryDish { get; set; } = new List<HistoryDish>();
        public List<FoodDish> Foods { get; set; } 
    }
}
