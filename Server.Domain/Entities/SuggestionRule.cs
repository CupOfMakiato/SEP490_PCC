namespace Server.Domain.Entities
{
    public class SuggestionRule : BaseEntity
    {
        public int Trimester { get; set; }
        public int AgeRange { get; set; }
        public double PercentageOfEnergyRecommend { get; set; }
        public double PercentageOfEnergy { get; set; }
        public string Condition { get; set; }
        public string Note { get; set; }

        public ICollection<Food> Foods { get; set; }

        public ICollection<Disease> Diseases { get; set; }

        public bool IsPositive { get; set; }
        public Guid NutrientCategoryId { get; set; }
        public NutrientCategory NutrientCategory { get; set; } = new NutrientCategory();
        public Guid NutrientId { get; set; }
        public Nutrient Nutrient { get; set; } = new Nutrient();
    }
}
