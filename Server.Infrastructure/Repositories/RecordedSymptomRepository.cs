using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Domain.Enums;
using Server.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Repositories
{
    public class RecordedSymptomRepository : GenericRepository<RecordedSymptom>, IRecordedSymptomRepository
    {
        private readonly AppDbContext _dbContext;

        public RecordedSymptomRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _dbContext = dbContext;
        }
        public async Task<List<RecordedSymptom>> GetAllSymptoms()
        {
            return await _dbContext.RecordedSymptom
                .Include(s => s.JournalSymptoms)
                .Where(c => c.IsActive == true)
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<RecordedSymptom> GetSymptomById(Guid id)
        {
            return await _dbContext.RecordedSymptom
                .Include(s => s.JournalSymptoms)
                .Where(c => c.IsActive == true)
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }
        public async Task<RecordedSymptom?> GetSymptomByName(string name)
        {
            return await _dbContext.RecordedSymptom
                .Include(s => s.JournalSymptoms)
                .FirstOrDefaultAsync(t => t.SymptomName.ToLower() == name.ToLower() && !t.IsDeleted);
        }

        public async Task<List<RecordedSymptom>> GetAllSymptomsForUser(Guid userId)
        {
            return await _dbContext.RecordedSymptom
                .Include(s => s.JournalSymptoms)
                .Where(s => s.IsActive && !s.IsDeleted)
                .Where(s => s.CreatedBy == userId)
                .ToListAsync();
        }
        public async Task<List<RecordedSymptom>> GetTemplateSymptoms()
        {
            return await _dbContext.RecordedSymptom
                .Include(s => s.JournalSymptoms)
                .Where(s => s.IsActive && !s.IsDeleted)
                .ToListAsync();
        }
        public async Task<List<RecordedSymptom>> GetTemplateSymptomsByUser(Guid userId)
        {
            return await _dbContext.RecordedSymptom
                .Include(s => s.JournalSymptoms)
                .Where(s => s.CreatedBy == userId && s.IsActive && !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<bool> IsSymptomNameDuplicateForUser(string name, Guid userId)
        {
            return await _dbContext.RecordedSymptom
                .Include(s => s.JournalSymptoms)
                .AnyAsync(s =>
                    s.CreatedBy == userId &&
                    s.IsActive &&
                    !s.IsDeleted &&
                    s.SymptomName.ToLower() == name.ToLower()
                );
        }
        public async Task<bool> IsTemplateSymptomExistsByName(string name)
        {
            return await _dbContext.RecordedSymptom
                .Include(s => s.JournalSymptoms)
                .AnyAsync(s => !s.IsDeleted &&
                               s.SymptomName.ToLower() == name);
        }
        public async Task<RecordedSymptom?> FindReusableSymptom(string name, Guid userId)
        {
            var simplifiedString = name.Trim().ToLower();

            return await _dbContext.RecordedSymptom
                .Include(s => s.JournalSymptoms)
                .FirstOrDefaultAsync(s =>
                    !s.IsDeleted &&
                    s.SymptomName.ToLower() == simplifiedString &&
                    (s.CreatedBy == userId));
        }

        public async Task<List<RecordedSymptom>> GetAllCheckedTemplateSymptoms()
        {
            return await _dbContext.RecordedSymptom
                .Include(s => s.JournalSymptoms)
                .Where(s => s.IsActive && !s.IsDeleted &&
                            s.JournalSymptoms.Any(s => s.IsChecked))
                .ToListAsync();
        }
        public async Task<List<RecordedSymptom>> GetAllUnCheckedTemplateSymptoms()
        {
            return await _dbContext.RecordedSymptom
                .Include(s => s.JournalSymptoms)
                .Where(s => s.IsActive && !s.IsDeleted &&
                            s.JournalSymptoms.Any(s => !s.IsChecked))
                .ToListAsync();
        }
    }
}
