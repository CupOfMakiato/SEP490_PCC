using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface ISubCategoryRepository : IGenericRepository<SubCategory>
    {
        public Task<ICollection<SubCategory>> GetAllSubCategories();
        public Task<SubCategory> GetSubCategoryById(Guid id);
        public Task<SubCategory> GetSubCategoryByName(string name);
    }
}
