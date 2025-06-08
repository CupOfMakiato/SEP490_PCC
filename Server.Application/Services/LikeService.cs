using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IClaimsService _claimsService;
        private readonly IUnitOfWork _unitOfWork;
        public LikeService(ILikeRepository likeRepository, IClaimsService claimsService, IUnitOfWork unitOfWork)
        {
            _likeRepository = likeRepository;
            _claimsService = claimsService;
            _unitOfWork = unitOfWork;
        }

        public async Task LikeABlog(Guid blogId)
        {
            var userId = _claimsService.GetCurrentUserId;

            var like = await _likeRepository.IsBlogLikedByUser(userId, blogId);

            if (like == null)
            {
                // Create new
                like = new Like
                {
                    BlogId = blogId,
                    UserId = userId,
                    LikedAt = DateTime.UtcNow
                };
                await _likeRepository.AddAsync(like);
            }
            else if (like.IsDeleted)
            {
                // Reactivate (undo soft delete)
                like.IsDeleted = false;
                like.LikedAt = DateTime.UtcNow;
            }
            else
            {
                // Soft delete (unlike)
                like.IsDeleted = true;
            }

            await _unitOfWork.SaveChangeAsync();
        }
    }
}
