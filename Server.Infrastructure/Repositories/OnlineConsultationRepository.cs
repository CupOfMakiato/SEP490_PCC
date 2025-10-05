using CloudinaryDotNet.Core;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class OnlineConsultationRepository : GenericRepository<OnlineConsultation>, IOnlineConsultationRepository
    {
        private readonly AppDbContext _context;

        public OnlineConsultationRepository(AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(context, timeService, claimsService)
        {
            _context = context;
        }

        public async Task<UserSubscription?> GetActiveSubscriptionAsync(Guid userId)
        {
            return await _context.UserSubscription
                .Where(us => us.UserId == userId && !us.IsDeleted /* && us.IsActive */)
                .Include(us => us.Payments)
                .OrderByDescending(us => us.CreationDate)
                .FirstOrDefaultAsync();
        }

        public async Task<OnlineConsultation?> GetOnlineConsultationByIdAsync(Guid onlineConsultationId)
        {
            return await _context.OnlineConsultation
                .Where(oc => oc.Id == onlineConsultationId && !oc.IsDeleted && oc.Consultant.Clinic.IsActive)
                .Select(oc => new OnlineConsultation
                {
                    Id = oc.Id,
                    UserId = oc.UserId,
                    ConsultantId = oc.ConsultantId,
                    Trimester = oc.Trimester,
                    Date = oc.Date,
                    GestationalWeek = oc.GestationalWeek,
                    Summary = oc.Summary,
                    ConsultantNote = oc.ConsultantNote,
                    UserNote = oc.UserNote,
                    VitalSigns = oc.VitalSigns,
                    Recommendations = oc.Recommendations,
                    User = oc.User != null && !oc.User.IsDeleted
                        ? new User
                        {
                            Id = oc.User.Id,
                            UserName = oc.User.UserName,
                            Email = oc.User.Email,
                            PhoneNumber = oc.User.PhoneNumber,
                            Status = oc.User.Status,
                            Avatar = oc.User.Avatar != null && !oc.User.Avatar.IsDeleted ? oc.User.Avatar : null
                        }
                        : null,
                    Consultant = oc.Consultant != null && !oc.Consultant.IsDeleted
                        ? new Consultant
                        {
                            Id = oc.Consultant.Id,
                            UserId = oc.Consultant.UserId,
                            Specialization = oc.Consultant.Specialization,
                            Certificate = oc.Consultant.Certificate,
                            Gender = oc.Consultant.Gender,
                            JoinedAt = oc.Consultant.JoinedAt,
                            IsCurrentlyConsulting = oc.Consultant.IsCurrentlyConsulting,
                            ExperienceYears = oc.Consultant.ExperienceYears,
                            ClinicId = oc.Consultant.ClinicId,
                            User = oc.Consultant.User != null && !oc.Consultant.User.IsDeleted
                                ? new User
                                {
                                    Id = oc.Consultant.User.Id,
                                    UserName = oc.Consultant.User.UserName,
                                    Email = oc.Consultant.User.Email,
                                    PhoneNumber = oc.Consultant.User.PhoneNumber,
                                    Status = oc.Consultant.User.Status,
                                    Avatar = oc.Consultant.User.Avatar != null && !oc.Consultant.User.Avatar.IsDeleted ? oc.Consultant.User.Avatar : null
                                }
                                : null,
                            Clinic = oc.Consultant.Clinic != null && !oc.Consultant.Clinic.IsDeleted
                                ? new Clinic
                                {
                                    Id = oc.Consultant.Clinic.Id,
                                    Address = oc.Consultant.Clinic.Address,
                                    Description = oc.Consultant.Clinic.Description,
                                    IsInsuranceAccepted = oc.Consultant.Clinic.IsInsuranceAccepted,
                                    IsActive = oc.Consultant.Clinic.IsActive,
                                    Specializations = oc.Consultant.Clinic.Specializations,
                                    User = oc.Consultant.User != null && !oc.Consultant.User.IsDeleted
                                        ? new User
                                        {
                                            Id = oc.Consultant.Clinic.User.Id,
                                            UserName = oc.Consultant.Clinic.User.UserName,
                                            Email = oc.Consultant.Clinic.User.Email,
                                            PhoneNumber = oc.Consultant.Clinic.User.PhoneNumber,
                                            Status = oc.Consultant.Clinic.User.Status,
                                            Avatar = oc.Consultant.Clinic.User.Avatar != null && !oc.Consultant.User.Avatar.IsDeleted ? oc.Consultant.User.Avatar : null
                                        }
                                        : null
                                }
                                : null
                        }
                        : null,
                    Attachments = oc.Attachments != null && oc.Attachments.Any()
                        ? oc.Attachments.Where(a => a != null && !a.IsDeleted).ToList()
                        : new List<Media>(),
                    IsDeleted = oc.IsDeleted
                })
                .FirstOrDefaultAsync();
        }

        public async Task<OnlineConsultation?> GetOnlineConsultationByOnlineConsultationIdAsync(Guid onlineConsultationId)
        {
            var consultation = await _context.OnlineConsultation
                .Include(oc => oc.Attachments)
                .FirstOrDefaultAsync(oc => oc.Id == onlineConsultationId && !oc.IsDeleted);

            if (consultation != null && consultation.Attachments != null)
            {
                consultation.Attachments = consultation.Attachments
                    .Where(a => a != null && !a.IsDeleted)
                    .ToList();
            }

            return consultation;
        }

        public async Task<List<OnlineConsultation>> GetOnlineConsultationsByConsultantIdAsync(Guid consultantId)
        {
            return await _context.OnlineConsultation
                .Where(oc => oc.ConsultantId == consultantId && !oc.IsDeleted && oc.Consultant.Clinic.IsActive)
                .Select(oc => new OnlineConsultation
                {
                    Id = oc.Id,
                    UserId = oc.UserId,
                    ConsultantId = oc.ConsultantId,
                    Trimester = oc.Trimester,
                    Date = oc.Date,
                    GestationalWeek = oc.GestationalWeek,
                    Summary = oc.Summary,
                    ConsultantNote = oc.ConsultantNote,
                    UserNote = oc.UserNote,
                    VitalSigns = oc.VitalSigns,
                    Recommendations = oc.Recommendations,
                    User = oc.User != null && !oc.User.IsDeleted
                        ? new User
                        {
                            Id = oc.User.Id,
                            UserName = oc.User.UserName,
                            Email = oc.User.Email,
                            PhoneNumber = oc.User.PhoneNumber,
                            Status = oc.User.Status,
                            Avatar = oc.User.Avatar != null && !oc.User.Avatar.IsDeleted ? oc.User.Avatar : null
                        }
                        : null,
                    Consultant = oc.Consultant != null && !oc.Consultant.IsDeleted
                        ? new Consultant
                        {
                            Id = oc.Consultant.Id,
                            UserId = oc.Consultant.UserId,
                            Specialization = oc.Consultant.Specialization,
                            Certificate = oc.Consultant.Certificate,
                            Gender = oc.Consultant.Gender,
                            JoinedAt = oc.Consultant.JoinedAt,
                            IsCurrentlyConsulting = oc.Consultant.IsCurrentlyConsulting,
                            ExperienceYears = oc.Consultant.ExperienceYears,
                            ClinicId = oc.Consultant.ClinicId,
                            User = oc.Consultant.User != null && !oc.Consultant.User.IsDeleted
                                ? new User
                                {
                                    Id = oc.Consultant.User.Id,
                                    UserName = oc.Consultant.User.UserName,
                                    Email = oc.Consultant.User.Email,
                                    PhoneNumber = oc.Consultant.User.PhoneNumber,
                                    Status = oc.Consultant.User.Status,
                                    Avatar = oc.Consultant.User.Avatar != null && !oc.Consultant.User.Avatar.IsDeleted ? oc.Consultant.User.Avatar : null
                                }
                                : null,
                            Clinic = oc.Consultant.Clinic != null && !oc.Consultant.Clinic.IsDeleted
                                ? new Clinic
                                {
                                    Id = oc.Consultant.Clinic.Id,
                                    Address = oc.Consultant.Clinic.Address,
                                    Description = oc.Consultant.Clinic.Description,
                                    IsInsuranceAccepted = oc.Consultant.Clinic.IsInsuranceAccepted,
                                    IsActive = oc.Consultant.Clinic.IsActive,
                                    Specializations = oc.Consultant.Clinic.Specializations,
                                    User = oc.Consultant.User != null && !oc.Consultant.User.IsDeleted
                                        ? new User
                                        {
                                            Id = oc.Consultant.Clinic.User.Id,
                                            UserName = oc.Consultant.Clinic.User.UserName,
                                            Email = oc.Consultant.Clinic.User.Email,
                                            PhoneNumber = oc.Consultant.Clinic.User.PhoneNumber,
                                            Status = oc.Consultant.Clinic.User.Status,
                                            Avatar = oc.Consultant.Clinic.User.Avatar != null && !oc.Consultant.User.Avatar.IsDeleted ? oc.Consultant.User.Avatar : null
                                        }
                                        : null
                                }
                                : null
                        }
                        : null,
                    Attachments = oc.Attachments != null && oc.Attachments.Any()
                        ? oc.Attachments.Where(a => a != null && !a.IsDeleted).ToList()
                        : new List<Media>(),
                    IsDeleted = oc.IsDeleted
                })
                .ToListAsync();
        }

        public async Task<List<OnlineConsultation>> GetOnlineConsultationsByUserIdAsync(Guid userId)
        {
            return await _context.OnlineConsultation
                .Where(oc => oc.UserId == userId && !oc.IsDeleted && oc.Consultant.Clinic.IsActive)
                .Select(oc => new OnlineConsultation
                {
                    Id = oc.Id,
                    UserId = oc.UserId,
                    ConsultantId = oc.ConsultantId,
                    Trimester = oc.Trimester,
                    Date = oc.Date,
                    GestationalWeek = oc.GestationalWeek,
                    Summary = oc.Summary,
                    ConsultantNote = oc.ConsultantNote,
                    UserNote = oc.UserNote,
                    VitalSigns = oc.VitalSigns,
                    Recommendations = oc.Recommendations,
                    User = oc.User != null && !oc.User.IsDeleted
                        ? new User
                        {
                            Id = oc.User.Id,
                            UserName = oc.User.UserName,
                            Email = oc.User.Email,
                            PhoneNumber = oc.User.PhoneNumber,
                            Status = oc.User.Status,
                            Avatar = oc.User.Avatar != null && !oc.User.Avatar.IsDeleted ? oc.User.Avatar : null
                        }
                        : null,
                    Consultant = oc.Consultant != null && !oc.Consultant.IsDeleted
                        ? new Consultant
                        {
                            Id = oc.Consultant.Id,
                            UserId = oc.Consultant.UserId,
                            Specialization = oc.Consultant.Specialization,
                            Certificate = oc.Consultant.Certificate,
                            Gender = oc.Consultant.Gender,
                            JoinedAt = oc.Consultant.JoinedAt,
                            IsCurrentlyConsulting = oc.Consultant.IsCurrentlyConsulting,
                            ExperienceYears = oc.Consultant.ExperienceYears,
                            ClinicId = oc.Consultant.ClinicId,
                            User = oc.Consultant.User != null && !oc.Consultant.User.IsDeleted
                                ? new User
                                {
                                    Id = oc.Consultant.User.Id,
                                    UserName = oc.Consultant.User.UserName,
                                    Email = oc.Consultant.User.Email,
                                    PhoneNumber = oc.Consultant.User.PhoneNumber,
                                    Status = oc.Consultant.User.Status,
                                    Avatar = oc.Consultant.User.Avatar != null && !oc.Consultant.User.Avatar.IsDeleted ? oc.Consultant.User.Avatar : null
                                }
                                : null,
                            Clinic = oc.Consultant.Clinic != null && !oc.Consultant.Clinic.IsDeleted
                                ? new Clinic
                                {
                                    Id = oc.Consultant.Clinic.Id,
                                    Address = oc.Consultant.Clinic.Address,
                                    Description = oc.Consultant.Clinic.Description,
                                    IsInsuranceAccepted = oc.Consultant.Clinic.IsInsuranceAccepted,
                                    IsActive = oc.Consultant.Clinic.IsActive,
                                    Specializations = oc.Consultant.Clinic.Specializations,
                                    User = oc.Consultant.User != null && !oc.Consultant.User.IsDeleted
                                        ? new User
                                        {
                                            Id = oc.Consultant.Clinic.User.Id,
                                            UserName = oc.Consultant.Clinic.User.UserName,
                                            Email = oc.Consultant.Clinic.User.Email,
                                            PhoneNumber = oc.Consultant.Clinic.User.PhoneNumber,
                                            Status = oc.Consultant.Clinic.User.Status,
                                            Avatar = oc.Consultant.Clinic.User.Avatar != null && !oc.Consultant.User.Avatar.IsDeleted ? oc.Consultant.User.Avatar : null
                                        }
                                        : null
                                }
                                : null
                        }
                        : null,
                    Attachments = oc.Attachments != null && oc.Attachments.Any()
                        ? oc.Attachments.Where(a => a != null && !a.IsDeleted).ToList()
                        : new List<Media>(),
                    IsDeleted = oc.IsDeleted
                })
                .ToListAsync();
        }
    }
}
