using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Task<ICollection<Category>> GetAllCategories();
        public Task<Category> GetCategoryById(Guid id);
        public Task<Category> GetCategoryByName(string name);
        Task<List<Category>> GetAllActiveCategories();
        Task<List<Category>> GetCategoryNotDeleted();
    }
}
