using AutoMapper;
using Server.Application.DTOs.Nutrient;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.NutrientProfile
{
    public class NutrientProfile : Profile
    {
        public NutrientProfile()
        {
            CreateMap<NutrientDTO, Nutrient>().ReverseMap();
        }        
    }
}
