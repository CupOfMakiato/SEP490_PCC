using AutoMapper;
using Server.Application.DTOs.OfflineConsultation;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.OfflineConsultationProfile
{
    public class OfflineConsultationProfile : Profile
    {
        public OfflineConsultationProfile()
        {
            CreateMap<ViewOfflineConsultationDTO, OfflineConsultation>().ReverseMap()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id));

            CreateMap<BookingOfflineConsultationDTO, OfflineConsultation>().ReverseMap();

            CreateMap<UpdateOfflineConsultationDTO, OfflineConsultation>().ReverseMap();
        }
    }
}
