namespace Server.Domain.Entities
{
    public class NutrientCategory : BaseEntity
    {
        public string Name { get; set; }    
        public string Description { get; set; } = string.Empty;
        public SuggestionRule SuggestionRule { get; set; }
        public IEnumerable<Nutrient> Nutrients { get; set; }
    }
}
