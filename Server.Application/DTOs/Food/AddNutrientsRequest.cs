namespace Server.Application.DTOs.Food
{
    public class AddNutrientsRequest
    {
        public Guid FoodId { get; set; }
        public List<AddNutrientDetail> Nutrients { get; set; }
    }
}
