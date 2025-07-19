using AutoMapper;
using Server.Application.DTOs.Consultant;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.ConsultantProfile
{
    public class ConsultantProfile : Profile
    {
        public ConsultantProfile()
        {
            CreateMap<ViewConsultantDTO, Consultant>().ReverseMap()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id));
        }
    }
}
