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
            .ForMember(dest => dest.Calories, opt => opt.Ignore())
            .AfterMap((src, dest, ctx) =>
            {
                dest.Calories = 0;

                if (ctx.Items.TryGetValue("CaloriesId", out var caloriesIdObj)
                    && caloriesIdObj is Guid caloriesId
                    && src.Foods != null)
                {
                    dest.Calories = src.Foods
                        .Where(fd => fd.Food?.FoodNutrients != null)
                        .SelectMany(fd => fd.Food.FoodNutrients!
                            .Where(fn => fn.NutrientId == caloriesId)
                            .Select(fn => fn.AmountPerUnit * fd.Amount))
                        .DefaultIfEmpty(0)
                        .Sum() / 100;
                }
            });
        }
    }
}
