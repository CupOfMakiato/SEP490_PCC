using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Repositories
{
    public interface IBasicBioMetricRepository : IGenericRepository<BasicBioMetric>
    {
        Task<List<BasicBioMetric>> GetAllBasicBioMetrics();
        Task<BasicBioMetric> GetBasicBioMetricById(Guid bbmId);
        Task<List<BasicBioMetric>> GetAllRecentBiometrics(DateTime lastCheckTime);
    }
}
