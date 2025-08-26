namespace Server.Application.DTOs.Allergy
{
    public class GetAllergyResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid AllergyCategoryId { get; set; }
        public string CommonSymptoms { get; set; }
        public string PregnancyRisk { get; set; }
        public string AllergyCategoryName { get; set; }
    }
}
