
namespace Server.Application.DTOs.Disease
{
    public class GetDiseaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Symptoms { get; set; }
        public string TreatmentOptions { get; set; }
        public bool PregnancyRelated { get; set; }
        public string RiskLevel { get; set; }
        public string TypeOfDesease { get; set; }
    }
}
