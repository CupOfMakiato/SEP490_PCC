namespace Server.Domain.Entities
{
    public class NutrientSuggestionAttribute
    {
        public Guid NutrientSuggestionAttributeId { get; set; }
        public Guid NutrientSuggestionId { get; set; } // Fix the typo here from "NutrientSuggetionId"
        public NutrientSuggestion NutrientSuggestion { get; set; }
        public Guid AttributeId { get; set; }
        public NSAttribute Attribute { get; set; }
        public Guid? AgeGroupId { get; set; }
        public AgeGroup? AgeGroup { get; set; }
        public int Trimester { get; set; }
    }
}
