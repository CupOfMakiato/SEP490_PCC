namespace Server.Application.DTOs.NutrientCategory
{
    public class UpdateNutrientCategoryRequest
    {
        public Guid NutrientCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
