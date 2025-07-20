using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        public Task<Doctor?> GetDoctorByIdAsync(Guid doctorId);
    }
}
