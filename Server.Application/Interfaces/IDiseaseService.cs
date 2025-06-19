using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface IDiseaseService
    {
        public Task<Disease> GetDiseaseByIdAsync(Guid diseaseId);
        public Task<List<Disease>> GetDiseasesAsync();
        public Task<bool> SoftDeleteDisease(Guid diseaseId);
        public Task<bool> DeleteDisease(Guid diseaseId);
        public Task<bool> CreateDisease(Disease disease);
        public Task<bool> UpdateDisease(Disease disease);
    }
}
