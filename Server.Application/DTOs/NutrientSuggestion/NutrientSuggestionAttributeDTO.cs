using Server.Domain.Entities;

namespace Server.Application.DTOs.NutrientSuggestion
{
    public class NutrientSuggestionAttributeDTO
    {
        public Guid NutrientSuggestionAttributeId { get; set; }
        public Guid NutrientSuggetionId { get; set; }
        public Guid AttributeId { get; set; }
        public NSAttributeDTO Attribute { get; set; }
        public Guid? AgeGroupId { get; set; }
        public int Trimester { get; set; }
    }
}
