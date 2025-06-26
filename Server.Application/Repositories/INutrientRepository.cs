using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface INutrientRepository : IGenericRepository<Nutrient>
    {
        public Task<IEnumerable<Nutrient>> GetNutrients();
        public Task<Nutrient> GetNutrientById(Guid nutrientId);
        public void DeleteNutrient(Nutrient nutrient);
        public Task<List<Nutrient>> GetByListName(List<string> names);
    }
}
