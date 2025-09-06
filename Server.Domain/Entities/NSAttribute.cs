namespace Server.Domain.Entities
{
    public class NSAttribute : BaseEntity
    {
        //Tỷ lệ %  năng lƣợng từ Protein/ tổng năng lƣợng khẩu phần
        public float? MaxEnergyPercentage { get; set; } 
        public float? MinEnergyPercentage { get; set; }
        //g/day
        public float? MaxValuePerDay { get; set; }
        public float? MinValuePerDay { get; set; }
        //g/kg/day
        public string Unit { get; set; }
        public double Amount { get; set; }
        public float? MinAnimalProteinPercentageRequire { get; set; }
        public Guid NutrientId { get; set; }
        public Nutrient Nutrient { get; set; }
        public int Type { get; set; }
        public List<NutrientSuggestionAttribute> NutrientSuggestionAttributes { get; set; }
    }
}
