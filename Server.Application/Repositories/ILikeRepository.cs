using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface ILikeRepository : IGenericRepository<Like>
    {
        // view
        Task<List<Like>> GetAllLikes();
        Task<List<Like>> GetAllLikedBlogsFromUser(Guid userId);
        // count
        Task<int> CountLikesByBlogId(Guid blogId);
        // check like
        Task<Like> IsBlogLikedByUser(Guid blogId, Guid userId);
    }
}
