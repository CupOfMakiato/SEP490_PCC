using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface IVitaminRepository : IGenericRepository<Vitamin>
    {
        public Task<IEnumerable<Vitamin>> GetVitamins();
        public Task<Vitamin> GetVitaminById(Guid vitaminId);
        public void DeleteVitamin(Vitamin vitamin);
    }
}
