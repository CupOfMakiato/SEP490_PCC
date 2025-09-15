using Server.Domain.Enums;

namespace Server.Application.DTOs.Meal
{
    public class MealsSuggestionRequest
    {
        public int Stage { get; set; }
        public string? DateOfBirth { get; set; }
        public MealType Type { get; set; }
        public int NumberOfDishes { get; set; }
        public List<Guid>? allergyIds { get; set; }
        public List<Guid>? diseaseIds { get; set; }
        public Guid? favouriteDishId { get; set; }
    }
}
