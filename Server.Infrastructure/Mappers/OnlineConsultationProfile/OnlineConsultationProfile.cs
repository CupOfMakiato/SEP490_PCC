using AutoMapper;
using Server.Application.DTOs.OnlineConsultation;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.OnlineConsultationProfile
{
    public class OnlineConsultationProfile : Profile
    {
        public OnlineConsultationProfile()
        {
            CreateMap<ViewOnlineConsultationDTO, OnlineConsultation>().ReverseMap()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id));

            CreateMap<AddOnlineConsultationDTO, OnlineConsultation>().ReverseMap();

            CreateMap<UpdateOnlineConsultationDTO, OnlineConsultation>().ReverseMap();
        }
    }
}
