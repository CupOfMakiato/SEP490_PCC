using AutoMapper;
using Server.Application.DTOs.ChatThread;
using Server.Application.DTOs.Message;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.ChatThreadProfile
{
    public class ChatThreadProfile : Profile
    {
        public ChatThreadProfile()
        {
            CreateMap<ViewChatThreadDTO, ChatThread>().ReverseMap()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id));

            CreateMap<ChatThreadDTO, ChatThread>().ReverseMap();
            
            CreateMap<ChatThread, CreateChatThreadDTO>()
            .ReverseMap();

        }
    }
}
