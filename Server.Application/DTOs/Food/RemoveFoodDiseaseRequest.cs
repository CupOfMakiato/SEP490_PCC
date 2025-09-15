namespace Server.Application.DTOs.Food
{
    public class RemoveFoodDiseaseRequest
    {
        public Guid FoodId { get; set; }
        public Guid DiseaseId { get; set; }
    }
}
