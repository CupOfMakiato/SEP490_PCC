using AutoMapper;
using CloudinaryDotNet.Actions;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.User;
using Server.Domain.Entities;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mappers.BlogProfile
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<Blog, ViewBlogDTO>()
            .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src =>
                src.BlogCreatedBy != null ? new UserDTO { Id = src.BlogCreatedBy.Id, UserName = src.BlogCreatedBy.UserName } : null))

            .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src =>
                src.BlogCreatedBy != null ? new GetUserDTO { Id = src.BlogCreatedBy.Id, UserName = src.BlogCreatedBy.UserName } : null))

            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src =>
                src.BlogTags
                    .Select(bt => bt.Tag.Name)
                    .ToList()))

            .ForMember(dest => dest.Images, opt => opt.MapFrom(src =>
                src.Media))

            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src =>
                src.Category != null ? src.Category.CategoryName : null)) 

            .ForMember(dest => dest.BookmarkCount, opt => opt.Ignore())

            .ForMember(dest => dest.LikeCount, opt => opt.Ignore()
            );

        }
    }
}
