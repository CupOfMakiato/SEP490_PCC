using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Blog;
using Server.Application.DTOs.GrowthData;
using Server.Application.DTOs.Journal;
using Server.Application.DTOs.Symptom;
using Server.Application.DTOs.User;
using Server.Application.Interfaces;
using Server.Application.Mappers.JournalExtensions;
using Server.Application.Repositories;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Services
{
    public class JournalService : IJournalService
    {
        private readonly IJournalRepository _journalRepository;
        private readonly ICurrentTime _currentTime;
        private readonly IClaimsService _claimsService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ISymptomService _symptomService;
        private readonly ISymptomRepository _symptomRepository;


        public JournalService(IUnitOfWork unitOfWork, IMapper mapper, IJournalRepository journalRepository,
            ICurrentTime currentTime, IClaimsService claimsService, ICloudinaryService cloudinaryService,
            ISymptomService symptomService, ISymptomRepository symptomRepository)
        {
            _journalRepository = journalRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentTime = currentTime;
            _claimsService = claimsService;
            _cloudinaryService = cloudinaryService;
            _symptomService = symptomService;
            _symptomRepository = symptomRepository;
        }
        private async Task<ViewJournalDTO> MapJournalToViewJournalDTO(Journal journal)
        {
            // manual mapper hehehe hetcuu
            var userId = journal.CreatedBy;
            var allSymptoms = await _symptomRepository.GetAllSymptomsForUser((Guid)userId);

            return new ViewJournalDTO
            {
                Id = journal.Id,
                CurrentWeek = journal.CurrentWeek,
                CurrentTrimester = journal.CurrentTrimester,
                Note = journal.Note,
                CurrentWeight = journal.CurrentWeight,
                Mood = journal.MoodNotes.ToString(),
                CreatedByUser = journal.JournalCreatedBy != null
                    ? new GetUserDTO
                    {
                        Id = journal.JournalCreatedBy.Id,
                        UserName = journal.JournalCreatedBy.UserName
                    }
                    : null,
                Symptoms = allSymptoms.Select(s => new SymptomDTO
                {
                    SymptomName = s.SymptomName,
                    IsTemplate = s.IsTemplate
                }).ToList()
            };
        }

        public async Task<Result<List<ViewJournalDTO>>> ViewAllJournals()
        {
            var journals = await _unitOfWork.JournalRepository.GetAllJournals();
            var result = new List<ViewJournalDTO>();

            foreach (var journal in journals)
            {
                var dto = await MapJournalToViewJournalDTO(journal);
                result.Add(dto);
            }

            return new Result<List<ViewJournalDTO>>
            {
                Error = 0,
                Message = "View all journals successfully",
                Data = result
            };
        }

        public async Task<Result<ViewJournalDTO>> ViewJournalById(Guid journalId)
        {
            var journal = await _unitOfWork.JournalRepository.GetJournalById(journalId);
            if (journal == null)
            {
                return new Result<ViewJournalDTO>
                {
                    Error = 1,
                    Message = "Journal not found",
                    Data = null
                };
            }

            var dto = await MapJournalToViewJournalDTO(journal);

            return new Result<ViewJournalDTO>
            {
                Error = 0,
                Message = "View journal by id successfully",
                Data = dto
            };
        }

        public async Task<Result<List<ViewJournalDTO>>> ViewJournalsByGrowthDataId(Guid growthDataId)
        {
            var journals = await _unitOfWork.JournalRepository.GetJournalsByGrowthDataId(growthDataId);
            if (journals == null || !journals.Any())
            {
                return new Result<List<ViewJournalDTO>>
                {
                    Error = 1,
                    Message = "No journals found for this growth data",
                    Data = null
                };
            }

            var result = new List<ViewJournalDTO>();

            foreach (var journal in journals)
            {
                var dto = await MapJournalToViewJournalDTO(journal);
                result.Add(dto);
            }

            return new Result<List<ViewJournalDTO>>
            {
                Error = 0,
                Message = "View journals by growth data id successfully",
                Data = result
            };
        }

        public async Task<Result<object>> CreateNewJournalEntryForCurrentWeek(CreateNewJournalEntryForCurrentWeekDTO CreateNewJournalEntryForCurrentWeekDTO)
        {
            //var GetCurrentUserId = _claimsService.GetCurrentUserId;
            var user = await _unitOfWork.UserRepository.GetByIdAsync(CreateNewJournalEntryForCurrentWeekDTO.UserId);
            if (user == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "User does not exist!",
                    Data = null
                };
            }
            var growthData = await _unitOfWork.GrowthDataRepository.GetGrowthDataById(CreateNewJournalEntryForCurrentWeekDTO.GrowthDataId);
            if (growthData == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Growth data not found.",
                    Data = null
                };
            }

            var today = _currentTime.GetCurrentTime().Date;
            int currentWeek = growthData.GetCurrentGestationalAgeInWeeks(today);
            int trimester = growthData.GetCurrentTrimester(today);


            var existingJournals = await _unitOfWork.JournalRepository
                .GetJournalFromGrowthDataByWeekAndTrimester(CreateNewJournalEntryForCurrentWeekDTO.Id, currentWeek, trimester);

            if (existingJournals.Any())
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = $"You already have a journal entry for week {currentWeek}.",
                    Data = null
                };
            }

            var journal = CreateNewJournalEntryForCurrentWeekDTO.ToJournal();

            var resolvedSymptoms = await _symptomService.ReuseExistingOrAddNewCustom(CreateNewJournalEntryForCurrentWeekDTO.UserId, CreateNewJournalEntryForCurrentWeekDTO.SymptomNames);

            foreach (var symptom in resolvedSymptoms)
            {
                journal.JournalSymptoms.Add(new JournalSymptom
                {
                    Journal = journal,
                    RecordedSymptom = symptom
                });
            }

            // Upload Images
            if (CreateNewJournalEntryForCurrentWeekDTO.RelatedImages != null && CreateNewJournalEntryForCurrentWeekDTO.RelatedImages.Any())
            {
                if (CreateNewJournalEntryForCurrentWeekDTO.RelatedImages.Count > 2)
                {
                    return new Result<object>
                    {
                        Error = 1,
                        Message = "You can upload a maximum of 2 images per entry.",
                        Data = null
                    };
                }

                foreach (var image in CreateNewJournalEntryForCurrentWeekDTO.RelatedImages)
                {
                    var response = await _cloudinaryService.UploadJournalImage(image.FileName, image, journal);
                    if (response != null)
                    {
                        journal.Media.Add(new Media
                        {
                            JournalId = journal.Id,
                            FileName = image.FileName,
                            FileUrl = response.FileUrl,
                            FilePublicId = response.PublicFileId,
                            FileType = image.ContentType
                        });
                    }
                }
            }
            if (CreateNewJournalEntryForCurrentWeekDTO.UltraSoundImages != null && CreateNewJournalEntryForCurrentWeekDTO.UltraSoundImages.Any())
            {
                if (CreateNewJournalEntryForCurrentWeekDTO.UltraSoundImages.Count > 2)
                {
                    return new Result<object>
                    {
                        Error = 1,
                        Message = "You can upload a maximum of 2 images per entry.",
                        Data = null
                    };
                }

                foreach (var image in CreateNewJournalEntryForCurrentWeekDTO.UltraSoundImages)
                {
                    var response = await _cloudinaryService.UploadJournalImage(image.FileName, image, journal);
                    if (response != null)
                    {
                        journal.Media.Add(new Media
                        {
                            JournalId = journal.Id,
                            FileName = image.FileName,
                            FileUrl = response.FileUrl,
                            FilePublicId = response.PublicFileId,
                            FileType = image.ContentType
                        });
                    }
                }
            }

            await _unitOfWork.JournalRepository.AddAsync(journal);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0
                    ? $"Journal entry for week {currentWeek} created successfully."
                    : "Failed to create journal entry.",
                Data = result > 0 ? new {CurrentWeek = currentWeek} : null
            };
        }
        public async Task<Result<object>> EditJournalEntry(EditJournalEntryDTO EditJournalEntryDTO)
        {
            var user = _claimsService.GetCurrentUserId;

            var journal = await _unitOfWork.JournalRepository.GetJournalById(EditJournalEntryDTO.Id);
            if (journal == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Journal entry not found.",
                    Data = null
                };
            }

            journal.Note = EditJournalEntryDTO.Note;
            journal.MoodNotes = (Domain.Enums.Mood)EditJournalEntryDTO.MoodNotes;
            journal.CurrentWeight = EditJournalEntryDTO.CurrentWeight;
            
            journal.ModificationBy = user;
            journal.ModificationDate = _currentTime.GetCurrentTime();

            journal.JournalSymptoms.Clear();
            foreach (var name in EditJournalEntryDTO.SymptomNames.Distinct())
            {
                var newSymptom = new RecordedSymptom
                {
                    SymptomName = name,
                    IsTemplate = false,
                    CreatedBy = user,
                    CreationDate = _currentTime.GetCurrentTime(),
                    IsActive = true
                };

                await _unitOfWork.SymptomRepository.AddAsync(newSymptom);
                journal.JournalSymptoms.Add(new JournalSymptom
                {
                    Journal = journal,
                    RecordedSymptom = newSymptom
                });
            }


            if (EditJournalEntryDTO.RelatedImages != null)
            {
                // Delete all previous images uploaded by RelatedImages
                var existingMedia = journal.Media.ToList(); // All media
                foreach (var media in existingMedia)
                {
                    // delete ALL and reupload fresh if RelatedImages provided
                    if (!string.IsNullOrEmpty(media.FilePublicId))
                        await _cloudinaryService.DeleteFileAsync(media.FilePublicId);
                }
                journal.Media.Clear();

                if (EditJournalEntryDTO.RelatedImages.Any())
                {
                    if (EditJournalEntryDTO.RelatedImages.Count > 2)
                    {
                        return new Result<object>
                        {
                            Error = 1,
                            Message = "You can upload a maximum of 2 related images.",
                            Data = null
                        };
                    }

                    foreach (var image in EditJournalEntryDTO.RelatedImages)
                    {
                        var response = await _cloudinaryService.UploadJournalImage(image.FileName, image, journal);
                        if (response != null)
                        {
                            journal.Media.Add(new Media
                            {
                                JournalId = journal.Id,
                                FileName = image.FileName,
                                FileUrl = response.FileUrl,
                                FilePublicId = response.PublicFileId,
                                FileType = image.ContentType
                            });
                        }
                    }
                }
            }

            if (EditJournalEntryDTO.UltraSoundImages != null)
            {
                // Delete all existing images again if needed
                var existingMedia = journal.Media.ToList(); 
                foreach (var media in existingMedia)
                {
                    if (!string.IsNullOrEmpty(media.FilePublicId))
                        await _cloudinaryService.DeleteFileAsync(media.FilePublicId);
                }
                journal.Media.Clear();

                if (EditJournalEntryDTO.UltraSoundImages.Any())
                {
                    if (EditJournalEntryDTO.UltraSoundImages.Count > 2)
                    {
                        return new Result<object>
                        {
                            Error = 1,
                            Message = "You can upload a maximum of 2 ultrasound images.",
                            Data = null
                        };
                    }

                    foreach (var image in EditJournalEntryDTO.UltraSoundImages)
                    {
                        var response = await _cloudinaryService.UploadJournalImage(image.FileName, image, journal);
                        if (response != null)
                        {
                            journal.Media.Add(new Media
                            {
                                JournalId = journal.Id,
                                FileName = image.FileName,
                                FileUrl = response.FileUrl,
                                FilePublicId = response.PublicFileId,
                                FileType = image.ContentType
                            });
                        }
                    }
                }
            }

            _unitOfWork.JournalRepository.Update(journal);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Journal updated successfully." : "Failed to update journal.",
                Data = null
            };
        }

        public async Task<Result<object>> DeleteJournal(Guid journalId)
        {
            var existingData = await _unitOfWork.JournalRepository.GetJournalById(journalId);
            if (existingData == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Journal not found",
                    Data = null
                };
            }

            _unitOfWork.JournalRepository.SoftRemove(existingData);

            // Save the changes
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Journal deleted successfully" : "Failed to delete Journal",
                Data = null
            };
        }
    }
}
