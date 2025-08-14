using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IAllergyCategoryRepository : IGenericRepository<AllergyCategory>
    {
        public Task<AllergyCategory> GetAllergyCategoryById(Guid allergyId); 
        public void DeleteAllergyCategory(AllergyCategory allergyCategory);  
        public Task<AllergyCategory> GetAllergyCategoryByName(string Name);
    }
}
