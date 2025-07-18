using AutoMapper;
using Server.Application.DTOs.Attendance;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.AttendanceProfile
{
    public class AttendanceProfile : Profile
    {
        public AttendanceProfile()
        {
            CreateMap<ViewAttendanceDTO, Attendance>().ReverseMap()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id));

            CreateMap<AddAttendanceDTO, Attendance>().ReverseMap();
        }
    }
}
