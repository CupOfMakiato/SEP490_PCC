using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface INutrientCategoryRepository : IGenericRepository<NutrientCategory>
    {
        public Task<List<NutrientCategory>> GetNutrientCategorys();
        public Task<NutrientCategory> GetNutrientCategoryById(Guid nutrientCategoryId);
        public void DeleteNutrientCategory(NutrientCategory nutrientCategory);
    }
}
