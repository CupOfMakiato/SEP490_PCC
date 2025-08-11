namespace Server.Application.DTOs.AllergyCategory
{
    public class UpdateAllergyCategoryRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
