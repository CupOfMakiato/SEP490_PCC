namespace Server.Application.DTOs.NutrientSuggestion
{
    public class UpdateNutrientSuggestionRequest
    {
        public Guid Id { get; set; }
        public string NutrientSuggetionName { get; set; }
    }
}
