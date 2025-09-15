namespace Server.Application.DTOs.Food
{
    public class CreateWarningFoodForAllergyRequest
    {
        public Guid AllergyId { get; set; }
        public List<FoodDiseaseWarningDto> warningFoodDtos { get; set; }
    }
}
