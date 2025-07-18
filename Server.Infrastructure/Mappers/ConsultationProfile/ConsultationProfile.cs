using AutoMapper;
using Server.Application.DTOs.Consultation;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.ConsultationProfile
{
    public class ConsultationProfile : Profile
    {
        public ConsultationProfile()
        {
            CreateMap<ViewConsultationDTO, Consultation>().ReverseMap()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id));

            CreateMap<AddConsultationDTO, Consultation>().ReverseMap();

            CreateMap<UpdateConsultationDTO, Consultation>().ReverseMap();
        }
    }
}
