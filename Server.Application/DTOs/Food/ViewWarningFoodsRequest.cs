namespace Server.Application.DTOs.Food
{
    public class ViewWarningFoodsRequest
    {
        public List<Guid> allergyIds { get; set; }
        public List<Guid> diseaseIds { get; set; }
    }
}
