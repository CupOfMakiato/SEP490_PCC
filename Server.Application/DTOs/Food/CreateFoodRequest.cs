using Server.Domain.Entities;

namespace Server.Application.DTOs.Food
{
    public class CreateFoodRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool PregnancySafe { get; set; }
        public Guid FoodCategoryId { get; set; }
        public string SafetyNote { get; set; }
        public bool Review { get; set; } = false;
        public List<string> FoodNutrientNames { get; set; }
    }
}
