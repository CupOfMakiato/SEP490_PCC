using AutoMapper;
using Server.Application.DTOs.Clinic;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.ClinicProfile
{
    public class ClinicProfile : Profile
    {
        public ClinicProfile()
        {
            CreateMap<ViewClinicDTO, Clinic>().ReverseMap()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id));

            CreateMap<AddClinicDTO, Clinic>().ReverseMap();

            CreateMap<UpdateClinicDTO, Clinic>().ReverseMap();
        }
    }
}
