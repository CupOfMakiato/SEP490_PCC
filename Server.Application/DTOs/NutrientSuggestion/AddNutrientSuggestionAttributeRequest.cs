namespace Server.Application.DTOs.NutrientSuggestion
{
    public class AddNutrientSuggestionAttributeRequest
    {
        public Guid NutrientSuggetionId { get; set; }
        public Guid? AgeGroudId { get; set; }
        public int Trimester { get; set; }
        public float? MaxEnergyPercentage { get; set; }
        public float? MinEnergyPercentage { get; set; }
        //g/day
        public float? MaxValuePerDay { get; set; }
        public float? MinValuePerDay { get; set; }
        //g/kg/day
        public string Unit { get; set; }
        public double Amount { get; set; }
        public float? MinAnimalProteinPercentageRequire { get; set; }
        public Guid NutrientId  { get; set; }
        public int Type { get; set; }
    }
}
