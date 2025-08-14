namespace Server.Application.DTOs.Meal
{
    public class CreateMealRequest
    {
        public int Trimester { get; set; }
        public List<DishMealDTO> DishMeals{ get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }
}
