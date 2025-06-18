using Server.Application.Interfaces;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Services
{
    public class VitaminService : IVitaminService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VitaminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ApproveVitamin(Guid vitaminId)
        {
            var vitamin = await _unitOfWork.VitaminRepository.GetByIdAsync(vitaminId);
            if (vitamin is null)
            {
                return false;
            }
            vitamin.Review = true;
            _unitOfWork.VitaminRepository.Update(vitamin);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> CreateVitamin(Vitamin vitamin)
        {
            _unitOfWork.VitaminRepository.AddAsync(vitamin);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> DeleteVitamin(Guid vitaminId)
        {
            var vitamin = await _unitOfWork.VitaminRepository.GetByIdAsync(vitaminId);
            if (vitamin is null)
            {
                return false;
            }
            _unitOfWork.VitaminRepository.DeleteVitamin(vitamin);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<Vitamin> GetVitaminByIdAsync(Guid vitaminId)
        {
            return await _unitOfWork.VitaminRepository.GetVitaminById(vitaminId);
        }

        public async Task<List<Vitamin>> GetVitaminsAsync()
        {
            return await _unitOfWork.VitaminRepository.GetAllAsync();
        }

        public async Task<bool> SoftDeleteVitamin(Guid VitaminId)
        {
            var vitamin = await _unitOfWork.VitaminRepository.GetByIdAsync(VitaminId);
            if (vitamin is null)
            {
                return false;
            }
            _unitOfWork.VitaminRepository.SoftRemove(vitamin);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UpdateVitamin(Vitamin vitamin)
        {
            _unitOfWork.VitaminRepository.Update(vitamin);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
