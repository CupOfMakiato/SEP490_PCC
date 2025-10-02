using Server.Application.DTOs.Payment;
using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Application.Repositories
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<List<Payment>> GetSuccessfulPaymentsAsync();
        Task<List<Payment>> GetPaymentsAsync(DateTime? fromDate, DateTime? toDate, Guid? userId, PaymentStatus? status);
        Task<List<RevenueStatisticsRaw>> GetRevenueByMonthAsync(int year);
        Task<List<RevenueStatisticsRaw>> GetRevenueByQuarterAsync(int year);
        Task<List<RevenueStatisticsRaw>> GetRevenueByYearAsync();
    }
}
