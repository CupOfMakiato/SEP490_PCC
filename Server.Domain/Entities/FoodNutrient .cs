using System.ComponentModel.DataAnnotations;


namespace Server.Domain.Entities
{
    public class FoodNutrient
    {
        [Key]
        public Guid FoodId { get; set; }
        [Key]
        public Guid NutrientId { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public string ReferenceQuantity { get; set; } //Định Lượng trong bao nhiêu ...
        public string ReferenceUnit { get; set; } //Đơn vị tham chiếu của food 
        public Nutrient Nutrient { get; set; }
        public Food Food { get; set; }
    }
}
