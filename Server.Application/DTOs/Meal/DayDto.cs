namespace Server.Application.DTOs.Meal
{
    public class DayDto
    {
        public DayOfWeek DayOfWeek { get; set; }
        public List<MealDto> Meals { get; set; } = new();
    }
}
