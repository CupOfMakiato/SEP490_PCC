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

            //ViewWarningFoodsResponse
            CreateMap<Food, ViewWarningFoodsResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.FoodDescription, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            .ForMember(dest => dest.PregnancySafe, opt => opt.MapFrom(src => src.PregnancySafe))
            .ForMember(dest => dest.SafetyNote, opt => opt.MapFrom(src => src.SafetyNote))
            .ForMember(dest => dest.FoodDisease, opt => opt.MapFrom(src => src.FoodDiseases))
            .ForMember(dest => dest.FoodAllergy, opt => opt.MapFrom(src => src.FoodAllergies));

            CreateMap<FoodNutrient, FoodNutrientDTO>()
                .ForMember(dest => dest.NutrientId, opt => opt.MapFrom(src => src.NutrientId))
                .ForMember(dest => dest.NutrientName, opt => opt.MapFrom(src => src.Nutrient.Name))
                .ForMember(dest => dest.NutrientEquivalent, opt => opt.MapFrom(src => src.NutrientEquivalent))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit))
                .ForMember(dest => dest.AmountPerUnit, opt => opt.MapFrom(src => src.AmountPerUnit))
                .ForMember(dest => dest.TotalWeight, opt => opt.MapFrom(src => src.TotalWeight))
                .ForMember(dest => dest.FoodEquivalent, opt => opt.MapFrom(src => src.FoodEquivalent));

            CreateMap<FoodDisease, FoodDiseaseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DiseaseId))
                .ForMember(dest => dest.DiseaseName, opt => opt.MapFrom(src => src.Disease.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<FoodAllergy, FoodAllergyDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AllergyId))
                .ForMember(dest => dest.AllergyName, opt => opt.MapFrom(src => src.Allergy.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
