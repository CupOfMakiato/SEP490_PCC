namespace Server.Application.DTOs.NutrientSuggestion
{
    public class NutrientSuggestionDTO
    {
        public Guid Id { get; set; }
        public string NutrientSuggestionName { get; set; }
        public List<NutrientSuggestionAttributeDTO> NutrientSuggestionAttributes { get; set; }
    }
}
