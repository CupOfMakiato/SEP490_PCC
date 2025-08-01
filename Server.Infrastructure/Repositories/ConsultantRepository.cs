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

        public async Task<Consultant> GetConsultantByConsultantIdAsync(Guid consultantId)
        {
            return await _context.Consultant.FirstOrDefaultAsync(c => c.Id == consultantId && !c.IsDeleted);
        }

        public async Task<Consultant> GetConsultantByIdAsync(Guid consultantId)
        {
            return await _context.Consultant.Where(c => c.Id == consultantId && !c.IsDeleted)
                                            .Select(c => new Consultant
                                            {
                                                Id = c.Id,
                                                Specialization = c.Specialization,
                                                Certificate = c.Certificate,
                                                Gender = c.Gender,
                                                JoinedAt = c.JoinedAt,
                                                IsCurrentlyConsulting = c.IsCurrentlyConsulting,
                                                ExperienceYears = c.ExperienceYears,
                                                UserId = c.UserId,
                                                User = c.User != null && !c.User.IsDeleted
                                                ? new User
                                                {
                                                    Id = c.User.Id,
                                                    UserName = c.User.UserName,
                                                    Email = c.User.Email,
                                                    PhoneNumber = c.User.PhoneNumber,
                                                    Status = c.User.Status,
                                                    Avatar = c.User.Avatar != null && !c.User.Avatar.IsDeleted ? c.User.Avatar : null
                                                }
                                                : null,
                                                ClinicId = c.ClinicId,
                                                Clinic = c.Clinic != null && !c.Clinic.IsDeleted ? c.Clinic : null,
                                                IsDeleted = c.IsDeleted
                                            })
                                            .FirstOrDefaultAsync();
        }

        //public async Task<bool> HasOverlappingScheduleAsync(Guid consultantId, DateTime startTime, DateTime endTime, int dayOfWeek)
        //{
        //    if (startTime >= endTime)
        //        return true;

        //    return await _context.Consultant.Where(c => c.Id == consultantId && !c.IsDeleted)
        //                                    .SelectMany(c => c.Schedules)
        //                                    .AnyAsync(s =>
        //                                        !s.IsDeleted &&
        //                                        s.Slot != null &&
        //                                        !s.Slot.IsDeleted &&
        //                                        s.Slot.DayOfWeek == dayOfWeek &&
        //                                        startTime < s.Slot.EndTime &&
        //                                        endTime > s.Slot.StartTime
        //                                    );
        //}
    }
}
