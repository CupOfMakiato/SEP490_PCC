using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Doctor;

namespace Server.Application.Interfaces
{
    public interface IDoctorService
    {
        public Task<Result<ViewDoctorDTO>> GetDoctorByIdAsync(Guid doctorId);
        public Task<Result<bool>> SoftDeleteDoctor(Guid doctorId);
        public Task<Result<ViewDoctorDTO>> CreateDoctor(AddDoctorDTO doctor);
        public Task<Result<ViewDoctorDTO>> UpdateDoctor(UpdateDoctorDTO doctor);
        public Task<Result<List<ViewDoctorDTO>>> GetAllDoctorsAsync();
    }
}
