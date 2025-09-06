namespace Server.Application.DTOs.Dish
{
    public class UpdateDishRequest
    {
        public Guid dishID { get; set; }
        public string DishName { get; set; }
        public string? Description { get; set; }
        public List<FoodDishDTO> foodList {  get; set; }
    }
}
