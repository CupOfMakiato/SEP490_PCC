using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Like;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface ILikeService
    {
        Task LikeABlog(Guid blogId);
        Task<Result<List<ViewAllLikeDTO>>> ViewAllLikedBlogFromUser(Guid userId);
        Task<Result<object>> SoftDeleteLike(Guid blogId);
    }
}
