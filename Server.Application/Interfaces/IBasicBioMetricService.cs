using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.BasicBioMetric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface IBasicBioMetricService
    {
        // view
        Task<Result<List<ViewBasicBioMetricDTO>>> ViewAllBasicBioMetrics();
        Task<Result<ViewBasicBioMetricDTO>> ViewBasicBioMetricById(Guid bbmId);
    }
}
