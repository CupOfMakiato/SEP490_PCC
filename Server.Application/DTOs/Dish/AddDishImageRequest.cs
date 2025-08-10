using Microsoft.AspNetCore.Http;

namespace Server.Application.DTOs.Dish
{
    public class AddDishImageRequest
    {
        public Guid dishId {  get; set; }
        public IFormFile Image { get; set; }
    }
}
