using CloudinaryDotNet.Actions;
using Server.Application.Abstractions.RequestAndResponse.Category;
using Server.Application.DTOs.Category;
using Server.Application.Mappers.UserExtension;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Mappers.CategoryExtensions
{
    public static class CategoryExtensions
    {
        public static ViewCategoryDTO ToViewCategoryDTO(this Category category)
        {
            return new ViewCategoryDTO
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                BlogCategoryTag = category.BlogCategoryTag,
                IsActive = category.IsActive,
                CreatedByUser = category.CategoryCreatedBy.ToUserDTO()

            };
        }
        public static Category ToCategory(this AddCategoryDTO addCategoryDTO)
        {
            return new Category
            {
                Id = addCategoryDTO.Id,
                CategoryName = addCategoryDTO.CategoryName,
                IsActive = addCategoryDTO.IsActive,
                BlogCategoryTag = addCategoryDTO.BlogCategoryTag,
                CreatedBy = addCategoryDTO.UserId,

            };
        }

        public static AddCategoryDTO ToAddCategoryDTO(this AddNewCategoryRequest addNewCategoryRequest)
        {
            return new AddCategoryDTO
            {
                Id = (Guid)addNewCategoryRequest.Id,
                UserId = addNewCategoryRequest.UserId,
                CategoryName = addNewCategoryRequest.CategoryName,
                BlogCategoryTag = addNewCategoryRequest.BlogCategoryTag,
                IsActive = true,

            };
        }
        public static EditCategoryDTO ToEditCategoryDTO(this EditCategoryRequest addNewCategoryRequest)
        {
            return new EditCategoryDTO
            {
                Id = addNewCategoryRequest.Id,
                //UserId = addNewCategoryRequest.UserId,
                CategoryName = addNewCategoryRequest.CategoryName,
                BlogCategoryTag = addNewCategoryRequest.BlogCategoryTag,
                IsActive = addNewCategoryRequest.IsActive,
            };
        }
    }
}
