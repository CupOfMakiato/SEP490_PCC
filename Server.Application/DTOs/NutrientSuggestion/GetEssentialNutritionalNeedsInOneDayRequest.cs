namespace Server.Application.DTOs.NutrientSuggestion
{
    public class GetEssentialNutritionalNeedsInOneDayRequest
    {
        public int currentWeek { get; set; }
        public string? dateOfBith { get; set; }
        public int? activityLevel { get; set; }
    }
}
