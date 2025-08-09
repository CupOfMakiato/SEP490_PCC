using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Symptom;
using Server.Application.DTOs.TemplateChecklist;
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
    public class RecordedSymptomService : IRecordedSymptomService
    {
        private readonly IRecordedSymptomRepository _symptomRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;
        public RecordedSymptomService(IRecordedSymptomRepository symptomRepository,
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

        private ViewSymptomDTO MapTemplateSymptomDTO(RecordedSymptom recordedSymptom, Guid journalId)
        {
            var link = recordedSymptom.JournalSymptoms
                .FirstOrDefault(x => x.JournalId == journalId);

            return new ViewSymptomDTO
            {
                Id = recordedSymptom.Id,
                JournalId = journalId,
                SymptomName = recordedSymptom.SymptomName,
                IsChecked = link?.IsChecked ?? false,
                CheckedDate = link?.CheckedDate,
                IsActive = recordedSymptom.IsActive
            };
        }
        public async Task<Result<List<ViewSymptomDTO>>> ViewAllSymptoms(Guid journalId)
        {
            var symptoms = await _symptomRepository.GetAllSymptoms();
            var result = symptoms
                .Select(c => MapTemplateSymptomDTO(c, journalId))
                .ToList();

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

        public async Task<Result<object>> AddNewTemplateSymptom(AddSymptomDTO addSymptomDTO)
        {
            var currentuser = _claimsService.GetCurrentUserId;
            var user = await _unitOfWork.UserRepository.GetByIdAsync(currentuser);
            if (user == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not exist!",
                    Data = null
                };
            }

            // Capitalized the first letter

            var inputName = addSymptomDTO.SymptomName.Trim();
            inputName = char.ToUpper(inputName[0]) + inputName.Substring(1).ToLower();

            var templateName = await _symptomRepository.IsTemplateSymptomExistsByName(inputName);
            if (templateName)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "A template symptom with this name already exists.",
                    Data = null
                };
            }

            var existing = await _unitOfWork.SymptomRepository.GetTemplateSymptomsByUser(currentuser);
            var isDuplicate = await _unitOfWork.SymptomRepository.IsSymptomNameDuplicateForUser(addSymptomDTO.SymptomName, currentuser);

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
                Data = symptom.SymptomName
            };
        }
        public async Task<Result<object>> EditTemplateSymptom(EditSymptomDTO editSymptomDTO)
        {
            var currentUser = _claimsService.GetCurrentUserId;
            var user = await _unitOfWork.UserRepository.GetByIdAsync(currentUser);

            if (user == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not exist!",
                    Data = null
                };
            }

            // Find the existing symptom
            var symptom = await _unitOfWork.SymptomRepository.GetByIdAsync(editSymptomDTO.SymptomId);
            if (symptom == null || !symptom.IsActive)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Symptom not found or inactive.",
                    Data = null
                };
            }

            // Capitalize the first letter of the new name
            var inputName = editSymptomDTO.SymptomName.Trim();
            inputName = char.ToUpper(inputName[0]) + inputName.Substring(1).ToLower();

            // Check if another template symptom already exists with the same name
            var templateExists = await _symptomRepository.IsTemplateSymptomExistsByName(inputName);
            if (templateExists && !string.Equals(symptom.SymptomName, inputName, StringComparison.OrdinalIgnoreCase))
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "A template symptom with this name already exists.",
                    Data = null
                };
            }

            // Check for duplicate within the user's template symptoms
            var isDuplicate = await _unitOfWork.SymptomRepository.IsSymptomNameDuplicateForUser(inputName, editSymptomDTO.UserId);
            if (isDuplicate && !string.Equals(symptom.SymptomName, inputName, StringComparison.OrdinalIgnoreCase))
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "You already have a symptom with this name.",
                    Data = null
                };
            }

            symptom.IsActive = editSymptomDTO.IsActive ?? symptom.IsActive;
            symptom.SymptomName = inputName;
            symptom.ModificationBy = currentUser;
            symptom.ModificationDate = DateTime.Now;

            _unitOfWork.SymptomRepository.Update(symptom);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Symptom updated successfully" : "Failed to update symptom",
                Data = symptom.SymptomName
            };
        }
        public async Task<Result<List<ViewSymptomDTO>>> ViewAllCheckedTemplateSymptoms()
        {
            var symptoms = await _symptomRepository.GetAllCheckedTemplateSymptoms();
            var result = _mapper.Map<List<ViewSymptomDTO>>(symptoms);
            return new Result<List<ViewSymptomDTO>>
            {
                Error = 0,
                Message = "Retrieved all checked template symptoms successfully",
                Data = result
            };
        }
        public async Task<Result<List<ViewSymptomDTO>>> ViewAllUncheckedTemplateSymptoms()
        {
            var symptoms = await _symptomRepository.GetAllUnCheckedTemplateSymptoms();
            var result = _mapper.Map<List<ViewSymptomDTO>>(symptoms);
            return new Result<List<ViewSymptomDTO>>
            {
                Error = 0,
                Message = "Retrieved all unchecked template symptoms successfully",
                Data = result
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
        public async Task<Result<object>> MarkTemplateSymptomAsChecked(Guid symptomId)
        {
            var currentUser = _claimsService.GetCurrentUserId;

            var symptom = await _unitOfWork.SymptomRepository.GetSymptomById(symptomId);
            if (symptom == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Symptom not found.",
                    Data = null
                };
            }

            var currentJournal = await _unitOfWork.JournalRepository.GetCurrentJournalByUser(currentUser);
            if (currentJournal == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "No active journal found for user.",
                    Data = null
                };
            }

            var existingJournalSymptom = symptom.JournalSymptoms
                .FirstOrDefault(js => js.JournalId == currentJournal.Id);

            if (existingJournalSymptom == null)
            {
                // create with IsChecked = true
                existingJournalSymptom = new JournalSymptom
                {
                    JournalId = currentJournal.Id,
                    RecordedSymptomId = symptom.Id,
                    IsChecked = true,
                    CheckedDate = DateTime.UtcNow
                };

                symptom.JournalSymptoms.Add(existingJournalSymptom);
            }
            else
            {
                if (!existingJournalSymptom.IsChecked) // false/null switch true
                {
                    existingJournalSymptom.IsChecked = true;
                    existingJournalSymptom.CheckedDate = DateTime.UtcNow;
                }
                else // true switch false
                {
                    existingJournalSymptom.IsChecked = false;
                    existingJournalSymptom.CheckedDate = null;
                }
            }

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Symptom status toggled successfully." : "Failed to toggle symptom status.",
                Data = new
                {
                    //SymptomId = symptom.Id,
                    SymptomName = symptom.SymptomName,
                    IsChecked = existingJournalSymptom.IsChecked,
                    CheckedDate = existingJournalSymptom.CheckedDate
                }
            };
        }

        public async Task<Result<object>> MarkSymptomAsActive (Guid symptomId)
        {
            var currentUser = _claimsService.GetCurrentUserId;
            var user = await _unitOfWork.UserRepository.GetByIdAsync(currentUser);
            if (user == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not exist!",
                    Data = null
                };
            }
            var symptom = await _unitOfWork.SymptomRepository.GetSymptomById(symptomId);
            if (symptom == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Symptom not found.",
                    Data = null
                };
            }
            if (!symptom.IsActive)
            {
                symptom.IsActive = true;
            }
            else
            {
               symptom.IsActive = false; 
            }

            var result = await _unitOfWork.SaveChangeAsync();
            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Symptom status toggled successfully." : "Failed to toggle symptom status.",
                Data = new
                {
                    SymptomName = symptom.SymptomName
                }
            };
        }


        public async Task<Result<object>> DeleteRecordedSymptom(Guid id)
        {
            var symptom = await _symptomRepository.GetSymptomById(id);
            if (symptom == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Symptom not found",
                    Data = null
                };
            }
            symptom.IsActive = false;
            _symptomRepository.SoftRemove(symptom);
            var result = await _unitOfWork.SaveChangeAsync();
            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Symptom deleted successfully" : "Failed to delete symptom",
                Data = null
            };
        }
    }
}