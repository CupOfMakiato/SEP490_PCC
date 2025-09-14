using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class OfflineConsultationRepository : GenericRepository<OfflineConsultation>, IOfflineConsultationRepository
    {
        private readonly AppDbContext _context;

        public OfflineConsultationRepository(AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(context, timeService, claimsService)
        {
            _context = context;
        }

        public async Task<List<OfflineConsultation?>> GetAllOfflineConsultationByUserIdAsync(Guid userId, string? status)
        {
            return await _context.OfflineConsultation
                .Include(oc => oc.Clinic)
                .Include(oc => oc.Doctor)
                .Where(oc =>
                    (oc.DoctorId == userId || oc.UserId == userId)
                    && !oc.IsDeleted
                    && (status == null || oc.Status == status)
                    && oc.Clinic.IsActive
                )
                .ToListAsync();
        }

        public async Task<OfflineConsultation?> GetOfflineConsultationByIdAsync(Guid offlineConsultationId)
        {
            return await _context.OfflineConsultation
                .Where(oc => oc.Id == offlineConsultationId && !oc.IsDeleted && oc.Clinic.IsActive)
                .Select(oc => new OfflineConsultation
                {
                    Id = oc.Id,
                    UserId = oc.UserId,
                    ClinicId = oc.ClinicId,
                    DoctorId = oc.DoctorId,
                    ConsultationType = oc.ConsultationType,
                    Status = oc.Status,
                    StartDate = oc.StartDate,
                    EndDate = oc.EndDate,
                    FromMonth = oc.FromMonth,
                    ToMonth = oc.ToMonth,
                    HealthNote = oc.HealthNote,
                    Attachments = oc.Attachments != null && oc.Attachments.Any()
                        ? oc.Attachments.Where(a => a != null && !a.IsDeleted).ToList()
                        : new List<Media>(),
                    Schedules = oc.Schedules != null && oc.Schedules.Any()
                        ? oc.Schedules
                            .Where(s => s != null && !s.IsDeleted)
                            .Select(s => new Schedule
                            {
                                Id = s.Id,
                                SlotId = s.SlotId,
                                DoctorId = s.DoctorId,
                                OfflineConsultationId = s.OfflineConsultationId,
                                IsDeleted = s.IsDeleted,
                                Slot = s.Slot != null && !s.Slot.IsDeleted ? s.Slot : null
                            })
                            .ToList()
                        : new List<Schedule>(),
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
                    Clinic = oc.Clinic != null && !oc.Clinic.IsDeleted
                        ? new Clinic
                        {
                            Id = oc.Clinic.Id,
                            Address = oc.Clinic.Address,
                            Description = oc.Clinic.Description,
                            IsInsuranceAccepted = oc.Clinic.IsInsuranceAccepted,
                            Specializations = oc.Clinic.Specializations,
                            User = oc.User != null && !oc.User.IsDeleted
                                ? new User
                                {
                                    Id = oc.Clinic.User.Id,
                                    UserName = oc.Clinic.User.UserName,
                                    Email = oc.Clinic.User.Email,
                                    PhoneNumber = oc.Clinic.User.PhoneNumber,
                                    Status = oc.Clinic.User.Status,
                                    Avatar = oc.Clinic.User.Avatar != null && !oc.Clinic.User.Avatar.IsDeleted ? oc.Clinic.User.Avatar : null
                                }
                                : null
                        }
                        : null,
                    Doctor = oc.Doctor != null && !oc.Doctor.IsDeleted
                        ? new Doctor
                        {
                            Id = oc.Doctor.Id,
                            UserId = oc.Doctor.UserId,
                            ClinicId = oc.Doctor.ClinicId,
                            Gender = oc.Doctor.Gender,
                            Specialization = oc.Doctor.Specialization,
                            Certificate = oc.Doctor.Certificate,
                            ExperienceYear = oc.Doctor.ExperienceYear,
                            WorkPosition = oc.Doctor.WorkPosition,
                            Description = oc.Doctor.Description,
                            User = oc.Doctor.User != null && !oc.Doctor.User.IsDeleted
                                ? new User
                                {
                                    Id = oc.Doctor.User.Id,
                                    UserName = oc.Doctor.User.UserName,
                                    Email = oc.Doctor.User.Email,
                                    PhoneNumber = oc.Doctor.User.PhoneNumber,
                                    Status = oc.Doctor.User.Status,
                                    Avatar = oc.Doctor.User.Avatar != null && !oc.Doctor.User.Avatar.IsDeleted ? oc.Doctor.User.Avatar : null
                                }
                                : null,
                            IsDeleted = oc.Doctor.IsDeleted
                        }
                        : null,
                    IsDeleted = oc.IsDeleted
                })
                .FirstOrDefaultAsync();
        }

        public async Task<OfflineConsultation?> GetOfflineConsultationByOfflineConsultationIdAsync(Guid offlineConsultationId)
        {
            return await _context.OfflineConsultation
                .Include(oc => oc.Schedules)
                    .ThenInclude(s => s.Slot)
                .FirstOrDefaultAsync(oc => oc.Id == offlineConsultationId && !oc.IsDeleted);
        }

        public async Task<List<OfflineConsultation>> GetOfflineConsultationsByCreatedByAsync(Guid userId)
        {
            return await _context.OfflineConsultation
                .Where(oc => oc.CreatedBy == userId && !oc.IsDeleted && oc.Clinic.IsActive)
                .OrderByDescending(oc => oc.CreationDate)
                .Select(oc => new OfflineConsultation
                {
                    Id = oc.Id,
                    UserId = oc.UserId,
                    ClinicId = oc.ClinicId,
                    DoctorId = oc.DoctorId,
                    ConsultationType = oc.ConsultationType,
                    Status = oc.Status,
                    StartDate = oc.StartDate,
                    EndDate = oc.EndDate,
                    FromMonth = oc.FromMonth,
                    ToMonth = oc.ToMonth,
                    HealthNote = oc.HealthNote,
                    Attachments = oc.Attachments != null && oc.Attachments.Any()
                        ? oc.Attachments.Where(a => a != null && !a.IsDeleted).ToList()
                        : new List<Media>(),
                    Schedules = oc.Schedules != null && oc.Schedules.Any()
                        ? oc.Schedules.Where(s => s != null && !s.IsDeleted).ToList()
                        : new List<Schedule>(),
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
                    Clinic = oc.Clinic != null && !oc.Clinic.IsDeleted
                        ? new Clinic
                        {
                            Id = oc.Clinic.Id,
                            Address = oc.Clinic.Address,
                            Description = oc.Clinic.Description,
                            IsInsuranceAccepted = oc.Clinic.IsInsuranceAccepted,
                            Specializations = oc.Clinic.Specializations,
                            User = oc.User != null && !oc.User.IsDeleted
                                ? new User
                                {
                                    Id = oc.Clinic.User.Id,
                                    UserName = oc.Clinic.User.UserName,
                                    Email = oc.Clinic.User.Email,
                                    PhoneNumber = oc.Clinic.User.PhoneNumber,
                                    Status = oc.Clinic.User.Status,
                                    Avatar = oc.Clinic.User.Avatar != null && !oc.Clinic.User.Avatar.IsDeleted ? oc.Clinic.User.Avatar : null
                                }
                                : null
                        }
                        : null,
                    Doctor = oc.Doctor != null && !oc.Doctor.IsDeleted
                        ? new Doctor
                        {
                            Id = oc.Doctor.Id,
                            UserId = oc.Doctor.UserId,
                            ClinicId = oc.Doctor.ClinicId,
                            Gender = oc.Doctor.Gender,
                            Specialization = oc.Doctor.Specialization,
                            Certificate = oc.Doctor.Certificate,
                            ExperienceYear = oc.Doctor.ExperienceYear,
                            WorkPosition = oc.Doctor.WorkPosition,
                            Description = oc.Doctor.Description,
                            User = oc.Doctor.User != null && !oc.Doctor.User.IsDeleted
                                ? new User
                                {
                                    Id = oc.Doctor.User.Id,
                                    UserName = oc.Doctor.User.UserName,
                                    Email = oc.Doctor.User.Email,
                                    PhoneNumber = oc.Doctor.User.PhoneNumber,
                                    Status = oc.Doctor.User.Status,
                                    Avatar = oc.Doctor.User.Avatar != null && !oc.Doctor.User.Avatar.IsDeleted ? oc.Doctor.User.Avatar : null
                                }
                                : null,
                            IsDeleted = oc.Doctor.IsDeleted
                        }
                        : null,
                    IsDeleted = oc.IsDeleted
                })
                .ToListAsync();
        }
    }
}
