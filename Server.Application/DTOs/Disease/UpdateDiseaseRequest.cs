namespace Server.Application.DTOs.Disease
{
    public class UpdateDiseaseRequest : CreateDiseaseRequest
    {
        public Guid DiseaseId { get; set; }
    }
}
