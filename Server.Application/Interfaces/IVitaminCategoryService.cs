using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface IVitaminCategoryService
    {
        public Task<VitaminCategory> GetVitaminCategoryByIdAsync(Guid vitaminCategoryId);
        public Task<List<VitaminCategory>> GetVitaminCategorysAsync();
        public Task<bool> SoftDeleteVitaminCategory(Guid vitaminCategoryId);
        public Task<bool> CreateVitaminCategory(VitaminCategory vitaminCategory);
        public Task<bool> UpdateVitaminCategory(VitaminCategory vitaminCategory);
    }
}
