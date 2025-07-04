using AutoMapper;
using Server.Application.DTOs.BasicBioMetric;
using Server.Application.DTOs.GrowthData;
using Server.Application.DTOs.Media;
using Server.Application.DTOs.User;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mappers.MetricProfile
{
    public class MetricProfile : Profile
    {
        public MetricProfile()
        {
            CreateMap<BasicBioMetric, ViewBasicBioMetricDTO>()
            .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src =>
                src.BasicBioMetricCreatedBy != null ? new GetUserDTO { Id = src.BasicBioMetricCreatedBy.Id, UserName = src.BasicBioMetricCreatedBy.UserName } : null));
            CreateMap<BasicBioMetric, BasicBioMetricDTO>().ReverseMap();
        }
    }
}
