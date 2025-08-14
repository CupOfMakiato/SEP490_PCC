using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.FoodCategory;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class FoodCategoryService : IFoodCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<object>> CreateFoodCategory(CreateFoodCategoryRequest request)
        {
            if (request == null)
                return new Result<object>()
                {
                    Error = 1,
                    Message = "Request is null"
                };
            var food = await _unitOfWork.FoodCategoryRepository.GetFoodCategoryByName(request.Name);
            if (food != null)
                return new Result<object>()
                {
                    Error = 1,
                    Message = "Name is duplicate"
                };
            var foodCategory = new FoodCategory()
            {
                Description = request.Description,
                Name = request.Name,
            };
            await _unitOfWork.FoodCategoryRepository.AddAsync(foodCategory);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<object>()
                {
                    Error = 0,
                    Message = "Create success",
                    Data = new FoodCategory
                    {
                        Id = foodCategory.Id,
                        Name = foodCategory.Name,
                        Description = foodCategory.Description,
                    }
                };
            return new Result<object>()
            {
                Error = 1,
                Message = "Create failed"
            };
        }


        public async Task<Result<bool>> DeleteFoodCategory(Guid foodCategoryId)
        {
            var foodCategory = await _unitOfWork.FoodCategoryRepository.GetFoodCategoryByIdAsync(foodCategoryId);
            if (foodCategory == null)
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Food cateogry is not found"
                };
            if (foodCategory.Foods.Count() != 0)
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Cannot delete this category"
                };
            _unitOfWork.FoodCategoryRepository.DeleteFoodCategory(foodCategory);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<bool>()
                {
                    Error = 0,
                    Message = "Delete success"
                };
            return new Result<bool>()
            {
                Error = 1,
                Message = "Delete failed"
            };
        }

        public async Task<FoodCategory> GetFoodCategoryByIdAsync(Guid foodCategoryId)
            => await _unitOfWork.FoodCategoryRepository.GetByIdAsync(foodCategoryId);

        public async Task<List<FoodCategory>> GetFoodCategorysAsync()
            => await _unitOfWork.FoodCategoryRepository.GetAllAsync();

        public async Task<FoodCategory> GetFoodCategoryWithFoodByIdAsync(Guid foodCategoryId)
        {
            return await _unitOfWork.FoodCategoryRepository.GetFoodCategoryByIdAsync(foodCategoryId);
        }

        public async Task<bool> SoftDeleteFoodCategory(Guid foodCategoryId)
        {
            var foodCategory = await _unitOfWork.FoodCategoryRepository.GetByIdAsync(foodCategoryId);
            if (foodCategory is null)
            {
                return false;
            }
            _unitOfWork.FoodCategoryRepository.SoftRemove(foodCategory);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<Result<object>> UpdateFoodCategory(UpdateFoodCategoryRequest request)
        {
            var foodCategory = await _unitOfWork.FoodCategoryRepository.GetByIdAsync(request.Id);
            if (foodCategory is null)
                return new Result<object>()
                {
                    Error = 1,
                    Message = "Category is not found"
                }; ;
            if (foodCategory.Name != request.Name)
                if (await _unitOfWork.FoodCategoryRepository.GetFoodCategoryByName(request.Name) != null)
                    return new Result<object>()
                    {
                        Error = 1,
                        Message = "Name is duplicate"
                    };
            foodCategory.Description = request.Description;
            foodCategory.Name = request.Name;
            _unitOfWork.FoodCategoryRepository.Update(foodCategory);
            if(await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<object>()
                {
                    Error = 0,
                    Message = "Update success",
                    Data = new FoodCategory 
                    {
                        Id = request.Id,
                        Name = foodCategory.Name, 
                        Description = foodCategory.Description,
                    }
                };
            return new Result<object>()
            {
                Error = 1,
                Message = "Update failed"
            };
        }
    }
}
