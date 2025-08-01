using AutoMapper;
using Server.Application.DTOs.Message;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.MessageProfile
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<SendMessageDTO, Message>().ReverseMap();

            CreateMap<ViewMessageDTO, Message>().ReverseMap()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id));
        }
    }
}
