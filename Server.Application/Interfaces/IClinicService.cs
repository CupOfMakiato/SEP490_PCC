using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Clinic;

namespace Server.Application.Interfaces
{
    public interface IClinicService
    {
        public Task<Result<ViewClinicDTO>> GetClinicByIdAsync(Guid clinicId);
        public Task<Result<List<ViewClinicDTO>>> GetClinicByNameAsync(string name);
        public Task<Result<List<ViewClinicDTO>>> GetClinicsAsync();
        public Task<Result<object>> SoftDeleteClinic(Guid clinicId);
        public Task<Result<object>> CreateClinic(AddClinicDTO clinic);
        public Task<Result<object>> UpdateClinic(UpdateClinicDTO clinic);
    }
}
