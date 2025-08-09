namespace Server.Application.DTOs.Food
{
    public class UpdateFoodNutrientRequest
    {
        public Guid FoodId { get; set; }
        public Guid NutrientId { get; set; }
        public double NutrientEquivalent { get; set; } // 1 đơn vị thì tương đương bao nhiêu (g) vitamin (ex: Glucid)
        public string Unit { get; set; }
        public double AmountPerUnit { get; set; } // lượng dinh dưỡng trong 1 đơn vị thực phẩm (g)
        public double TotalWeight { get; set; }   // trọng lượng kể cả thải bỏ (g)
        public string FoodEquivalent { get; set; } // chén cơm hay hạt đậu gì đó
    }
}
