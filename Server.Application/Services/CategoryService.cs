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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<object>> AddNewCategory(AddCategoryDTO addCategoryDTO)
        {
            var user = await _unitOfWork.userRepository.GetByIdAsync(addCategoryDTO.UserId);
            if (user == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not exist!",
                    Data = null
                };
            }
            var boardMapper = addCategoryDTO.ToCategory();

            // Save board to database
            await _unitOfWork.categoryRepository.AddAsync(boardMapper);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Add new category successfully" : "Add new category fail",
                Data = null
            };
        }

        public async Task<Result<object>> DeleteCategory(Guid Id)
        {
            var Category = await _unitOfWork.categoryRepository.GetByIdAsync(Id);

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
            var result = _mapper.Map<List<ViewCategoryDTO>>(await _unitOfWork.categoryRepository.GetAllCategories());

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
