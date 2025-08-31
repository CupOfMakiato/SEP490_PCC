using AutoMapper;
using Server.Application.DTOs.Allergy;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.AllergyProfile
{
    public class AllergyProfile : Profile
    {
        public AllergyProfile()
        {
            CreateMap<Allergy, GetAllergyResponse>()
                .ForMember(dest => dest.AllergyCategoryName,
                    opt => opt.MapFrom(src => src.AllergyCategory.Name));

            CreateMap<CreateAllergyRequest, Allergy>();
            CreateMap<UpdateAllergyRequest, Allergy>();
        }
    }

}
