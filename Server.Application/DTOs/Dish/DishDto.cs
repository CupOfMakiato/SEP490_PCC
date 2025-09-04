namespace Server.Application.DTOs.Dish
{
    public class DishDto
    {
        public Guid Id { get; set; }
        public string DishName { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public double Calories { get; set; }
    }
}
