using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.OnlineConsultation;

namespace Server.Application.Interfaces
{
    public interface IOnlineConsultationService
    {
        public Task<Result<List<ViewOnlineConsultationDTO>>> GetOnlineConsultationsByConsultantIdAsync(Guid consultantId);
        public Task<Result<List<ViewOnlineConsultationDTO>>> GetOnlineConsultationsByUserIdAsync(Guid userId);
        public Task<Result<ViewOnlineConsultationDTO>> GetOnlineConsultationByIdAsync(Guid onlineConsultationId);
        public Task<Result<ViewOnlineConsultationDTO>> CreateOnlineConsultation(AddOnlineConsultationDTO onlineConsultation);
        public Task<Result<ViewOnlineConsultationDTO>> UpdateOnlineConsultation(UpdateOnlineConsultationDTO onlineConsultation);
        public Task<Result<bool>> SoftDeleteOnlineConsultation(Guid onlineConsultationId);
    }
}
