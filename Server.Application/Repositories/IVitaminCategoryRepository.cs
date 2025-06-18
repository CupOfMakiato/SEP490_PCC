using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface IVitaminCategoryRepository : IGenericRepository<VitaminCategory>
    {
        public Task<List<VitaminCategory>> GetVitaminCategorys();
        public Task<VitaminCategory> GetVitaminCategoryById(Guid vitaminCategoryId);
    }
}
