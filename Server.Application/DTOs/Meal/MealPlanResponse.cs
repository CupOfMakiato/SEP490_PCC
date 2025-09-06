namespace Server.Application.DTOs.Meal
{
    public class MealPlanResponse
    {
        public double TargetCalories { get; set; }
        public List<DayDto> Days { get; set; } = new();
    }
}
