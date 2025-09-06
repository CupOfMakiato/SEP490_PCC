namespace Server.Application.DTOs.Food
{
    public class FoodDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool PregnancySafe { get; set; }
        public string SafetyNote { get; set; }
        public Guid FoodCategoryId { get; set; }
    }
}
