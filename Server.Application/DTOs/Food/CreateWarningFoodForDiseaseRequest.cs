namespace Server.Application.DTOs.Food
{
    public class CreateWarningFoodForDiseaseRequest
    {
        public Guid DiseaseId { get; set; }
        public List<FoodDiseaseWarningDto> warningFoodDtos { get; set; }
    }
}
