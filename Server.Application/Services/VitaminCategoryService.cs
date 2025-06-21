using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class VitaminCategoryService : IVitaminCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VitaminCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateVitaminCategory(VitaminCategory vitaminCategory)
        {
            _unitOfWork.VitaminCategoryRepository.AddAsync(vitaminCategory);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<VitaminCategory> GetVitaminCategoryByIdAsync(Guid vitaminCategoryId)
        {
            return await _unitOfWork.VitaminCategoryRepository.GetVitaminCategoryById(vitaminCategoryId);
        }

        public async Task<List<VitaminCategory>> GetVitaminCategorysAsync()
        {
            return await _unitOfWork.VitaminCategoryRepository.GetAllAsync();
        }

        public async Task<bool> SoftDeleteVitaminCategory(Guid VitaminCategoryId)
        {
            var vitaminCategory = await _unitOfWork.VitaminCategoryRepository.GetByIdAsync(VitaminCategoryId);
            if (vitaminCategory is null)
            {
                return false;
            }
            _unitOfWork.VitaminCategoryRepository.SoftRemove(vitaminCategory);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UpdateVitaminCategory(VitaminCategory vitaminCategory)
        {
            _unitOfWork.VitaminCategoryRepository.Update(vitaminCategory);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
