using AutoMapper;
using Server.Application.DTOs.GrowthData;
using Server.Application.DTOs.Journal;
using Server.Application.DTOs.User;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mappers.JournalProfile
{
    public class JournalProfile : Profile
    {
        public JournalProfile()
        {
            CreateMap<Journal, ViewJournalDTO>()
            .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src =>
                src.JournalCreatedBy != null ? new UserDTO { Id = src.JournalCreatedBy.Id, UserName = src.JournalCreatedBy.UserName } : null));
        }
    }
}
