using Microsoft.AspNetCore.Http;

namespace Server.Application.DTOs.Nutrient
{
    public class UpdateNutrientImageRequest
    {
        public Guid Id { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}
