namespace Server.Application.DTOs.Dish
{
    public class UpdateFoodInDishRequest
    {
        public Guid FoodId { get; set; }
        public Guid DishId { get; set; }
        public string Unit { get; set; }
        public double Amount { get; set; }
    }
}
