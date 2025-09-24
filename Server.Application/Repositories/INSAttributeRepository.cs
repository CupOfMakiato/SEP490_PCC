using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface INSAttributeRepository : IGenericRepository<NSAttribute>
    {
        public Task<NSAttribute> GetNSAttributeById(Guid id);
        public void Remove(NSAttribute nSAttribute);
    }
}
