using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface IVitaminService
    {
        public Task<Vitamin> GetVitaminByIdAsync(Guid vitaminId);
        public Task<List<Vitamin>> GetVitaminsAsync();
        public Task<bool> SoftDeleteVitamin(Guid vitaminId);
        public Task<bool> DeleteVitamin(Guid vitaminId);
        public Task<bool> CreateVitamin(Vitamin vitamin);
        public Task<bool> UpdateVitamin(Vitamin vitamin);
        public Task<bool> ApproveVitamin(Guid vitaminId);
    }
}
