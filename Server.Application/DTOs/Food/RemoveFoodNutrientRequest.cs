namespace Server.Application.DTOs.Food
{
    public class RemoveFoodNutrientRequest
    {
        public Guid FoodId { get; set; }
        public Guid NutrientId { get; set; }
    }
}
