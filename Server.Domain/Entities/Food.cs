namespace Server.Domain.Entities
{
    public class Food : BaseEntity
    {
        public string Name { get; set; }    
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool PregnancySafe { get; set; }
        public Guid FoodCategoryId { get; set; }
        public string SafetyNote { get; set; }
        public FoodCategory FoodCategory { get; set; }
        public ICollection<FoodNutrient>? FoodNutrients { get; set; } = new List<FoodNutrient>();
        public ICollection<FoodDish>? FoodDishes { get; set; } = new List<FoodDish>();
        public ICollection<FoodDisease>? FoodDiseases { get; set; } = new List<FoodDisease>();
        public ICollection<FoodAllergy>? FoodAllergies { get; set; } = new List<FoodAllergy>();
    }
}
