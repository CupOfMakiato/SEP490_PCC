namespace Server.Domain.Entities
{
    public class Meal : BaseEntity
    {
        public int Trimester { get; set; }
        public List<DishMeal> DishMeals { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }
}
