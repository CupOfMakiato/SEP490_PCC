﻿using Org.BouncyCastle.Asn1.Ocsp;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.NutrientCategory;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class NutrientCategoryService : INutrientCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NutrientCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<NutrientCategory>> CreateNutrientCategory(CreateNutrientCategoryRequest request)
        {
            var nutrientCategory = new NutrientCategory()
            {
                Name = request.Name,
                Description = request.Description,
            };
            await _unitOfWork.NutrientCategoryRepository.AddAsync(nutrientCategory);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<NutrientCategory>()
                {
                    Data = nutrientCategory
                };
            return new Result<NutrientCategory>() 
            { 
                Error = 1,
                Message = "Create fail"
            };
        }

        public async Task<NutrientCategory> GetNutrientCategoryByIdAsync(Guid nutrientCategoryId)
        {
            return await _unitOfWork.NutrientCategoryRepository.GetNutrientCategoryById(nutrientCategoryId);
        }

        public async Task<List<NutrientCategory>> GetNutrientCategorysAsync()
        {
            return await _unitOfWork.NutrientCategoryRepository.GetAllAsync();
        }

        public async Task<bool> SoftDeleteNutrientCategory(Guid NutrientCategoryId)
        {
            var nutrientCategory = await _unitOfWork.NutrientCategoryRepository.GetByIdAsync(NutrientCategoryId);
            if (nutrientCategory is null)
            {
                return false;
            }
            _unitOfWork.NutrientCategoryRepository.SoftRemove(nutrientCategory);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<Result<NutrientCategory>> UpdateNutrientCategory(UpdateNutrientCategoryRequest request)
        {
            var nutrientCategory = await _unitOfWork.NutrientCategoryRepository.GetNutrientCategoryById(request.NutrientCategoryId);

            if (nutrientCategory is null)
                return new Result<NutrientCategory>()
                {
                    Error = 1,
                    Message = "Invalid Id"
                };

            nutrientCategory.Name = request.Name;
            nutrientCategory.Description = request.Description;

            _unitOfWork.NutrientCategoryRepository.Update(nutrientCategory);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<NutrientCategory>()
                {
                    Data = nutrientCategory
                };
            return new Result<NutrientCategory>()
            {
                Error = 1,
                Message = "Update fail"
            };
        }
    }
}
