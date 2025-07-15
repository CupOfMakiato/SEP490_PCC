using AutoMapper;
using Server.Application.DTOs.UserChecklist;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mappers.ChecklistProfile
{
    public class CustomChecklistProfile : Profile
    {
        public CustomChecklistProfile()
        {
            CreateMap<CustomChecklist, ViewCustomChecklistDTO>().ReverseMap();
        }
    }
}
