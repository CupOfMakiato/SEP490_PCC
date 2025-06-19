using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class DiseaseService : IDiseaseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiseaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateDisease(Disease disease)
        {
            _unitOfWork.DiseaseRepository.AddAsync(disease);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> DeleteDisease(Guid diseaseId)
        {
            var disease = await _unitOfWork.DiseaseRepository.GetByIdAsync(diseaseId);
            if (disease is null)
            {
                return false;
            }
            _unitOfWork.DiseaseRepository.DeleteDisease(disease);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<Disease> GetDiseaseByIdAsync(Guid diseaseId)
        {
            return await _unitOfWork.DiseaseRepository.GetDiseaseById(diseaseId);
        }

        public async Task<List<Disease>> GetDiseasesAsync()
        {
            return await _unitOfWork.DiseaseRepository.GetAllAsync();
        }

        public async Task<bool> SoftDeleteDisease(Guid DiseaseId)
        {
            var disease = await _unitOfWork.DiseaseRepository.GetByIdAsync(DiseaseId);
            if (disease is null)
            {
                return false;
            }
            _unitOfWork.DiseaseRepository.SoftRemove(disease);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UpdateDisease(Disease disease)
        {
            _unitOfWork.DiseaseRepository.Update(disease);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
