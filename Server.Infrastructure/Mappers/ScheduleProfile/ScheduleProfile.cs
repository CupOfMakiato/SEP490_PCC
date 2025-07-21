using AutoMapper;
using Server.Application.DTOs.Schedule;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.ScheduleProfile
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<ViewScheduleDTO, Schedule>().ReverseMap();
            CreateMap<AddScheduleDTO, Schedule>().ReverseMap();
            CreateMap<UpdateScheduleDTO, Schedule>().ReverseMap();
        }
    }
}
