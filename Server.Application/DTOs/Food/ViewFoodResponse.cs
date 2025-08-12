using Server.Domain.Entities;

namespace Server.Application.DTOs.Food
{
    public class ViewFoodResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool PregnancySafe { get; set; }
        public Guid FoodCategoryId { get; set; }
        public string SafetyNote { get; set; }
        public ICollection<FoodNutrientDTO>? FoodNutrients { get; set; } = new List<FoodNutrientDTO>();
    }
}
