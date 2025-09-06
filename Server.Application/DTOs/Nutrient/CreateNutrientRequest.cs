using Microsoft.AspNetCore.Http;

namespace Server.Application.DTOs.Nutrient
{
    public class CreateNutrientRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
    }
}
