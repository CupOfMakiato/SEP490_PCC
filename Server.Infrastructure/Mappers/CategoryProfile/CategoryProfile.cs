using AutoMapper;
using Server.Application.DTOs.Category;
using Server.Application.DTOs.SubCategory;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mappers.CategoryProfile
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<ViewCategoryDTO, Category>().ReverseMap()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id));
            CreateMap<AddCategoryDTO, Category>().ReverseMap();

            CreateMap<ViewSubCategoryDTO, SubCategory>().ReverseMap()
                .ForMember(p => p.Id, b => b.MapFrom(m => m.Id));
        }
    }
}
