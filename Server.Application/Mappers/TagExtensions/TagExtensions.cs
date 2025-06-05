using CloudinaryDotNet.Actions;
using Server.Application.Abstractions.RequestAndResponse.Category;
using Server.Application.Abstractions.RequestAndResponse.Tag;
using Server.Application.DTOs.Category;
using Server.Application.DTOs.Tag;
using Server.Domain.Entities;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Mappers.TagExtensions
{
    public static class TagExtensions
    {
        public static Tag ToTag(this AddTagDTO addTagDTO)
        {
            return new Tag
            {
                Id = addTagDTO.Id,
                Name = addTagDTO.Name,
                //Status = addTagDTO.Status,
                CreatedBy = addTagDTO.UserId,

            };
        }
        public static AddTagDTO ToAddTagDTO(this AddNewTagRequest addNewTagRequest)
        {
            return new AddTagDTO
            {
                Id = (Guid)addNewTagRequest.Id,
                UserId = addNewTagRequest.UserId,
                Name = addNewTagRequest.Name,
                Status = StatusEnums.Active,

            };
        }


    }
}
