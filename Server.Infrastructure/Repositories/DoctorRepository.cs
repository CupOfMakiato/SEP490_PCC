using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(context, timeService, claimsService)
        {
            _context = context;
        }

        public async Task<Doctor?> GetDoctorByIdAsync(Guid doctorId)
        {
            return await _context.Doctor
                .Where(d => d.Id == doctorId && !d.IsDeleted)
                .Select(d => new Doctor
                {
                    Id = d.Id,
                    Gender = d.Gender,
                    Specialization = d.Specialization,
                    Certificate = d.Certificate,
                    ExperienceYear = d.ExperienceYear,
                    WorkPosition = d.WorkPosition,
                    Description = d.Description,
                    UserId = d.UserId,
                    ClinicId = d.ClinicId,
                    Clinic = d.Clinic != null && !d.Clinic.IsDeleted ? d.Clinic : null,
                    User = d.User != null && !d.User.IsDeleted ? d.User : null,
                    Schedules = d.Schedules
                        .Where(s => !s.IsDeleted && s.Slot != null && !s.Slot.IsDeleted)
                        .Select(s => new Schedule
                        {
                            Id = s.Id,
                            SlotId = s.SlotId,
                            DoctorId = s.DoctorId,
                            Slot = s.Slot != null && !s.Slot.IsDeleted ? s.Slot : null,
                            IsDeleted = s.IsDeleted
                        }).ToList(),
                    IsDeleted = d.IsDeleted
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> HasOverlappingScheduleAsync(Guid doctorId, DateTime startTime, DateTime endTime, int dayOfWeek)
        {
            if (startTime >= endTime)
                return true;

            return await _context.Doctor.Where(d => d.Id == doctorId && !d.IsDeleted)
                                            .SelectMany(d => d.Schedules)
                                            .AnyAsync(s =>
                                                !s.IsDeleted &&
                                                s.Slot != null &&
                                                !s.Slot.IsDeleted &&
                                                s.Slot.DayOfWeek == dayOfWeek &&
                                                startTime < s.Slot.EndTime &&
                                                endTime > s.Slot.StartTime
                                            );
        }
    }
}
