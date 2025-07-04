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
        // create
        Task<Result<object>> CreateBasicBioMetric(CreateBasicBioMetricDTO CreateBasicBioMetricDTO);
        // edit
        Task<Result<object>> EditBasicBioMetric(EditBasicBioMetricDTO EditBasicBioMetricDTO);
        // delete
        Task<Result<object>> DeleteBasicBioMetric(Guid bbmId);
    }
}
