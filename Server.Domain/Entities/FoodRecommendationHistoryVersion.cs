namespace Server.Domain.Entities
{
    public class FoodRecommendationHistoryVersion
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime FirstDateOfPregnancy { get; set; }
        public Guid FoodRecommendationHistoryId { get; set; }
        public FoodRecommendationHistory FoodRecommendationHistory { get; set; }
    }
}
