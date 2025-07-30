namespace Server.Application.DTOs.EnergySuggestion
{
    public class UpdateEnergySuggestionRequest
    {
        public Guid Id { get; set; }
        public int ActivityLevel { get; set; }
        public double BaseCalories { get; set; }
        public int Trimester { get; set; }
        public double AdditionalCalories { get; set; }
        public Guid AgeGroupId { get; set; }
    }
}
