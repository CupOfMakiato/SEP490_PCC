namespace Server.Application.DTOs.Meal
{
    public class ViewMenuSuggestionRequest
    {
        public int Stage { get; set; }
        public List<Guid>? ListFavouriteDishesId { get; set; }
    }
}
