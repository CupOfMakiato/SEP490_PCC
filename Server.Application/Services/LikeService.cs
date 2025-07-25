using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Like;
using Server.Application.DTOs.Symptom;
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
        private readonly IMapper _mapper;
        public LikeService(ILikeRepository likeRepository, IClaimsService claimsService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _claimsService = claimsService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<List<ViewAllLikeDTO>>> ViewAllLikedBlogFromUser(Guid userId)
        {
            var likes = await _likeRepository.GetAllLikedBlogsFromUser(userId);
            var result = _mapper.Map<List<ViewAllLikeDTO>>(likes);
            return new Result<List<ViewAllLikeDTO>>
            {
                Error = 0,
                Message = "Retrieved liked blogs successfully",
                Data = result
            };
        }
        public async Task LikeABlog(Guid blogId)
        {
            var userId = _claimsService.GetCurrentUserId;

            var like = await _likeRepository.IsBlogLikedByUser(blogId, userId);

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
        public async Task<Result<object>> SoftDeleteLike(Guid blogId)
        {
            var userId = _claimsService.GetCurrentUserId;

            var bookmark = await _likeRepository.IsBlogLikedByUser(blogId, userId);

            if (bookmark == null || bookmark.IsDeleted)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Like not found or already deleted"
                };
            }

            bookmark.IsDeleted = true;
            await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = 0,
                Message = "Like removed successfully"
            };
        }
    }
}
