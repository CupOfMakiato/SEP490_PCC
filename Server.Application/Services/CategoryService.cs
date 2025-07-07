using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Category;
using Server.Application.Interfaces;
using Server.Application.Mappers.CategoryExtensions;
using Server.Application.Repositories;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IClaimsService _claimsService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository, IClaimsService claimsService)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;
        }

        public async Task<Result<object>> AddNewCategory(AddCategoryDTO addCategoryDTO)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(addCategoryDTO.UserId);
            if (user == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not exist!",
                    Data = null
                };
            }

            var existingCategory = await _unitOfWork.CategoryRepository.GetCategoryByName(addCategoryDTO.CategoryName);
            if (existingCategory != null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Category with the same name already exists!",
                    Data = null
                };
            }

            var boardMapper = addCategoryDTO.ToCategory();

            await _unitOfWork.CategoryRepository.AddAsync(boardMapper);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Add new category successfully" : "Add new category fail",
                Data = null
            };
        }
        public async Task<Result<List<ViewCategoryDTO>>> ViewAllActiveCategories()
        {
            var result = _mapper.Map<List<ViewCategoryDTO>>(await _unitOfWork.CategoryRepository.GetAllActiveCategories());
            return new Result<List<ViewCategoryDTO>>
            {
                Error = 0,
                Message = "view all active categories successfully",
                Data = result
            };
        }

        public async Task<Result<List<ViewCategoryDTO>>> ViewAllCategoriesNotDeleted()
        {
            var result = _mapper.Map<List<ViewCategoryDTO>>(await _unitOfWork.CategoryRepository.GetCategoryNotDeleted());
            return new Result<List<ViewCategoryDTO>>
            {
                Error = 0,
                Message = "view all categories successfully",
                Data = result
            };
        }
        public async Task<Result<object>> EditCategory(EditCategoryDTO EditCategoryDTO)
        {
            var Category = await _unitOfWork.CategoryRepository.GetByIdAsync(EditCategoryDTO.Id);
            if (Category == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Didn't find any category, please try again!",
                    Data = null
                };
            }

            var existingCategory = await _unitOfWork.CategoryRepository.GetCategoryByName(EditCategoryDTO.CategoryName);
            if (existingCategory != null && existingCategory.Id != EditCategoryDTO.Id)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Category with the same name already exists!",
                    Data = null
                };
            }
            var user = _claimsService.GetCurrentUserId;

            Category.Id = EditCategoryDTO.Id;
            Category.CategoryName = EditCategoryDTO.CategoryName;
            Category.ModificationBy = user;
            Category.IsActive = EditCategoryDTO.IsActive;
            Category.BlogCategoryTag = EditCategoryDTO.BlogCategoryTag;
            //Category.ModificationBy = EditCategoryDTO.ModifiedBy;
            Category.ModificationDate = DateTime.Now;

            _categoryRepository.Update(Category);
            var result = await _unitOfWork.SaveChangeAsync();
            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Edit category successfully" : "Edit category fail",
                Data = null
            };
        }
        

        public async Task<Result<object>> DeleteCategory(Guid Id)
        {
            var Category = await _unitOfWork.CategoryRepository.GetByIdAsync(Id);

            if (Category == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Didn't find any category, please try again!",
                    Data = null
                };
            }

            _categoryRepository.SoftRemove(Category);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Delete category successfully" : "Delete category fail",
                Data = result
            };
        }

        public async Task<Result<List<ViewCategoryDTO>>> ViewAllCategories()
        {
            var result = _mapper.Map<List<ViewCategoryDTO>>(await _unitOfWork.CategoryRepository.GetAllCategories());

            return new Result<List<ViewCategoryDTO>>
            {
                Error = 0,
                Message = "view all categories successfully",
                Data = result
            };
        }

        public async Task<Result<Category>> ViewCategoryByName(string name)
        {
            var result = await _categoryRepository.GetCategoryByName(name);

            return new Result<Category>
            {
                Error = 0,
                Message = "view all categories successfully",
                Data = result
            };
        }

        public async Task<Result<ViewCategoryDTO>> ViewCategoryById(Guid Id)
        {
            var result = _mapper.Map<ViewCategoryDTO>(await _categoryRepository.GetByIdAsync(Id));

            return new Result<ViewCategoryDTO>
            {
                Error = 0,
                Message = "View category successfully",
                Data = result
            };
        }

    }
}
