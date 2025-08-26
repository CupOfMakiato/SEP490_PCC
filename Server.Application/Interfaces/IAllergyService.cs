using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Allergy;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface IAllergyService
    {
        Task<Result<GetAllergyResponse>> GetAllergyByIdAsync(Guid allergyId);
        Task<Result<List<GetAllergyResponse>>> GetAllergiesAsync();
        Task<Result<object>> SoftDeleteAllergy(Guid allergyId);
        Task<Result<object>> DeleteAllergy(Guid allergyId);
        Task<Result<Allergy>> CreateAllergy(CreateAllergyRequest request);
        Task<Result<Allergy>> UpdateAllergy(UpdateAllergyRequest request);
    }
}
