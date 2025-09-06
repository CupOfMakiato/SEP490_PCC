using AutoMapper;
using Server.Application.DTOs.Dish;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.DishProfile
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<FoodDish, FoodDishDTO>().ReverseMap();
            CreateMap<GetFoodDishRequest, FoodDish>().ReverseMap().ForMember(dest => dest.FoodName, opt => opt.MapFrom(src => src.Food.Name));
            CreateMap<DishMeal, DishMealDTO>().ReverseMap();
            CreateMap<Dish, GetDishResponse>().ReverseMap();

        }
    }
}
