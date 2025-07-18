using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Consultation;

namespace Server.Application.Interfaces
{
    public interface IConsultationService
    {
        public Task<Result<ViewConsultationDTO>> GetConsultationByIdAsync(Guid consultationId);
        public Task<Result<List<ViewConsultationDTO>>> GetConsultationByConsultantIdAsync(Guid consultantId);
        public Task<Result<bool>> SoftDeleteConsultation(Guid consultationId);
        public Task<Result<ViewConsultationDTO>> CreateConsultation(AddConsultationDTO consultation);
        public Task<Result<ViewConsultationDTO>> UpdateConsultatation(UpdateConsultationDTO consultation);
    }
}
