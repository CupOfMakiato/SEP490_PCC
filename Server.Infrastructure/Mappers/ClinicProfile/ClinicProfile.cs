using AutoMapper;
using Server.Application.DTOs.Clinic;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.ClinicProfile
{
    public class ClinicProfile : Profile
    {
        public ClinicProfile()
        {
            CreateMap<ViewClinicDTO, Clinic>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.User, src => src.MapFrom(x => x.User))
                .ReverseMap();
            CreateMap<AddClinicDTO, Clinic>().ReverseMap();

            CreateMap<UpdateClinicDTO, Clinic>().ReverseMap();
        }
    }
}
