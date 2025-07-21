namespace Server.Domain.Entities
{
    public class NutrientSuggestionAttribute
    {
        public Guid NutrientSuggetionId { get; set; }
        public NutrientSuggetion NutrientSuggetion { get; set; }
        public Guid AttributeId { get; set; }
        public ESAttribute Attribute { get; set; }
        public Guid AgeGroudId { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public int Trimester { get; set; }
    }
}
