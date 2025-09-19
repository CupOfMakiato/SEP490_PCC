using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Clinic;

namespace Server.Application.Interfaces
{
    public interface IClinicService
    {
        public Task<Result<ViewClinicDTO>> GetClinicByIdAsync(Guid clinicId);
        public Task<Result<List<ViewClinicDTO>>> GetClinicByNameAsync(string name);
        public Task<Result<List<ViewClinicDTO>>> GetClinicsAsync();
        public Task<Result<bool>> SoftDeleteClinic(Guid clinicId);
        public Task<Result<ViewClinicDTO>> CreateClinic(AddClinicDTO clinic);
        public Task<Result<ViewClinicDTO>> UpdateClinic(UpdateClinicDTO clinic);
        public Task<Result<bool>> ApproveClinic(Guid clinicId);
        public Task<Result<bool>> RejectClinic(Guid clinicId);
        public Task<Result<List<ViewClinicDTO>>> SuggestClinicsAsync(Guid userId);
        public Task<Result<ViewClinicDTO>> GetClinicByUserIdAsync(Guid userId);
    }
}
