using Server.Domain.Enums;

namespace Server.Application.DTOs.Food
{
    public class FoodDiseaseDto
    {
        public Guid Id { get; set; }
        public string DiseaseName { get; set; }
        public FoodDiseaseStatus Status { get; set; }
        public string Description { get; set; }
    }
}
