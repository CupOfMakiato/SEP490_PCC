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
                .Where(oc =>
                    (oc.DoctorId == userId || oc.UserId == userId)
                    && !oc.IsDeleted
                    && (status == null || oc.Status == status)
                )
                .ToListAsync();
        }

        public async Task<OfflineConsultation?> GetOfflineConsultationByIdAsync(Guid offlineConsultationId)
        {
            return await _context.OfflineConsultation
                .Where(oc => oc.Id == offlineConsultationId && !oc.IsDeleted)
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
                    DayOfWeek = oc.DayOfWeek,
                    HealthNote = oc.HealthNote,
                    Attachments = oc.Attachments != null && oc.Attachments.Any()
                        ? oc.Attachments.Where(a => a != null && !a.IsDeleted).ToList()
                        : new List<Media>(),
                    User = oc.User != null && !oc.User.IsDeleted ? oc.User : null,
                    Clinic = oc.Clinic != null && !oc.Clinic.IsDeleted ? oc.Clinic : null,
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
                            User = oc.Doctor.User != null && !oc.Doctor.User.IsDeleted ? oc.Doctor.User : null,
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
                .FirstOrDefaultAsync(oc => oc.Id == offlineConsultationId && !oc.IsDeleted);
        }
    }
}
