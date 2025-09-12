using AutoMapper;
using Server.Application.DTOs.NutrientSuggestion;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.NutrientSuggestionProfile
{  
    public class NutrientSuggestionProfile : Profile
    {
        public NutrientSuggestionProfile()
        {
            // NutrientSuggetion <-> NutrientSuggetionDTO
            CreateMap<NutrientSuggestion, NutrientSuggestionDTO>()
                .ForMember(dest => dest.NutrientSuggestionAttributes, opt => opt.MapFrom(src => src.NutrientSuggestionAttributes));

            CreateMap<NutrientSuggestionDTO, NutrientSuggestion>()
                .ForMember(dest => dest.NutrientSuggestionAttributes, opt => opt.MapFrom(src => src.NutrientSuggestionAttributes));

            // NutrientSuggestionAttribute <-> NutrientSuggestionAttributeDTO
            CreateMap<NutrientSuggestionAttribute, NutrientSuggestionAttributeDTO>()
                .ForMember(dest => dest.Attribute, opt => opt.MapFrom(src => src.Attribute));

            CreateMap<NutrientSuggestionAttributeDTO, NutrientSuggestionAttribute>()
                .ForMember(dest => dest.Attribute, opt => opt.MapFrom(src => src.Attribute));

            // NSAttribute <-> NSAttributeDTO
            CreateMap<NSAttribute, NSAttributeDTO>()
                .ForMember(dest => dest.NutrientName, opt => opt.MapFrom(src => src.Nutrient.Name));

            CreateMap<NSAttributeDTO, NSAttribute>()
                .ForMember(dest => dest.Nutrient, opt => opt.Ignore()); // prevent circular mapping

            // Nutrient <-> NutrientDTO (if needed)
            // You don’t have a NutrientDTO, so just ignore for now
        }
    }

}
