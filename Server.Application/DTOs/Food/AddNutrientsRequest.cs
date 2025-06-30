namespace Server.Application.DTOs.Food
{
    public class AddNutrientsRequest
    {
        public Guid FoodId { get; set; }
        public List<string> NutrientsNames = new List<string>();
    }
}
