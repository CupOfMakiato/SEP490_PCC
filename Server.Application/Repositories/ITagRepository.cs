using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        // view
        Task<List<Tag>> GetAllTags();
        Task<Tag> GetTagById(Guid id);
        Task<Tag?> GetTagByName(string name);
    }
}
