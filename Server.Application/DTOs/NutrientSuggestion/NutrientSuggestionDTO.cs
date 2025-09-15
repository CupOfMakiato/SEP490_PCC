namespace Server.Application.DTOs.NutrientSuggestion
{
    public class NutrientSuggestionDTO
    {
        public Guid Id { get; set; }
        public string NutrientSuggetionName { get; set; }
        public List<NutrientSuggestionAttributeDTO> NutrientSuggestionAttributes { get; set; }
    }
}
