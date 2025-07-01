using AutoMapper;
using Server.Application.DTOs.Media;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Mappers.MediaProfile
{
    public class MediaProfile : Profile
    {
        public MediaProfile()
        {
            CreateMap<Media, MediaDTO>();
                

        }
    }
}
