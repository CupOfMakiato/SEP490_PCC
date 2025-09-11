using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.BasicBioMetric;
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
        private readonly IRecordedSymptomService _symptomService;
        private readonly IRecordedSymptomRepository _symptomRepository;
        private readonly IBasicBioMetricService _basicBioMetricService;
        private readonly ITailoredCheckupReminderService _tailoredCheckupReminderService;
        private readonly INotificationService _notificationService;


        public JournalService(IUnitOfWork unitOfWork, IMapper mapper, IJournalRepository journalRepository,
            ICurrentTime currentTime, IClaimsService claimsService, ICloudinaryService cloudinaryService,
            IRecordedSymptomService symptomService, IRecordedSymptomRepository symptomRepository, IBasicBioMetricService basicBioMetricService,
            ITailoredCheckupReminderService tailoredCheckupReminderService, INotificationService notificationService)
        {
            _journalRepository = journalRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentTime = currentTime;
            _claimsService = claimsService;
            _cloudinaryService = cloudinaryService;
            _symptomService = symptomService;
            _symptomRepository = symptomRepository;
            _basicBioMetricService = basicBioMetricService;
            _tailoredCheckupReminderService = tailoredCheckupReminderService;
            _notificationService = notificationService;
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
                    SymptomName = s.SymptomName
                }).ToList()
            };
        }
        private async Task<ViewJournalDetailDTO> MapJournalToViewJournalDetailDTO(Journal journal)
        {
            var relatedImages = journal.Media?
                .Where(m => m.FilePublicId != null && m.FilePublicId.Contains("journal-related"))
                .Select(m => m.FileUrl)
                .ToList() ?? new List<string>();

            var ultrasoundImages = journal.Media?
                .Where(m => m.FilePublicId != null && m.FilePublicId.Contains("journal-ultrasound"))
                .Select(m => m.FileUrl)
                .ToList() ?? new List<string>();

            return new ViewJournalDetailDTO
            {
                Id = journal.Id,
                CurrentWeek = journal.CurrentWeek,
                CurrentTrimester = journal.CurrentTrimester,
                CurrentWeight = journal.CurrentWeight,
                SystolicBP = journal.SystolicBP,
                DiastolicBP = journal.DiastolicBP,
                HeartRateBPM = journal.HeartRateBPM,
                BloodSugarLevelMgDl = journal.BloodSugarLevelMgDl,
                Note = journal.Note,
                Mood = journal.MoodNotes.ToString(),
                CreatedByUser = journal.JournalCreatedBy != null
                    ? new GetUserDTO
                    {
                        Id = journal.JournalCreatedBy.Id,
                        UserName = journal.JournalCreatedBy.UserName
                    }
                    : null,
                Symptoms = journal.JournalSymptoms
                    .Where(js => js.RecordedSymptom.IsActive && !js.RecordedSymptom.IsDeleted)
                    .Select(js => new SymptomDTO
                    {
                        SymptomName = js.RecordedSymptom.SymptomName
                    })
                    .ToList(),
                RelatedImages = relatedImages,
                UltraSoundImages = ultrasoundImages
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

        public async Task<Result<ViewJournalDetailDTO>> ViewJournalById(Guid journalId)
        {
            var journal = await _unitOfWork.JournalRepository.GetJournalById(journalId);
            if (journal == null)
            {
                return new Result<ViewJournalDetailDTO>
                {
                    Error = 1,
                    Message = "Journal not found",
                    Data = null
                };
            }

            var dto = await MapJournalToViewJournalDetailDTO(journal);

            return new Result<ViewJournalDetailDTO>
            {
                Error = 0,
                Message = "View journal by id successfully",
                Data = dto
            };
        }
        public async Task<Result<ViewJournalDetailDTO>> ViewJournalDetail(Guid journalId)
        {
            var journal = await _unitOfWork.JournalRepository.GetJournalById(journalId);
            if (journal == null)
            {
                return new Result<ViewJournalDetailDTO>
                {
                    Error = 1,
                    Message = "Journal not found",
                    Data = null
                };
            }

            var dto = await MapJournalToViewJournalDetailDTO(journal);

            return new Result<ViewJournalDetailDTO>
            {
                Error = 0,
                Message = "View journal detail successfully",
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
            int currentWeek = CreateNewJournalEntryForCurrentWeekDTO.CurrentWeek;

            int currentTrimester = currentWeek switch
            {
                <= 13 => 1,
                <= 27 => 2,
                _ => 3
            };

            if (growthData.FirstDayOfLastMenstrualPeriod != null)
            {
                var gestationalDays = (today - growthData.FirstDayOfLastMenstrualPeriod.Date).TotalDays;
                int actualWeek = (int)(gestationalDays / 7) + 1;

                if (currentWeek > actualWeek)
                {
                    return new Result<object>
                    {
                        Error = 1,
                        Message = $"You cannot create a journal entry for week {currentWeek} as it is in the future.",
                        Data = null
                    };
                }
            }

            var existingJournals = await _unitOfWork.JournalRepository
                .GetJournalFromGrowthDataByWeek(CreateNewJournalEntryForCurrentWeekDTO.GrowthDataId, currentWeek);

            if (existingJournals.Any())
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = $"You already have a journal entry for week {currentWeek}.",
                    Data = null
                };
            }

            // Validate BP input
            if ((CreateNewJournalEntryForCurrentWeekDTO.SystolicBP.HasValue && !CreateNewJournalEntryForCurrentWeekDTO.DiastolicBP.HasValue) ||
                (!CreateNewJournalEntryForCurrentWeekDTO.SystolicBP.HasValue && CreateNewJournalEntryForCurrentWeekDTO.DiastolicBP.HasValue))
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "You must provide both Systolic and Diastolic BP values together.",
                    Data = null
                };
            }

            var journal = CreateNewJournalEntryForCurrentWeekDTO.ToJournal();

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
                    var response = await _cloudinaryService.UploadJournalImage(image.FileName, image, journal, "journal-related");
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
                    var response = await _cloudinaryService.UploadJournalImage(image.FileName, image, journal, "journal-ultrasound");
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

            var resolvedSymptoms = await _symptomService.ReuseExistingOrAddNewCustom(CreateNewJournalEntryForCurrentWeekDTO.UserId, CreateNewJournalEntryForCurrentWeekDTO.SymptomNames);

            foreach (var symptom in resolvedSymptoms)
            {
                journal.JournalSymptoms.Add(new JournalSymptom
                {
                    JournalId = journal.Id,
                    RecordedSymptomId = symptom.Id
                });
            }

            await _unitOfWork.SaveChangeAsync();

            // after saving journal then update this too
            var editBbmDto = new EditBasicBioMetricDTO
            {
                Id = growthData.BasicBioMetric.Id,
                WeightKg = CreateNewJournalEntryForCurrentWeekDTO.CurrentWeight,
                SystolicBP = CreateNewJournalEntryForCurrentWeekDTO.SystolicBP,
                DiastolicBP = CreateNewJournalEntryForCurrentWeekDTO.DiastolicBP,
                HeartRateBPM = CreateNewJournalEntryForCurrentWeekDTO.HeartRateBPM,
                BloodSugarLevelMgDl = CreateNewJournalEntryForCurrentWeekDTO.BloodSugarLevelMgDl,
                Notes = $"System reacored from Journal week {currentWeek}"
            };

            // this service already have savechange sooooo no need to save again
            await _basicBioMetricService.EditBasicBioMetric(editBbmDto);

            var journalDto = new
            {
                journal.Id,
                journal.CurrentWeek,
                journal.CurrentWeight,
                journal.SystolicBP,
                journal.DiastolicBP,
                journal.HeartRateBPM,
                journal.BloodSugarLevelMgDl,
                journal.Note,
                Media = journal.Media.Select(m => new { m.FileUrl, m.FileType }),
                Symptoms = journal.JournalSymptoms.Select(js => js.RecordedSymptomId)
            };

            // Send notification after successful journal creation
            var notification = new Notification
            {
                Id = Guid.NewGuid(),
                Message = $"Your journal entry for week {currentWeek} was created successfully.",
                CreatedBy = CreateNewJournalEntryForCurrentWeekDTO.UserId,
                CreationDate = _currentTime.GetCurrentTime()
            };

            await _notificationService.CreateNotification(notification, journalDto, "Journal");

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
            // Validate BP input
            if ((EditJournalEntryDTO.SystolicBP.HasValue && !EditJournalEntryDTO.DiastolicBP.HasValue) ||
                (!EditJournalEntryDTO.SystolicBP.HasValue && EditJournalEntryDTO.DiastolicBP.HasValue))
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "You must provide both Systolic and Diastolic BP values together.",
                    Data = null
                };
            }

            journal.Note = EditJournalEntryDTO.Note ?? journal.Note;
            journal.MoodNotes = EditJournalEntryDTO.MoodNotes ?? journal.MoodNotes;
            journal.CurrentWeight = EditJournalEntryDTO.CurrentWeight ?? journal.CurrentWeight;
            
            journal.ModificationBy = user;
            journal.ModificationDate = _currentTime.GetCurrentTime();

            journal.JournalSymptoms.Clear();

            var resolvedSymptoms = await _symptomService.ReuseExistingOrAddNewCustom(
                user,
                EditJournalEntryDTO.SymptomNames.Distinct().ToList()
            );

            foreach (var symptom in resolvedSymptoms)
            {
                journal.JournalSymptoms.Add(new JournalSymptom
                {
                    JournalId = journal.Id,
                    RecordedSymptomId = symptom.Id
                });
            }



            // Related Images
            if (EditJournalEntryDTO.RelatedImages != null)
            {
                var relatedMedia = journal.Media
                    .Where(m => m.FileUrl.Contains("journal-related"))
                    .ToList();

                foreach (var media in relatedMedia)
                {
                    if (!string.IsNullOrEmpty(media.FilePublicId))
                        await _cloudinaryService.DeleteFileAsync(media.FilePublicId);

                    journal.Media.Remove(media);
                }

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
                    var response = await _cloudinaryService.UploadJournalImage(image.FileName, image, journal, "journal-related");
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

            // Ultrasound Images
            if (EditJournalEntryDTO.UltraSoundImages != null)
            {
                var ultrasoundMedia = journal.Media
                    .Where(m => m.FileUrl.Contains("journal-ultrasound"))
                    .ToList();

                foreach (var media in ultrasoundMedia)
                {
                    if (!string.IsNullOrEmpty(media.FilePublicId))
                        await _cloudinaryService.DeleteFileAsync(media.FilePublicId);

                    journal.Media.Remove(media);
                }

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
                    var response = await _cloudinaryService.UploadJournalImage(image.FileName, image, journal, "journal-ultrasound");
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

            _unitOfWork.JournalRepository.Update(journal);
            var result = await _unitOfWork.SaveChangeAsync();
            var growthData = await _unitOfWork.GrowthDataRepository.GetGrowthDataById(journal.GrowthDataId);

            if (growthData?.BasicBioMetric != null)
            {
                // calculate current gestational week
                var today = _currentTime.GetCurrentTime().Date;
                int actualWeek = 0;
                if (growthData.FirstDayOfLastMenstrualPeriod != null)
                {
                    var gestationalDays = (today - growthData.FirstDayOfLastMenstrualPeriod.Date).TotalDays;
                    actualWeek = (int)(gestationalDays / 7) + 1;
                }

                // only sync biometric if journal belongs to "closest" current week
                if (journal.CurrentWeek == actualWeek)
                {
                    var editBbmDto = new EditBasicBioMetricDTO
                    {
                        Id = growthData.BasicBioMetric.Id,
                        WeightKg = journal.CurrentWeight,
                        SystolicBP = EditJournalEntryDTO.SystolicBP ?? growthData.BasicBioMetric.SystolicBP,
                        DiastolicBP = EditJournalEntryDTO.DiastolicBP ?? growthData.BasicBioMetric.DiastolicBP,
                        HeartRateBPM = EditJournalEntryDTO.HeartRateBPM ?? growthData.BasicBioMetric.HeartRateBPM,
                        BloodSugarLevelMgDl = EditJournalEntryDTO.BloodSugarLevelMgDl ?? growthData.BasicBioMetric.BloodSugarLevelMgDl,
                        Notes = $"System updated from Journal week {journal.CurrentWeek} (edited)"
                    };

                    await _basicBioMetricService.EditBasicBioMetric(editBbmDto);
                }
            }

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Journal updated successfully." : "Failed to update journal.",
                Data = null
            };
        }

        public async Task<Result<object>> DeleteJournal(Guid journalId)
        {
            var journal = await _unitOfWork.JournalRepository.GetJournalById(journalId);
            if (journal == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Journal not found",
                    Data = null
                };
            }

            var growthDataId = journal.GrowthDataId;
            var reminder = await _unitOfWork.TailoredCheckupReminderRepository
                .GetActiveReminderByGrowthDataAndWeek(growthDataId, journal.CurrentWeek);

            if (reminder != null)
            {
                reminder.IsActive = false;
                reminder.ModificationDate = _currentTime.GetCurrentTime();
                reminder.Note = $"Deactivated because journal week {journal.CurrentWeek} was deleted.";
                _unitOfWork.TailoredCheckupReminderRepository.Update(reminder);
            }

            _unitOfWork.JournalRepository.SoftRemove(journal);
            await _unitOfWork.SaveChangeAsync();

            var growthData = await _unitOfWork.GrowthDataRepository.GetGrowthDataById(growthDataId);
            if (growthData?.BasicBioMetric != null)
            {
                var bbm = growthData.BasicBioMetric;

                var latestJournal = await _unitOfWork.JournalRepository
                    .GetLatestJournalByGrowthDataId(growthDataId);

                if (latestJournal != null)
                {
                    bbm.WeightKg = latestJournal.CurrentWeight ?? bbm.WeightKg;
                    bbm.SystolicBP = latestJournal.SystolicBP;
                    bbm.DiastolicBP = latestJournal.DiastolicBP;
                    bbm.HeartRateBPM = latestJournal.HeartRateBPM;
                    bbm.BloodSugarLevelMgDl = latestJournal.BloodSugarLevelMgDl;
                    bbm.Notes = $"System rolled back from deleted journal, now using journal week {latestJournal.CurrentWeek}";
                }
                else
                {
                    bbm.WeightKg = growthData.PreWeight ?? bbm.WeightKg;
                    bbm.SystolicBP = null;
                    bbm.DiastolicBP = null;
                    bbm.HeartRateBPM = null;
                    bbm.BloodSugarLevelMgDl = null;
                    bbm.Notes = "System reset BBM because all journals were deleted.";
                }

                _unitOfWork.BasicBioMetricRepository.Update(bbm);
                await _unitOfWork.SaveChangeAsync();

                await _tailoredCheckupReminderService.SendEmergencyBiometricAlert(bbm.Id);
            }

            return new Result<object>
            {
                Error = 0,
                Message = "Journal deleted successfully, BBM updated, and related reminders deactivated.",
                Data = null
            };
        }


    }
}
