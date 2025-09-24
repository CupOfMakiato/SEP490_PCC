using AutoMapper;
using Server.Application.DTOs.Consultant;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.ConsultantProfile
{
    public class ConsultantProfile : Profile
    {
        public ConsultantProfile()
        {
            CreateMap<ViewConsultantDTO, Consultant>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.User, src => src.MapFrom(x => x.User))
                .ReverseMap();
            CreateMap<AddConsultantDTO, Consultant>().ReverseMap();
            CreateMap<UpdateConsultantDTO, Consultant>().ReverseMap();
        }
    }
}
