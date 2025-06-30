namespace Server.Application.DTOs.Nutrient
{
    public class CreateNutrientRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Unit { get; set; }
        public Guid CategoryId { get; set; }
    }
}
