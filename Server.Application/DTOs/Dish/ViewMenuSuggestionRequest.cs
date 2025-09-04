using Server.Domain.Enums;

namespace Server.Application.DTOs.Dish
{
    public class ViewMenuSuggestionRequest
    {
        public int Stage { get; set; } // pregnancy week
        public MealType MealType { get; set; } // Breakfast, Lunch, Dinner, Snack1, Snack2
        public DateTime? DateOfBirth { get; set; } // optional, used to resolve AgeGroupId
        public List<Guid>? ListFavouriteDishesId { get; set; }
        public List<Guid>? AllergyIds { get; set; } = new();
        public List<Guid>? DiseaseIds { get; set; } = new();
    }
}
