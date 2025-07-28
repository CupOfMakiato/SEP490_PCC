using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class ClinicRepository : GenericRepository<Clinic>, IClinicRepository
    {
        private readonly AppDbContext _context;

        public ClinicRepository(AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService) :
            base(context, timeService, claimsService)
        {
            _context = context;
        }

        public async Task<Clinic> GetClinicByClinicIdAsync(Guid clinicId)
        {
            return await _context.Clinic
                .Include(c => c.ImageUrl)
                .FirstOrDefaultAsync(c => c.Id == clinicId
                                    && !c.IsDeleted && c.IsActive
                                    && !c.ImageUrl.IsDeleted);
        }

        public async Task<Clinic> GetClinicByIdAsync(Guid clinicId)
        {
            return await _context.Clinic
                    .Where(c => c.Id == clinicId && !c.IsDeleted && c.IsActive)
                    .Select(c => new Clinic
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Address = c.Address,
                        Description = c.Description,
                        Phone = c.Phone,
                        Email = c.Email,
                        IsInsuranceAccepted = c.IsInsuranceAccepted,
                        IsActive = c.IsActive,
                        Specializations = c.Specializations,
                        ImageUrl = c.ImageUrl != null && !c.ImageUrl.IsDeleted ? c.ImageUrl : null,
                        Consultants = c.Consultants
                            .Where(con => !con.IsDeleted)
                            .Select(con => new Consultant
                            {
                                Id = con.Id,
                                Specialization = con.Specialization,
                                Certificate = con.Certificate,
                                Gender = con.Gender,
                                JoinedAt = con.JoinedAt,
                                IsCurrentlyConsulting = con.IsCurrentlyConsulting,
                                ExperienceYears = con.ExperienceYears,
                                UserId = con.UserId,
                                IsDeleted = con.IsDeleted,
                                User = con.User != null && !con.User.IsDeleted
                                ? new User
                                {
                                    Id = con.User.Id,
                                    UserName = con.User.UserName,
                                    Email = con.User.Email,
                                    PhoneNumber = con.User.PhoneNumber,
                                    Status = con.User.Status,
                                    Avatar = con.User.Avatar != null && !con.User.Avatar.IsDeleted ? con.User.Avatar : null
                                }
                                : null,
                            }).ToList(),
                        Doctors = c.Doctors
                            .Where(doc => !doc.IsDeleted)
                            .Select(doc => new Doctor
                            {
                                Id = doc.Id,
                                FullName = doc.FullName,
                                Gender = doc.Gender,
                                Specialization = doc.Specialization,
                                Certificate = doc.Certificate,
                                ExperienceYear = doc.ExperienceYear,
                                WorkPosition = doc.WorkPosition,
                                Description = doc.Description,
                                IsDeleted = doc.IsDeleted,
                                User = doc.User != null && !doc.User.IsDeleted
                                ? new User
                                {
                                    Id = doc.User.Id,
                                    UserName = doc.User.UserName,
                                    Email = doc.User.Email,
                                    PhoneNumber = doc.User.PhoneNumber,
                                    Status = doc.User.Status,
                                    Avatar = doc.User.Avatar != null && !doc.User.Avatar.IsDeleted ? doc.User.Avatar : null
                                }
                                : null
                            }).ToList(),
                        Feedbacks = c.Feedbacks
                            .Where(fb => !fb.IsDeleted)
                            .Select(fb => new Feedback
                            {
                                Id = fb.Id,
                                IsDeleted = fb.IsDeleted
                            }).ToList()
                    })
                    .FirstOrDefaultAsync();
        }

        public async Task<List<Clinic>> GetClinicByNameAsync(string name)
        {
            return await _context.Clinic
                    .Where(c => c.Name.Contains(name) && !c.IsDeleted && c.IsActive)
                    .Select(c => new Clinic
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Address = c.Address,
                        Description = c.Description,
                        Phone = c.Phone,
                        Email = c.Email,
                        IsInsuranceAccepted = c.IsInsuranceAccepted,
                        IsActive = c.IsActive,
                        Specializations = c.Specializations,
                        ImageUrl = c.ImageUrl != null && !c.ImageUrl.IsDeleted ? c.ImageUrl : null,
                        Consultants = c.Consultants
                            .Where(con => !con.IsDeleted && con.User != null && !con.User.IsDeleted)
                            .Select(con => new Consultant
                            {
                                Id = con.Id,
                                Specialization = con.Specialization,
                                Certificate = con.Certificate,
                                Gender = con.Gender,
                                JoinedAt = con.JoinedAt,
                                IsCurrentlyConsulting = con.IsCurrentlyConsulting,
                                ExperienceYears = con.ExperienceYears,
                                UserId = con.UserId,
                                IsDeleted = con.IsDeleted,
                                User = con.User != null && !con.User.IsDeleted
                                ? new User
                                {
                                    Id = con.User.Id,
                                    UserName = con.User.UserName,
                                    Email = con.User.Email,
                                    PhoneNumber = con.User.PhoneNumber,
                                    Status = con.User.Status,
                                    Avatar = con.User.Avatar != null && !con.User.Avatar.IsDeleted ? con.User.Avatar : null
                                }
                                : null,
                            }).ToList(),
                        Doctors = c.Doctors
                            .Where(doc => !doc.IsDeleted)
                            .Select(doc => new Doctor
                            {
                                Id = doc.Id,
                                FullName = doc.FullName,
                                Gender = doc.Gender,
                                Specialization = doc.Specialization,
                                Certificate = doc.Certificate,
                                ExperienceYear = doc.ExperienceYear,
                                WorkPosition = doc.WorkPosition,
                                Description = doc.Description,
                                IsDeleted = doc.IsDeleted,
                                User = doc.User != null && !doc.User.IsDeleted
                                ? new User
                                {
                                    Id = doc.User.Id,
                                    UserName = doc.User.UserName,
                                    Email = doc.User.Email,
                                    PhoneNumber = doc.User.PhoneNumber,
                                    Status = doc.User.Status,
                                    Avatar = doc.User.Avatar != null && !doc.User.Avatar.IsDeleted ? doc.User.Avatar : null
                                }
                                : null
                            }).ToList(),
                        Feedbacks = c.Feedbacks
                            .Where(fb => !fb.IsDeleted)
                            .Select(fb => new Feedback
                            {
                                Id = fb.Id,
                                IsDeleted = fb.IsDeleted
                            }).ToList()
                    })
                    .ToListAsync();
        }

        public async Task<List<Clinic>> GetClinicsAsync()
        {
            return await _context.Clinic.Where(c => !c.IsDeleted && c.IsActive)
                                        .ToListAsync();
        }

        public async Task<Clinic> GetClinicToApproveAsync(Guid clinicId)
        {
            return await _context.Clinic.FirstOrDefaultAsync
                        (c => c.Id == clinicId && !c.IsDeleted);
        }
    }
}
