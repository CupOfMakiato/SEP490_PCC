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
            CreateMap<Dish, DishDto>()
    .ForMember(dest => dest.Calories, opt => opt.Ignore()) // we’ll set manually
    .AfterMap((src, dest, ctx) =>
    {
        if (ctx.Items.TryGetValue("CaloriesId", out var caloriesIdObj)
            && caloriesIdObj is Guid caloriesId)
        {
            dest.Calories = src.Foods
                .SelectMany(fd => fd.Food.FoodNutrients
                    .Where(fn => fn.NutrientId == caloriesId)
                    .Select(fn => fn.AmountPerUnit * fd.Amount))
                .Sum();
        }
    });


        }
    }
}
