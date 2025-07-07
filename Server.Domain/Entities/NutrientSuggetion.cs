namespace Server.Domain.Entities
{
    public class NutrientSuggetion : BaseEntity
    {
        public float? MaxEnergyPercentage { get; set; }
        public float? MinEnergyPercentage { get; set; }
        public float? MaxValuePerDay { get; set; }
        public float? MinValuePerDay { get; set; }
        public string Unit {  get; set; }
        public double Amount { get; set; }
        public int Trimester {  get; set; }
        public float EnergyPercentageAddingBaseOnTrimester {  get; set; }
        public float ValueAddingBaseOnTrimester {  get; set; }
        public Guid AgeGroudId { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public EnergySuggestion EnergySuggestion { get; set; }
        public Nutrient Nutrient { get; set; }
        public int Type { get; set; }
    }
}
