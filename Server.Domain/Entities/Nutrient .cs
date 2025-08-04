namespace Server.Domain.Entities
{
    public class Nutrient : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public string ImageUrl { get; set; }
        public bool Review { get; set; } = false;
        public Guid CategoryId { get; set; }
        public NutrientCategory NutrientCategory { get; set; }
        public List<NSAttribute> Attributes { get; set; }
        public IEnumerable<FoodNutrient> FoodNutrients { get; set; }
    }
}
