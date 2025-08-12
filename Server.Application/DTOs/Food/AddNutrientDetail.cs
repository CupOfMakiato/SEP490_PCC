namespace Server.Application.DTOs.Food
{
    public class AddNutrientDetail
    {
        public Guid? NutrientId { get; set; } // nullable so we can send name only
        public double NutrientEquivalent { get; set; }
        public string Unit { get; set; }
        public double AmountPerUnit { get; set; }
        public double TotalWeight { get; set; }
        public string FoodEquivalent { get; set; }
    }
}
