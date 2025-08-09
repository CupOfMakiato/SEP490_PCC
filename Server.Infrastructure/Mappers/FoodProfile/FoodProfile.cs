using AutoMapper;
using Server.Application.DTOs.Food;
using Server.Application.DTOs.Nutrient;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.FoodProfile
{
    public class FoodProfile : Profile
    {
        public FoodProfile()
        {
            CreateMap<FoodDTO, Food>().ReverseMap();
        }
    }
}
