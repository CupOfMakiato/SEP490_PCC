namespace Server.Domain.Entities
{
    public class NutrientSuggestion : BaseEntity
    {
        public string NutrientSuggestionName { get; set; } = string.Empty;
        public List<NutrientSuggestionAttribute> NutrientSuggestionAttributes { get; set; } = new List<NutrientSuggestionAttribute>();
    }
}
