using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface IMediaRepository : IGenericRepository<Media>
    {
        Task<List<Media>> GetAllMedias();
        Task<List<Media>> GetMediaByBlogId(Guid blogId);
        Task<Media> GetMediaById(Guid id);
        Task<int> GetTotalMediaCount();

    }
}

