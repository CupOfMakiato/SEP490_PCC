using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.AllergyCategory;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface IAllergyCategoryService
    {
        Task<AllergyCategory> GetAllergyCategoryByIdAsync(Guid allergyCategoryId);
        Task<List<AllergyCategory>> GetAllergyCategoriesAsync();
        Task<AllergyCategory> GetAllergyCategoryWithAllergiesByIdAsync(Guid allergyCategoryId);
        Task<bool> SoftDeleteAllergyCategory(Guid allergyCategoryId);
        Task<Result<bool>> DeleteAllergyCategory(Guid allergyCategoryId);
        Task<Result<object>> CreateAllergyCategory(CreateAllergyCategoryRequest request);
        Task<Result<object>> UpdateAllergyCategory(UpdateAllergyCategoryRequest request);
    }

}
