using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface INutrientCategoryService
    {
        public Task<NutrientCategory> GetNutrientCategoryByIdAsync(Guid nutrientCategoryId);
        public Task<List<NutrientCategory>> GetNutrientCategorysAsync();
        public Task<bool> SoftDeleteNutrientCategory(Guid nutrientCategoryId);
        public Task<bool> CreateNutrientCategory(NutrientCategory nutrientCategory);
        public Task<bool> UpdateNutrientCategory(NutrientCategory nutrientCategory);
    }
}
