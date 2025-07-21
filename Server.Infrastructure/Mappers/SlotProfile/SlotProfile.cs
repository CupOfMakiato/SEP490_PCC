using AutoMapper;
using Server.Application.DTOs.Slot;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.SlotProfile
{
    public class SlotProfile : Profile
    {
        public SlotProfile()
        {
            CreateMap<ViewSlotDTO, Slot>().ReverseMap();
            CreateMap<AddSlotDTO, Slot>().ReverseMap();
        }
    }
}
