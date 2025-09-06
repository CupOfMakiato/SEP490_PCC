namespace Server.Application.DTOs.Meal
{
    public class MealAdviceResponse
    {
        public double TargetCalories { get; set; }
        public List<MealDto> Meals { get; set; } = new List<MealDto>();
    }
}
