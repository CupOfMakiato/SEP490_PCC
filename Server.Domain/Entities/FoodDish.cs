namespace Server.Domain.Entities
{
    public class FoodDish
    {
        public Guid FoodId { get; set; }
        public Food Food { get; set; }

        public Guid DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
