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

            CreateMap<FoodNutrient, FoodNutrientDTO>()
           .ForMember(dest => dest.NutrientName, opt => opt.MapFrom(src => src.Nutrient.Name))
           .ForMember(dest => dest.NutrientId, opt => opt.MapFrom(src => src.NutrientId))
           .ForMember(dest => dest.NutrientEquivalent, opt => opt.MapFrom(src => src.NutrientEquivalent))
           .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit))
           .ForMember(dest => dest.AmountPerUnit, opt => opt.MapFrom(src => src.AmountPerUnit))
           .ForMember(dest => dest.TotalWeight, opt => opt.MapFrom(src => src.TotalWeight))
           .ForMember(dest => dest.FoodEquivalent, opt => opt.MapFrom(src => src.FoodEquivalent));

            // Map từ Food → ViewFoodRequest
            CreateMap<Food, ViewFoodResponse>()
                .ForMember(dest => dest.FoodNutrients, opt => opt.MapFrom(src => src.FoodNutrients));
        }
    }
}
