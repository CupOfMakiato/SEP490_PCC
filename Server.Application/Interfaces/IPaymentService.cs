using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Payment;
using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Application.Interfaces
{
    public interface IPaymentService
    {
        public Task<Result<Payment>> CreateCheckoutSession(CreateCheckoutSessionRequest request);
        public Task<Result<bool>> ActiveSubscription(Guid userSubscriptionId);
        // Revenue/statistics
        Task<List<RevenueStatisticsDetailDto>> GetRevenueByMonthAsync(int year);
        Task<List<RevenueStatisticsDetailDto>> GetRevenueByQuarterAsync(int year);
        Task<List<RevenueStatisticsDetailDto>> GetRevenueByYearAsync();

        // History
        Task<List<PaymentHistoryDto>> GetPaymentHistoryAsync(DateTime? fromDate, DateTime? toDate, Guid? userId, PaymentStatus? status);
        Task<List<PaymentHistoryDto>> GetPaymentHistoryByUserAsync(Guid userId);

        //Dashboard
        Task<DashboardStatisticsDto> GetDashboardStatisticsAsync(int year);
    }
}
