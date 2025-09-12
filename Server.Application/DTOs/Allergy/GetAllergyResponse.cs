namespace Server.Application.DTOs.Allergy
{
    public class GetAllergyResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid AllergyCategoryId { get; set; }
        public string CommonSymptoms { get; set; } = string.Empty;
        public string PregnancyRisk { get; set; } = string.Empty;
        public string AllergyCategoryName { get; set; } = string.Empty;
    }
}
