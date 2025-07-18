using AutoMapper;
using Server.Application.DTOs.DailySchedule;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.DailyScheduleProdile
{
    public class DailyScheduleProfile : Profile
    {
        public DailyScheduleProfile()
        {
            CreateMap<ViewDailyScheduleDTO, DailySchedule>().ReverseMap();
            CreateMap<AddDailyScheduleDTO, DailySchedule>().ReverseMap();
            CreateMap<UpdateDailyScheduleDTO, DailySchedule>().ReverseMap();
            CreateMap<GetDailyScheduleDTO, DailySchedule>().ReverseMap();
        }
    }
}
