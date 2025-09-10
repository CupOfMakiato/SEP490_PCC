namespace Server.Application.DTOs.Food
{
    public class RemoveFoodAllergyRequest
    {
        public Guid FoodId { get; set; }
        public Guid AllergyId { get; set; }
    }
}
