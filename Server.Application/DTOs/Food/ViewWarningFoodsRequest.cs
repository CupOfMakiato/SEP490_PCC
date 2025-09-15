namespace Server.Application.DTOs.Food
{
    public class ViewWarningFoodsRequest
    {
        public List<Guid>? AllergyIds { get; set; } = new List<Guid>();
        public List<Guid>? DiseaseIds { get; set; } = new List<Guid>();
    }
}
