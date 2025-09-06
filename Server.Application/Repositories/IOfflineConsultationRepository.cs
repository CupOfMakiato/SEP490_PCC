using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IOfflineConsultationRepository : IGenericRepository<OfflineConsultation>
    {
        public Task<List<OfflineConsultation?>> GetAllOfflineConsultationByUserIdAsync(Guid userId, string? status);
        public Task<OfflineConsultation?> GetOfflineConsultationByIdAsync(Guid offlineConsultationId);
        public Task<OfflineConsultation?> GetOfflineConsultationByOfflineConsultationIdAsync(Guid offlineConsultationId);
        Task<List<OfflineConsultation>> GetOfflineConsultationsByCreatedByAsync(Guid userId);
    }
}
