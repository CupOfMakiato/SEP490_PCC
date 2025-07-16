using System.ComponentModel.DataAnnotations;


namespace Server.Domain.Entities
{
    public class FoodNutrient
    {
        [Key]
        public Guid FoodId { get; set; }
        [Key]
        public Guid NutrientId { get; set; }
        public double NutrientEquivalent { get; set; } // 1 đơn vị thì tương đương bao nhiêu (g) vitamin (ex: Glucid)
        public string Unit { get; set; }
        public double AmountPerUnit { get; set; } // lượng dinh dưỡng trong 1 đơn vị thực phẩm (g)
        public double TotalWeight { get; set; }   // trọng lượng kể cả thải bỏ (g)
        public string FoodEquivalent { get; set; }
        public Nutrient Nutrient { get; set; }
        public Food Food { get; set; }
    }
}
