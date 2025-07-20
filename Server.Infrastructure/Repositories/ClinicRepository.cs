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
                        ImageUrl = c.ImageUrl,
                        Consultants = c.Consultants
                            .Where(con => !con.IsDeleted)
                            .Select(con => new Consultant
                            {
                                Id = con.Id,
                                UserId = con.UserId,
                                ClinicId = con.ClinicId,
                                User = con.User,
                                IsDeleted = con.IsDeleted
                            }).ToList(),
                        Doctors = c.Doctors
                            .Where(doc => !doc.IsDeleted)
                            .Select(doc => new Doctor
                            {
                                Id = doc.Id,
                                IsDeleted = doc.IsDeleted
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
                        ImageUrl = c.ImageUrl,
                        Consultants = c.Consultants
                            .Where(con => !con.IsDeleted)
                            .Select(con => new Consultant
                            {
                                Id = con.Id,
                                UserId = con.UserId,
                                ClinicId = con.ClinicId,
                                User = con.User,
                                IsDeleted = con.IsDeleted
                            }).ToList(),
                        Doctors = c.Doctors
                            .Where(doc => !doc.IsDeleted)
                            .Select(doc => new Doctor
                            {
                                Id = doc.Id,
                                IsDeleted = doc.IsDeleted
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
    }
}
