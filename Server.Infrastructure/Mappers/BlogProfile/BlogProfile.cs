using AutoMapper;
using CloudinaryDotNet.Actions;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.User;
using Server.Domain.Entities;
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
        src.BlogCreatedBy != null ? new UserDTO { Id = src.BlogCreatedBy.Id, UserName = src.BlogCreatedBy.UserName } : null));

        }
    }
}
