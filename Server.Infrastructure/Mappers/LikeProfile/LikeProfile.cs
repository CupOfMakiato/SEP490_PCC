using AutoMapper;
using Server.Application.DTOs.Like;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mappers.LikeProfile
{
    public class LikeProfile : Profile
    {
        public LikeProfile()
        {
            CreateMap<Like, ViewAllLikeDTO>()
                .ForMember(dest => dest.BlogId, opt => opt.MapFrom(src => src.BlogId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Blog.Title))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Blog.Body))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Blog.CategoryId))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.Blog.CreatedBy))
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.Blog.CreationDate));
        }
    }
}
