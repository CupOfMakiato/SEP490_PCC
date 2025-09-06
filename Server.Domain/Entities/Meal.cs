using Server.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Domain.Entities
{
    public class Meal : BaseEntity
    {
        public MealType MealType { get; set; }
        public List<DishMeal> DishMeals { get; set; }

        [NotMapped]
        public double TotalCalories { get; set; }
    }
}
