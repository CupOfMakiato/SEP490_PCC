using AutoMapper;
using Server.Application.DTOs.Admin;
using Server.Application.DTOs.TemplateChecklist;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mappers.ChecklistProfile
{
    public class TemplateChecklistProfile : Profile
    {
        public TemplateChecklistProfile()
        {
            CreateMap<TemplateChecklist, ViewTemplateChecklistDTO>();

            CreateMap<TemplateChecklistGrowthData, ViewTemplateChecklistDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TemplateChecklistId))
            .ForMember(dest => dest.GrowthDataId, opt => opt.MapFrom(src => src.GrowthDataId))
            .ForMember(dest => dest.TaskName, opt => opt.MapFrom(src => src.TemplateChecklist.TaskName))
            .ForMember(dest => dest.Trimester, opt => opt.MapFrom(src => src.TemplateChecklist.Trimester))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.TemplateChecklist.IsActive))
            .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted))
            .ForMember(dest => dest.CompletedDate, opt => opt.MapFrom(src => src.CompletedDate))

            .ReverseMap();
        }
    }
}
