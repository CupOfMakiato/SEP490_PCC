using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IClinicRepository : IGenericRepository<Clinic>
    {
        public Task<Clinic> GetClinicByIdAsync(Guid clinicId);
        public Task<List<Clinic>> GetClinicByNameAsync(string name);
        public Task<List<Clinic>> GetClinicsAsync();
        public Task<Clinic> GetClinicToApproveAsync(Guid clinicId);
        public Task<Clinic> GetClinicByClinicIdAsync(Guid clinicId);
        public Task<List<Clinic>> SuggestClinicsAsync(string userAddress, int maxResult = 10);
        public Task<Clinic> GetClinicByUserId(Guid userId);
    }
}
