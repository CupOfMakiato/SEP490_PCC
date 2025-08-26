using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IAllergyRepository : IGenericRepository<Allergy>
    {
        Task<List<Allergy>> GetAllAllergies();
        Task<Allergy> GetAllergyById(Guid allergyId);
        public void DeleteAllergy(Allergy allergy);    
    }
}
