using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.OnlineConsultation;

namespace Server.Application.Interfaces
{
    public interface IOnlineConsultationService
    {
        public Task<Result<List<ViewOnlineConsultationDTO>>> GetOnlineConsultationsAsync(Guid consultantId, string? status);
        public Task<Result<ViewOnlineConsultationDTO>> GetOnlineConsultationByIdAsync(Guid onlineConsultationId);
        public Task<Result<ViewOnlineConsultationDTO>> BookOnlineConsultationAsync(AddOnlineConsultationDTO onlineConsultation);
        public Task<Result<ViewOnlineConsultationDTO>> UpdateOnlineConsultation(UpdateOnlineConsultationDTO onlineConsultation);
        public Task<Result<bool>> CancelOnlineConsultationAsync(Guid onlineConsultationId);
        public Task<Result<bool>> ConfirmOnlineConsultationAsync(Guid onlineConsultationId);
        public Task<Result<bool>> SoftDeleteOnlineConsultation(Guid onlineConsultationId);
    }
}
