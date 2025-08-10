using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Nutrient;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class NutrientService : INutrientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IMapper _mapper;

        public NutrientService(IUnitOfWork unitOfWork, ICloudinaryService cloudinaryService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _cloudinaryService = cloudinaryService;
            _mapper = mapper;
        }

        public async Task<Result<NutrientDTO>> CreateNutrient(CreateNutrientRequest request)
        {
            var nutrientCategory = await _unitOfWork.NutrientCategoryRepository.GetByIdAsync
                (request.CategoryId);

            if (nutrientCategory is null)
            {
                return new Result<NutrientDTO>()
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
            };

            var uploadImageResult = await _cloudinaryService.UploadImage(request.ImageUrl, "Nutrient");
            if (uploadImageResult is not null)
                nutrient.ImageUrl = uploadImageResult.FileUrl;
            await _unitOfWork.NutrientRepository.AddAsync(nutrient);

            if (!(await _unitOfWork.SaveChangeAsync() > 0))
                return new Result<NutrientDTO>()
                {
                    Message = "Create fail",
                    Error = 1
                };
            return new Result<NutrientDTO>()
            {
                Data = _mapper.Map<NutrientDTO>(nutrient),
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

        public async Task<NutrientDTO> GetNutrientByIdAsync(Guid nutrientId)
        {
            return _mapper.Map<NutrientDTO>(await _unitOfWork.NutrientRepository.GetNutrientById(nutrientId));
        }

        public async Task<List<NutrientDTO>> GetNutrientsAsync()
        {
            return _mapper.Map<List<NutrientDTO>>(await _unitOfWork.NutrientRepository.GetAllAsync());
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

        public async Task<Result<NutrientDTO>> UpdateNutrient(UpdateNutrientRequest request)
        {
            if (request is null)
                return new Result<NutrientDTO>()
                {
                    Error = 1,
                    Message = "Request is null"
                };
            var nutrient = await _unitOfWork.NutrientRepository.GetByIdAsync(request.Id);
            if (nutrient is null)
                return new Result<NutrientDTO>()
                {
                    Error = 1,
                    Message = "Nutrient is not found"
                };
            nutrient.Name = request.Name;
            nutrient.Description = request.Description;
            _unitOfWork.NutrientRepository.Update(nutrient);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<NutrientDTO>()
                {
                    Error = 1,
                    Data = _mapper.Map<NutrientDTO>(nutrient)
                };
            return new Result<NutrientDTO>()
            {
                Error = 1,
                Message = "Update failed"
            };
        }

        public async Task<Result<NutrientDTO>> UpdateNutrientImage(UpdateNutrientImageRequest request)
        {
            if (request is null)
                return new Result<NutrientDTO>()
                {
                    Error = 1,
                    Message = "Request is null"
                };
            var nutrient = await _unitOfWork.NutrientRepository.GetByIdAsync(request.Id);
            if (nutrient is null)
                return new Result<NutrientDTO>()
                {
                    Error = 1,
                    Message = "Nutrient is not found"
                };
            var uploadImageResult = await _cloudinaryService.UploadImage(request.ImageUrl, "Nutrient");
            if (uploadImageResult is null)
                return new Result<NutrientDTO>()
                {
                    Error = 1,
                    Message = "Image is not found"
                };
            nutrient.ImageUrl = uploadImageResult.FileUrl;
            _unitOfWork.NutrientRepository.Update(nutrient);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<NutrientDTO>()
                {
                    Error = 1,
                    Data = _mapper.Map<NutrientDTO>(nutrient)
                };
            return new Result<NutrientDTO>()
            {
                Error = 1,
                Message = "Update failed"
            };
        }
    }
}
