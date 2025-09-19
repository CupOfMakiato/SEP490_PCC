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

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.User
                .Where(u => !u.IsDeleted && u.RoleId == 2)
                .Select(u => new User
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Status = u.Status,
                    RoleId = u.RoleId,
                    Avatar = u.Avatar != null && !u.Avatar.IsDeleted ? u.Avatar : null
                })
                .ToListAsync();
        }

        public async Task<List<User?>> GetAllUsersByNameAsync(string? name)
        {
            var query = _context.User
                .Where(u => !u.IsDeleted && u.RoleId == 2);

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(u => u.UserName.Contains(name));
            }

            return await query
                .Select(u => new User
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Status = u.Status,
                    RoleId = u.RoleId,
                    Avatar = u.Avatar != null && !u.Avatar.IsDeleted ? u.Avatar : null
                })
                .ToListAsync();
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

        public async Task<Consultant> GetConsultantByUserIdAsync(Guid userId)
        {
            return await _context.Consultant
                .Where(c => c.UserId == userId && !c.IsDeleted)
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
                    Clinic = c.Clinic != null && !c.Clinic.IsDeleted
                        ? new Clinic
                        {
                            Id = c.Clinic.Id,
                            Address = c.Clinic.Address,
                            Description = c.Clinic.Description,
                            IsInsuranceAccepted = c.Clinic.IsInsuranceAccepted,
                            Specializations = c.Clinic.Specializations,
                            UserId = c.Clinic.UserId,
                            User = c.Clinic.User != null && !c.Clinic.User.IsDeleted
                                ? new User
                                {
                                    Id = c.Clinic.User.Id,
                                    UserName = c.Clinic.User.UserName, // 👈 this will now show up
                                    Email = c.Clinic.User.Email,
                                    PhoneNumber = c.Clinic.User.PhoneNumber,
                                    Status = c.Clinic.User.Status,
                                    Avatar = c.Clinic.User.Avatar != null && !c.Clinic.User.Avatar.IsDeleted ? c.Clinic.User.Avatar : null
                                }
                                : null
                        }
                        : null,
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
