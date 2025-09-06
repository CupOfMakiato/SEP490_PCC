using Server.Domain.Entities;

namespace Server.Application.DTOs.Food
{
    public class ViewWarningFoodsResponse
    {
        public string Name { get; set; }
        public string FoodDescription { get; set; }
        public string? ImageUrl { get; set; }
        public bool PregnancySafe { get; set; }
        public string SafetyNote { get; set; }
        public ICollection<FoodNutrientDTO>? FoodNutrients { get; set; } = new List<FoodNutrientDTO>();
        public ICollection<FoodDiseaseDto>? FoodDisease { get; set; } = new List<FoodDiseaseDto>();
        public ICollection<FoodAllergyDto>? FoodAllergy { get; set; } = new List<FoodAllergyDto>();
    }
}
