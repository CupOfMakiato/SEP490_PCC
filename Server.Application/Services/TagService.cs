using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.Tag;
using Server.Application.Interfaces;
using Server.Application.Mappers.TagExtensions;
using Server.Application.Repositories;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TagService(IUnitOfWork unitOfWork, IMapper mapper, ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<List<ViewTagDTO>>> ViewAllTags()
        {
            var result = _mapper.Map<List<ViewTagDTO>>(await _unitOfWork.TagRepository.GetAllTags());

            return new Result<List<ViewTagDTO>>
            {
                Error = 0,
                Message = "View all tags successfully",
                Data = result
            };
        }
        public async Task<Result<ViewTagDTO>> ViewTagById(Guid tagId)
        {
            var result = _mapper.Map<ViewTagDTO>(await _unitOfWork.TagRepository.GetTagById(tagId));
            return new Result<ViewTagDTO>
            {
                Error = 0,
                Message = "View tag successfully",
                Data = result
            };
        }

        public async Task<Result<object>> AddNewTag(AddTagDTO addTagDTO)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(addTagDTO.UserId);
            if (user == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not exist!",
                    Data = null
                };
            }
            var tagMapper = addTagDTO.ToTag();

            // Save tag to database
            await _unitOfWork.TagRepository.AddAsync(tagMapper);
            var result = await _unitOfWork.SaveChangeAsync();
            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Add new tag successfully" : "Add new tag fail",
                Data = result
            };
        }


    }
}
