using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.OfflineConsultation;

namespace Server.Application.Interfaces
{
    public interface IOfflineConsultationService
    {
        public Task<Result<List<ViewOfflineConsultationDTO>>> GetOfflineConsultationsByUserIdAsync(Guid userId, string? status);
        public Task<Result<ViewOfflineConsultationDTO>> GetOfflineConsultationByIdAsync(Guid offlineConsultationId);
        public Task<Result<ViewOfflineConsultationDTO>> BookOfflineConsultationAsync(BookingOfflineConsultationDTO offlineConsultation);
        //public Task<Result<bool>> CancelOfflineConsultationAsync(Guid offlineConsultationId);
        //public Task<Result<bool>> ConfirmOfflineConsultationAsync(Guid offlineConsultationId);
        public Task<Result<bool>> SoftDeleteOfflineConsultation(Guid offlineConsultationId);
        public Task SendOfflineConsultationRemindersAsync();
        public Task<Result<bool>> SendBookingEmailAsync(Guid offlineConsultationId);
        public Task<Result<List<ViewOfflineConsultationDTO>>> GetOfflineConsultationsByCreatedByAsync(Guid userId);
    }
}
