using AutoMapper;
using Server.Application.DTOs.Notification;
using Server.Application.DTOs.User;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mappers.NotificationProfile
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, ViewNotificationDTO>()
                .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src =>
                src.NotificationCreatedByUser != null ? new GetUserDTO { Id = src.NotificationCreatedByUser.Id, UserName = src.NotificationCreatedByUser.UserName } : null))
                .ReverseMap();
        }
    }
}
