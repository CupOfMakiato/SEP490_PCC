using Server.Domain.Enums;

namespace Server.Application.DTOs.Food
{
    public record FoodDiseaseWarningDto
    {
        public Guid FoodId { get; set; }
        public string Description { get; set; }
    }
}
