using Hangfire;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class ConsultantRepository : GenericRepository<Consultant>, IConsultantRepository
    {
        private readonly AppDbContext _context;

        public ConsultantRepository(AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(context, timeService, claimsService)
        {
            _context = context;
        }

        public async Task<Consultant> GetConsultantByIdAsync(Guid consultantId)
        {
            return await _context.Consultant.Where(c => c.Id == consultantId && !c.IsDeleted)
                                            .Select(c => new Consultant
                                            {
                                                Id = c.Id,                                                Specialization = c.Specialization,
                                                Certificate = c.Certificate,
                                                Status = c.Status,
                                                Gender = c.Gender,
                                                JoinedAt = c.JoinedAt,
                                                IsCurrentlyConsulting = c.IsCurrentlyConsulting,
                                                ExperienceYears = c.ExperienceYears,
                                                UserId = c.UserId,
                                                User = c.User != null && !c.User.IsDeleted ? c.User : null,
                                                Schedules = c.Schedules
                                                    .Where(s => !s.IsDeleted && s.Slot != null && !s.Slot.IsDeleted)
                                                    .Select(s => new Schedule
                                                    {
                                                        Id = s.Id,
                                                        SlotId = s.SlotId,
                                                        ConsultantId = s.ConsultantId,
                                                        Slot = s.Slot != null && !s.Slot.IsDeleted ? s.Slot : null,
                                                        IsDeleted = s.IsDeleted
                                                    }).ToList(),
                                                IsDeleted = c.IsDeleted
                                            })
                                            .FirstOrDefaultAsync();
        }

        public async Task<bool> HasOverlappingScheduleAsync(Guid consultantId, DateTime startTime, DateTime endTime, int dayOfWeek)
        {
            if (startTime >= endTime)
                return true;

            return await _context.Consultant.Where(c => c.Id == consultantId && !c.IsDeleted)
                                            .SelectMany(c => c.Schedules)
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
