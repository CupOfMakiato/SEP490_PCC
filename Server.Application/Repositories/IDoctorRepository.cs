using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        public Task<Doctor?> GetDoctorByIdAsync(Guid doctorId);
        public Task<bool> HasOverlappingScheduleAsync(Guid doctorId,
                                                      DateTime startTime,
                                                      DateTime endTime,
                                                      int dayOfWeek);
        public Task<List<Doctor>> GetAllDoctorsAsync();
    }
}
