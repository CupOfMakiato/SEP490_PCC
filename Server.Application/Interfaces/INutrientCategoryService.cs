using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.NutrientCategory;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface INutrientCategoryService
    {
        public Task<NutrientCategory> GetNutrientCategoryByIdAsync(Guid nutrientCategoryId);
        public Task<List<NutrientCategory>> GetNutrientCategorysAsync();
        public Task<bool> SoftDeleteNutrientCategory(Guid nutrientCategoryId);
        public Task<Result<NutrientCategory>> CreateNutrientCategory(CreateNutrientCategoryRequest request);
        public Task<Result<NutrientCategory>> UpdateNutrientCategory(UpdateNutrientCategoryRequest request);
    }
}
