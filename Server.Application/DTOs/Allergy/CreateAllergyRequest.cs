namespace Server.Application.DTOs.Allergy
{
    public class CreateAllergyRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid AllergyCategoryId { get; set; }
        public string CommonSymptoms { get; set; }
        public string PregnancyRisk { get; set; }
    }
}
