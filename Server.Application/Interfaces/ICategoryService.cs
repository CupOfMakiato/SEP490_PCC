﻿using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Category;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<Result<object>> AddNewCategory(AddCategoryDTO addCategoryDTO);
        Task<Result<object>> DeleteCategory(Guid categoryId);
        Task<Result<List<ViewCategoryDTO>>> ViewAllCategories();
        Task<Result<Category>> ViewCategoryByName(string name);
        Task<Result<ViewCategoryDTO>> ViewCategoryById(Guid Id);



    }
}
