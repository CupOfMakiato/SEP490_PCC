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
                .FirstOrDefaultAsync(c => c.Id == clinicId
                                    && !c.IsDeleted && c.IsActive);
        }

        public async Task<Clinic> GetClinicByIdAsync(Guid clinicId)
        {
            return await _context.Clinic
                    .Where(c => c.Id == clinicId && !c.IsDeleted && c.IsActive)
                    .Select(c => new Clinic
                    {
                        Id = c.Id,
                        Address = c.Address,
                        Description = c.Description,
                        IsInsuranceAccepted = c.IsInsuranceAccepted,
                        IsActive = c.IsActive,
                        Specializations = c.Specializations,
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
                                Rating = fb.Rating,
                                Comment = fb.Comment,
                                IsDeleted = fb.IsDeleted
                            }).ToList()
                    })
                    .FirstOrDefaultAsync();
        }

        public async Task<List<Clinic>> GetClinicByNameAsync(string name)
        {
            return await _context.Clinic
                    .Where(c => (c.User.UserName.Contains(name) || c.Address.Contains(name)) && !c.IsDeleted && c.IsActive)
                    .Select(c => new Clinic
                    {
                        Id = c.Id,
                        Address = c.Address,
                        Description = c.Description,
                        IsInsuranceAccepted = c.IsInsuranceAccepted,
                        IsActive = c.IsActive,
                        Specializations = c.Specializations,
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
                                Rating = fb.Rating,
                                Comment = fb.Comment,
                                IsDeleted = fb.IsDeleted
                            }).ToList()
                    })
                    .ToListAsync();
        }

        public async Task<List<Clinic>> GetClinicsAsync()
        {
            return await _context.Clinic
                    .Where(c => !c.IsDeleted && c.IsActive)
                    .Select(c => new Clinic
                    {
                        Id = c.Id,
                        Address = c.Address,
                        Description = c.Description,
                        IsInsuranceAccepted = c.IsInsuranceAccepted,
                        IsActive = c.IsActive,
                        Specializations = c.Specializations,
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
                                Rating = fb.Rating,
                                Comment = fb.Comment,
                                IsDeleted = fb.IsDeleted
                            }).ToList()
                    })
                    .ToListAsync();
        }

        public async Task<Clinic> GetClinicToApproveAsync(Guid clinicId)
        {
            return await _context.Clinic.FirstOrDefaultAsync
                        (c => c.Id == clinicId && !c.IsDeleted);
        }

        public async Task<List<Clinic>> SuggestClinicsAsync(string userAddress, int maxResults = 10)
        {
            var clinics = await _context.Clinic
                .Include(c => c.Feedbacks)
                .Where(c => !c.IsDeleted && c.IsActive)
                .ToListAsync();

            var suggested = clinics
                .Select(c => new
                    {
                        Clinic = c,
                        // Calculate average rating, default to 0 if no feedbacks
                        AverageRating = c.Feedbacks != null && c.Feedbacks.Any(fb => !fb.IsDeleted)
                            ? c.Feedbacks.Where(fb => !fb.IsDeleted).Average(fb => fb.Rating)
                            : 0,
                        // Simple proximity: 0 if address matches, 1 otherwise (replace with real distance logic as needed)
                        Proximity = !string.IsNullOrEmpty(userAddress) && !string.IsNullOrEmpty(c.Address)
                            ? (c.Address.Contains(userAddress) ? 0 : 1)
                            : int.MaxValue
                    })
                .OrderBy(s => s.Proximity)
                .ThenByDescending(s => s.AverageRating)
                .Take(maxResults)
                .Select(s => s.Clinic)
                .ToList();

            return suggested;
        }
    }
}
