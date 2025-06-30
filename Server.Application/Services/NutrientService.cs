using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Nutrient;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class NutrientService : INutrientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NutrientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Nutrient>> ApproveNutrient(Guid nutrientId)
        {
            var nutrient = await _unitOfWork.NutrientRepository.GetByIdAsync(nutrientId);
            if (nutrient is null)
            {
                return new Result<Nutrient>()
                {
                    Error = 1,
                    Message = "Nutrient doesn't exist!"
                };
            }
            nutrient.Review = true;
            _unitOfWork.NutrientRepository.Update(nutrient);
            if(await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<Nutrient>()
                {
                    Data = nutrient,
                    Error = 0,
                    Message = "Approved"
                };
            return new Result<Nutrient>()
            {
                Error = 1,
                Message = "Approve failed"
            };
        }

        public async Task<Result<Nutrient>> CreateNutrient(CreateNutrientRequest request)
        {
            var nutrientCategory = await _unitOfWork.NutrientCategoryRepository.GetByIdAsync
                (request.CategoryId);

            if (nutrientCategory is null)
            {
                return new Result<Nutrient>()
                {
                    Message = "Food category is not exist",
                    Error = 1
                };
            }

            var nutrient = new Nutrient()
            {
                Description = request.Description,
                Name = request.Name,
                CategoryId = request.CategoryId,
                NutrientCategory = nutrientCategory,
                ImageUrl = request.ImageUrl,
                Unit = request.Unit,
            };
            await _unitOfWork.NutrientRepository.AddAsync(nutrient);

            if (!(await _unitOfWork.SaveChangeAsync() > 0))
                return new Result<Nutrient>()
                {
                    Message = "Create fail",
                    Error = 1
                };
            return new Result<Nutrient>()
            {
                Data = nutrient,
                Error = 0
            };
        }

        public async Task<bool> DeleteNutrient(Guid nutrientId)
        {
            var nutrient = await _unitOfWork.NutrientRepository.GetByIdAsync(nutrientId);
            if (nutrient is null)
            {
                return false;
            }
            _unitOfWork.NutrientRepository.DeleteNutrient(nutrient);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<Nutrient> GetNutrientByIdAsync(Guid nutrientId)
        {
            return await _unitOfWork.NutrientRepository.GetNutrientById(nutrientId);
        }

        public async Task<List<Nutrient>> GetNutrientsAsync()
        {
            return await _unitOfWork.NutrientRepository.GetAllAsync();
        }

        public async Task<bool> SoftDeleteNutrient(Guid NutrientId)
        {
            var nutrient = await _unitOfWork.NutrientRepository.GetByIdAsync(NutrientId);
            if (nutrient is null)
            {
                return false;
            }
            _unitOfWork.NutrientRepository.SoftRemove(nutrient);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UpdateNutrient(Nutrient nutrient)
        {
            _unitOfWork.NutrientRepository.Update(nutrient);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
