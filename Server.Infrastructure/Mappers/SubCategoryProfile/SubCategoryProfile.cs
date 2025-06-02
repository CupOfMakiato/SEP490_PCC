using AutoMapper;
using Server.Application.DTOs.SubCategory;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mappers.SubCategoryProfile
{
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<ViewSubCategoryDTO, SubCategory>().ReverseMap()
               .ForMember(p => p.Id, b => b.MapFrom(m => m.Id));
            CreateMap<AddSubCategoryDTO, SubCategory>().ReverseMap();
        }
    }
}
