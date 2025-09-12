namespace Server.Domain.Entities
{
    public class AgeGroup : BaseEntity
    {
        public int FromAge { get; set; }
        public int ToAge { get; set; }
        public List<EnergySuggestion> EnergySuggestions { get; set; } = new List<EnergySuggestion>();
        public List<NutrientSuggestion> NutrientSuggestions { get; set; } = new List<NutrientSuggestion>();
    }
}
