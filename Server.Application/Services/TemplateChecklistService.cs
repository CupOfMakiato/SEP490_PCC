using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.TemplateChecklist;
using Server.Application.DTOs.UserChecklist;
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
    public class TemplateChecklistService : ITemplateChecklistService
    {
        private readonly ITemplateChecklistRepository _templateChecklistRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;

        public TemplateChecklistService(
            ITemplateChecklistRepository templateChecklistRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IClaimsService claimsService)
        {
            _templateChecklistRepository = templateChecklistRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;
        }

        private ViewTemplateChecklistDTO MapTemplateChecklistDTO(TemplateChecklist checklist, Guid growthDataId)
        {
            var link = checklist.TemplateChecklistGrowthDatas
                .FirstOrDefault(x => x.GrowthDataId == growthDataId);

            return new ViewTemplateChecklistDTO
            {
                Id = checklist.Id,
                GrowthDataId = growthDataId,
                TaskName = checklist.TaskName,
                Trimester = checklist.Trimester,
                IsCompleted = link?.IsCompleted ?? false,
                CompletedDate = link?.CompletedDate,
                IsActive = checklist.IsActive
            };
        }



        public async Task<Result<List<ViewTemplateChecklistDTO>>> ViewAllTemplateChecklists(Guid growthDataId)
        {
            var checklists = await _templateChecklistRepository.GetAllActiveTemplateChecklists(); 

            var result = checklists
                .Select(c => MapTemplateChecklistDTO(c, growthDataId))
                .ToList();

            return new Result<List<ViewTemplateChecklistDTO>>
            {
                Error = 0,
                Message = "Retrieved template checklists successfully",
                Data = result
            };
        }

    }
}
