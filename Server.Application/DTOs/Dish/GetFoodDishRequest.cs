namespace Server.Application.DTOs.Dish
{
    public class GetFoodDishRequest
    {
        public Guid FoodId { get; set; }
        public string FoodName { get; set; }
        public string Unit { get; set; }
        public double Amount { get; set; }
    }
}
