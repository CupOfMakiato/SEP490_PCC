using AutoMapper;
using Server.Application.DTOs.User;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mappers.UserProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<User, GetUserDTO>()
            .ForMember(dest => dest.PhoneNo, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.Avatar))
                
            .ReverseMap();
            CreateMap<User, EditUserDTO>()
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
            .ReverseMap();
        }
    }
}
