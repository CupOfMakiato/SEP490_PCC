using AutoMapper;
using Server.Application.DTOs.TailoredCheckupReminder;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mappers.ReminderProfile
{
    public class TailoredCheckupReminderProfile : Profile
    {
        public TailoredCheckupReminderProfile()
        {
            CreateMap<TailoredCheckupReminder, ViewTailoredCheckupReminderDTO>().ReverseMap();
        }
    }
}
