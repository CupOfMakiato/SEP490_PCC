using AutoMapper;
using Server.Application.Abstractions.Shared;
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
    public class SymptomService : ISymptomService
    {
        private readonly ISymptomRepository _symptomRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;
        public SymptomService(ISymptomRepository symptomRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IClaimsService claimsService
            )
        {
            _symptomRepository = symptomRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;
        }
        public async Task<Result<List<ViewSymptomDTO>>> ViewAllSymptoms()
        {
            var symptoms = await _symptomRepository.GetAllSymptoms();
            var result = _mapper.Map<List<ViewSymptomDTO>>(symptoms);
            return new Result<List<ViewSymptomDTO>>
            {
                Error = 0,
                Message = "Retrieved symptoms successfully",
                Data = result
            };
        }
        public async Task<Result<List<ViewSymptomDTO>>> ViewAllSymptomsForUser(Guid userId)
        {
            var symptoms = await _symptomRepository.GetAllSymptomsForUser(userId);
            var result = _mapper.Map<List<ViewSymptomDTO>>(symptoms);

            return new Result<List<ViewSymptomDTO>>
            {
                Error = 0,
                Message = "Retrieved all symptoms plus cumtom-added successfully",
                Data = result
            };
        }

        public async Task<Result<ViewSymptomDTO>> ViewSymptomById(Guid id)
        {
            var symptom = await _symptomRepository.GetSymptomById(id);
            if (symptom == null)
            {
                return new Result<ViewSymptomDTO>
                {
                    Error = 1,
                    Message = "Symptom not found",
                    Data = null
                };
            }

            return new Result<ViewSymptomDTO>
            {
                Error = 0,
                Message = "Symptom retrieved successfully",
                Data = _mapper.Map<ViewSymptomDTO>(symptom)
            };
        }

        public async Task<Result<object>> AddNewCustomSymptom(AddSymptomDTO addSymptomDTO)
        {
            var currentuser = _claimsService.GetCurrentUserId;
            var user = await _unitOfWork.UserRepository.GetByIdAsync(addSymptomDTO.UserId);
            if (user == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not exist!",
                    Data = null
                };
            }

            var customName = addSymptomDTO.SymptomName.Trim().ToLower();

            var templateName = await _symptomRepository.IsTemplateSymptomExistsByName(customName);
            if (templateName)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "A template symptom with this name already exists.",
                    Data = null
                };
            }

            var existing = await _unitOfWork.SymptomRepository.GetCustomSymptomsByUser(addSymptomDTO.UserId);
            var isDuplicate = await _unitOfWork.SymptomRepository.IsSymptomNameDuplicateForUser(addSymptomDTO.SymptomName, addSymptomDTO.UserId);

            if (isDuplicate)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "You already have a symptom with this name.",
                    Data = null
                };
            }

            var symptom = new RecordedSymptom
            {
                SymptomName = addSymptomDTO.SymptomName,
                IsTemplate = false,
                CreatedBy = currentuser,
                CreationDate = DateTime.Now,
                IsActive = true
            };

            await _unitOfWork.SymptomRepository.AddAsync(symptom);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Symptom added successfully" : "Failed to add symptom",
                Data = symptom.Id
            };
        }
        public async Task<List<RecordedSymptom>> ReuseExistingOrAddNewCustom(Guid userId, IEnumerable<string> symptomNames)
        {
            var user = _claimsService.GetCurrentUserId;
            var resolved = new List<RecordedSymptom>();

            foreach (var name in symptomNames.Distinct(StringComparer.OrdinalIgnoreCase))
            {
                var existingSymptom = await _symptomRepository.FindReusableSymptom(name, userId);

                if (existingSymptom != null)
                {
                    resolved.Add(existingSymptom);
                }
                else
                {
                    var newSymptom = new RecordedSymptom
                    {
                        SymptomName = name.Trim(),
                        IsTemplate = false,
                        CreatedBy = user,
                        CreationDate = DateTime.Now,
                        IsActive = true
                    };

                    await _symptomRepository.AddAsync(newSymptom);
                    resolved.Add(newSymptom);
                }
            }

            return resolved;
        }

    }
}