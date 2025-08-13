using AutoMapper;
using Server.Application.DTOs.Doctor;
using Server.Domain.Entities;

namespace Server.Infrastructure.Mappers.DoctorProfile
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<ViewDoctorDTO, Doctor>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                .ReverseMap();
                
            CreateMap<AddDoctorDTO, Doctor>().ReverseMap();
            CreateMap<UpdateDoctorDTO, Doctor>().ReverseMap();
        }
    }
}
