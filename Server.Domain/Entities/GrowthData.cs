namespace Server.Domain.Entities
{
    public class GrowthData : BaseEntity
    {
        public DateTime DateOfPregnancy { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public DateTime FirstDayOfLastMenstrualPeriod { get; set; }
        public int GestationalAgeInWeeks { get; set; }
        public DateTime EstimatedDueDate { get; set; }
        public IEnumerable<FoodRecommendationHistory> FoodRecommendationHistories { get; set; }
        public User GrowthDataCreatedBy { get; set; }
        public ICollection<DiseaseGrowthData> DiseaseGrowthData { get; set; } = new List<DiseaseGrowthData>();
        public Journal Journal { get; set; }
        //public Fetus Fetus { get; set; }

        public int CurrentTrimester()
        {
            return GestationalAgeInWeeks switch
            {
                < 14 => 1,
                < 28 => 2,
                _ => 3
            };
        }
        public int GetCurrentGestationalAgeInWeeks(DateTime currentDate)
        {
            var weeks = (currentDate.Date - FirstDayOfLastMenstrualPeriod.Date).Days / 7;
            return Math.Clamp(weeks, 0, 40);
        }
    }
}
