using AutoMapper;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.Tag;
using Server.Application.DTOs.User;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mappers.TagProfile
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, ViewTagDTO>()
    .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src =>
        src.TagCreatedBy != null ? new UserDTO { Id = src.TagCreatedBy.Id, UserName = src.TagCreatedBy.UserName } : null));

        }
    }
}
