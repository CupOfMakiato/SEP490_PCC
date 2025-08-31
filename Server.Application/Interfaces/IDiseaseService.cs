using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Disease;
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
        Task<Result<GetDiseaseResponse>> GetDiseaseByIdAsync(Guid diseaseId);
        Task<Result<List<GetDiseaseResponse>>> GetDiseasesAsync();
        Task<Result<object>> SoftDeleteDisease(Guid diseaseId);
        Task<Result<object>> DeleteDisease(Guid diseaseId);
        Task<Result<Disease>> CreateDisease(CreateDiseaseRequest request);
        Task<Result<Disease>> UpdateDisease(UpdateDiseaseRequest request);
    }
}
