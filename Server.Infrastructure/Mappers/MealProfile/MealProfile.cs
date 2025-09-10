using AutoMapper;
using Server.Application.DTOs.Dish;
using Server.Application.DTOs.Meal;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.MealProfile
{
    public class MealProfile : Profile
    {
        public MealProfile()
        {
            CreateMap<Meal, MealDto>().ReverseMap();        
            CreateMap<Meal, GetMealResponse>().ReverseMap();        
            CreateMap<DishMeal, Application.DTOs.Meal.DishMealDTO>().ReverseMap();        
        }
    }
}
