using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.AllergyCategory;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class AllergyCategoryService : IAllergyCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AllergyCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<object>> CreateAllergyCategory(CreateAllergyCategoryRequest request)
        {
            if (request == null)
                return new Result<object>
                {
                    Error = 1,
                    Message = "Request is null"
                };

            if (await _unitOfWork.AllergyCategoryRepository.GetAllergyCategoryByName(request.Name) != null)
                return new Result<object>
                {
                    Error = 1,
                    Message = "Name is duplicate"
                };

            var allergyCategory = new AllergyCategory
            {
                Description = request.Description,
                Name = request.Name
            };

            await _unitOfWork.AllergyCategoryRepository.AddAsync(allergyCategory);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<object>
                {
                    Error = 0,
                    Message = "Create success",
                    Data = new AllergyCategory
                    {
                        Id = allergyCategory.Id,
                        Name = allergyCategory.Name,
                        Description = allergyCategory.Description
                    }
                };

            return new Result<object>
            {
                Error = 1,
                Message = "Create failed"
            };
        }

        public async Task<Result<bool>> DeleteAllergyCategory(Guid allergyCategoryId)
        {
            var allergyCategory = await _unitOfWork.AllergyCategoryRepository.GetAllergyCategoryById(allergyCategoryId);
            if (allergyCategory == null)
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Allergy category is not found"
                };

            if (allergyCategory.Allergies.Count() != 0)
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Cannot delete this category"
                };

            _unitOfWork.AllergyCategoryRepository.DeleteAllergyCategory(allergyCategory);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<bool>
                {
                    Error = 0,
                    Message = "Delete success"
                };

            return new Result<bool>
            {
                Error = 1,
                Message = "Delete failed"
            };
        }

        public async Task<AllergyCategory> GetAllergyCategoryByIdAsync(Guid allergyCategoryId)
            => await _unitOfWork.AllergyCategoryRepository.GetByIdAsync(allergyCategoryId);

        public async Task<List<AllergyCategory>> GetAllergyCategoriesAsync()
            => await _unitOfWork.AllergyCategoryRepository.GetAllAsync();

        public async Task<AllergyCategory> GetAllergyCategoryWithAllergiesByIdAsync(Guid allergyCategoryId)
            => await _unitOfWork.AllergyCategoryRepository.GetAllergyCategoryById(allergyCategoryId);

        public async Task<bool> SoftDeleteAllergyCategory(Guid allergyCategoryId)
        {
            var allergyCategory = await _unitOfWork.AllergyCategoryRepository.GetByIdAsync(allergyCategoryId);
            if (allergyCategory is null)
                return false;

            _unitOfWork.AllergyCategoryRepository.SoftRemove(allergyCategory);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<Result<object>> UpdateAllergyCategory(UpdateAllergyCategoryRequest request)
        {
            var allergyCategory = await _unitOfWork.AllergyCategoryRepository.GetByIdAsync(request.Id);
            if (allergyCategory is null)
                return new Result<object>
                {
                    Error = 1,
                    Message = "Category is not found"
                };

            if (allergyCategory.Name != request.Name)
                if (await _unitOfWork.AllergyCategoryRepository.GetAllergyCategoryByName(request.Name) != null)
                    return new Result<object>
                    {
                        Error = 1,
                        Message = "Name is duplicate"
                    };

            allergyCategory.Description = request.Description;
            allergyCategory.Name = request.Name;

            _unitOfWork.AllergyCategoryRepository.Update(allergyCategory);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<object>
                {
                    Error = 0,
                    Message = "Update success",
                    Data = new AllergyCategory
                    {
                        Id = request.Id,
                        Name = allergyCategory.Name,
                        Description = allergyCategory.Description
                    }
                };

            return new Result<object>
            {
                Error = 1,
                Message = "Update failed"
            };
        }
    }

}
