namespace Server.Application.DTOs.Dish
{
    public class UpdateDishRequest
    {
        public Guid dishID { get; set; }
        public List<FoodDishDto> foodList {  get; set; }
    }
}
