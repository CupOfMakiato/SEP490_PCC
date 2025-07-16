using AutoMapper;
using Server.Application.DTOs.BasicBioMetric;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.GrowthData;
using Server.Application.DTOs.Journal;
using Server.Application.DTOs.User;
using Server.Application.DTOs.UserChecklist;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mappers.GrowthDataProfile
{
    public class GrowthDataProfile : Profile
    {
        public GrowthDataProfile()
        {
            CreateMap<GrowthData, ViewGrowthDataDTO>()
            .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src =>
                src.GrowthDataCreatedBy != null ? new GetUserDTO { Id = src.GrowthDataCreatedBy.Id, UserName = src.GrowthDataCreatedBy.UserName } : null))

            .ForMember(dest => dest.Journal, opt => opt.MapFrom(src =>
                src.Journals))
            .ForMember(dest => dest.BasicBioMetric, opt => opt.MapFrom(src =>
                src.BasicBioMetric))

            .ForMember(dest => dest.CustomChecklist, opt => opt.MapFrom(src =>
                src.CustomChecklists)
            );


        }
    }
}
