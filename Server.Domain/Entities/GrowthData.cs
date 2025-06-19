namespace Server.Domain.Entities
{
    public class GrowthData : BaseEntity
    {
        public DateTime FirstDateOfPregnancy { get; set; }
        public int Week { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Note { get; set; }
        public IEnumerable<FoodRecommendationHistory> FoodRecommendationHistories { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<DiseaseGrowthData> DiseaseGrowthData { get; set; } = new List<DiseaseGrowthData>();
    }
}
