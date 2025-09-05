using Microsoft.AspNetCore.Http;

namespace Server.Application.DTOs.Food
{
    public class UpdateFoodImageRequest
    {
        public Guid Id { get; set; }
        public IFormFile? image { get; set; }
    }
}
