using Net.payOS;
using Net.payOS.Types;
using Server.Application;
using Server.Application.Abstractions.Shared;
using Server.Application.Commons;
using Server.Application.DTOs.Payment;
using Server.Application.Interfaces;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PayOS _payOS;

        public PaymentService(IUnitOfWork unitOfWork, PayOS payOS, IUserService userService)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _payOS = payOS;
        }

        public async Task<Result<bool>> ActiveSubscription(Guid userSubscriptionId)
        {
            var userSubscription = await _unitOfWork.UserSubscriptionRepository.GetUserSubscriptionByIdAsync(userSubscriptionId);
            if (userSubscription == null)
            {
                return new Result<bool>()
                {
                    Data = false,
                    Error = 1,
                    Message = "User subscription not found"
                };
            }
            var payment = userSubscription.Payments?.LastOrDefault();
            if (payment == null)
                return new Result<bool>()
                {
                    Data = false,
                    Error = 1,
                    Message = "No payment found for the subscription"
                };
            long.TryParse(payment.GatewayTransactionId, out var gatewayTransactionId);
            if (gatewayTransactionId == 0)
                return new Result<bool>()
                {
                    Data = false,
                    Error = 1,
                    Message = "Invalid GatewayTransactionId"
                };
            var paymentStatus = await _payOS.getPaymentLinkInformation(gatewayTransactionId);
            if (paymentStatus == null || paymentStatus.status != "PAID")   
            {
                return new Result<bool>()
                {
                    Data = false,
                    Error = 1,
                    Message = "Payment not completed"
                };
            }
            if (payment.CompletedAt != null)
            {
                return new Result<bool>()
                {
                    Data = false,
                    Error = 1,
                    Message = "This payment session is activated"
                };
            }
            if (payment.DurationInDays is null || payment.DurationInDays <= 0)
            {
                return new Result<bool>()
                {
                    Data = false,
                    Error = 1,
                    Message = "Invalid payment duration"
                };
            }
            userSubscription.Status = UserSubscriptionStatus.Active;
            userSubscription.ExpiresAt = DateTime.UtcNow.AddDays((double)payment.DurationInDays);
            payment.Status = PaymentStatus.Success;            
            payment.CompletedAt = DateTime.UtcNow;
            _unitOfWork.UserSubscriptionRepository.Update(userSubscription);
            _unitOfWork.PaymentRepository.Update(payment);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<bool>()
                {
                    Data = true,
                    Error = 0,
                    Message = "Subscription activated successfully"
                };
            }
            return new Result<bool>()
            {
                Data = false,
                Error = 1,
                Message = "Failed to activate subscription"
            };
        }
        public async Task<Result<Payment>> CreateCheckoutSession(CreateCheckoutSessionRequest request)
        {
            var user = await _userService.GetCurrentUserById();
            if (user is null)
                return new Result<Payment>()
                {
                    Error = 1,
                    Message = "User not found"
                };
            if (user.Data is null)
                return new Result<Payment>()
                {
                    Error = 1,
                    Message = "User data not found"
                };
            var userSubscription = await _unitOfWork.UserSubscriptionRepository.GetByIdAsync(request.UserSubscriptionId);
            if (userSubscription is null)
                return new Result<Payment>()
                {
                    Error = 1,
                    Message = "User subscription not found"
                };
            var subscription = await _unitOfWork.SubscriptionPlanRepository.GetByIdAsync(request.SubscriptionPlanId);
            if (subscription is null)
                return new Result<Payment>()
                {
                    Error = 1,
                    Message = "Subscription plan not found"
                };
            int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
            var subscriptionMonths = subscription.DurationInDays / 30;
            if (subscriptionMonths == 0)
                return new Result<Payment>()
                {
                    Error = 1,
                    Message = "Subscription plan duration is invalid"
                };
            var expiresAt = DateTime.UtcNow.AddMinutes(15);
            var amount = (int)subscription.Price * subscriptionMonths;
            ItemData item = new ItemData(subscription.SubscriptionName.ToString(), (int)subscriptionMonths, (int)subscription.Price);
            List<ItemData> items = new List<ItemData> { item };
            PaymentData paymentData = new PaymentData(
                    orderCode,
                    (int)amount,
                    "Thanh toán gói " + subscription.SubscriptionName.ToString(),
                    items,
                    //"https://example.com/cancel",
                    //"https://example.com/success",
                    "http://localhost:5173/payment-cancel",
                    "http://localhost:5173/payment-success",
                    expiredAt: new DateTimeOffset(expiresAt)
                .ToUnixTimeSeconds()
                );
            CreatePaymentResult result = await _payOS.createPaymentLink(paymentData);
            //if (result == null || result.status != "success")
            if (result == null)
            {
                return new Result<Payment>()
                {
                    Error = 1,
                    Message = "Failed to create payment link"
                };
            }
            var paymentId = new Guid();
            var payment = new Payment()
            {
                Id = paymentId,
                UserSubscriptionId = request.UserSubscriptionId,
                Description = "Payment for subscription plan: " + subscription.SubscriptionName,
                InvoicedPrice = (decimal)amount,
                Amount = (decimal)amount,
                Currency = "VND",
                CheckoutUrl = result.checkoutUrl,
                UserSubscription = userSubscription,
                GatewayTransactionId = result.orderCode.ToString(),
                Provider = "PayOS",
                PaymentMethod = request.PaymentMethod,
                Status = PaymentStatus.Pending,
                ExpiresAt = expiresAt,
                RawResponse = System.Text.Json.JsonSerializer.Serialize(result),
                DurationInDays = subscription.DurationInDays,
                SubscriptionType = subscription.SubscriptionType,
            };
            await _unitOfWork.PaymentRepository.AddAsync(payment);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<Payment>()
                {
                    Data = payment,
                    Error = 0,
                    Message = result.checkoutUrl
                };
            return new Result<Payment>()
            {
                Error = 1,
                Message = "Failed to save payment"
            };
        }

        public async Task<List<RevenueStatisticsDetailDto>> GetRevenueByMonthAsync(int year)
        {
            var payments = (await _unitOfWork.PaymentRepository.GetSuccessfulPaymentsAsync())
                .Where(p => p.CreatedAt.Year == year && p.UserSubscription != null && p.UserSubscription.SubscriptionPlan != null);

            var mapped = payments
                .GroupBy(p => new
                {
                    p.CreatedAt.Year,
                    Month = p.CreatedAt.Month,
                    PlanId = p.UserSubscription.SubscriptionPlanId,
                    PlanName = p.UserSubscription.SubscriptionPlan.SubscriptionName
                })
                .Select(g => new RevenueStatisticsDetailDto
                {
                    Period = new PeriodDto { Type = "Month", Value = g.Key.Month, Year = g.Key.Year },
                    SubscriptionPlanId = g.Key.PlanId,
                    SubscriptionName = g.Key.PlanName.ToString(),
                    Count = g.Count(),
                    TotalRevenue = g.Sum(x => x.Amount)
                })
                .ToList();

            return StatisticsHelper.CalculateGrowthPerSeries(
                mapped,
                r => r.SubscriptionPlanId,
                r => r.TotalRevenue,
                r => r.Period,
                (r, g) => r.GrowthRate = g
            );
        }

        public async Task<List<RevenueStatisticsDetailDto>> GetRevenueByQuarterAsync(int year)
        {
            var payments = (await _unitOfWork.PaymentRepository.GetSuccessfulPaymentsAsync())
                .Where(p => p.CreatedAt.Year == year && p.UserSubscription != null && p.UserSubscription.SubscriptionPlan != null);

            var mapped = payments
                .GroupBy(p => new
                {
                    p.CreatedAt.Year,
                    Quarter = ((p.CreatedAt.Month - 1) / 3) + 1,
                    PlanId = p.UserSubscription.SubscriptionPlanId,
                    PlanName = p.UserSubscription.SubscriptionPlan.SubscriptionName
                })
                .Select(g => new RevenueStatisticsDetailDto
                {
                    Period = new PeriodDto { Type = "Quarter", Value = g.Key.Quarter, Year = g.Key.Year },
                    SubscriptionPlanId = g.Key.PlanId,
                    SubscriptionName = g.Key.PlanName.ToString(),
                    Count = g.Count(),
                    TotalRevenue = g.Sum(x => x.Amount)
                })
                .ToList();

            return StatisticsHelper.CalculateGrowthPerSeries(
                mapped,
                r => r.SubscriptionPlanId,
                r => r.TotalRevenue,
                r => r.Period,
                (r, g) => r.GrowthRate = g
            );
        }

        public async Task<List<RevenueStatisticsDetailDto>> GetRevenueByYearAsync()
        {
            var payments = (await _unitOfWork.PaymentRepository.GetSuccessfulPaymentsAsync())
                .Where(p => p.UserSubscription != null && p.UserSubscription.SubscriptionPlan != null);

            var mapped = payments
                .GroupBy(p => new
                {
                    Year = p.CreatedAt.Year,
                    PlanId = p.UserSubscription.SubscriptionPlanId,
                    PlanName = p.UserSubscription.SubscriptionPlan.SubscriptionName
                })
                .Select(g => new RevenueStatisticsDetailDto
                {
                    Period = new PeriodDto { Type = "Year", Value = g.Key.Year, Year = g.Key.Year },
                    SubscriptionPlanId = g.Key.PlanId,
                    SubscriptionName = g.Key.PlanName.ToString(),
                    Count = g.Count(),
                    TotalRevenue = g.Sum(x => x.Amount)
                })
                .ToList();

            return StatisticsHelper.CalculateGrowthPerSeries(
                mapped,
                r => r.SubscriptionPlanId,
                r => r.TotalRevenue,
                r => r.Period,
                (r, g) => r.GrowthRate = g
            );
        }

        public async Task<List<PaymentHistoryDto>> GetPaymentHistoryAsync(DateTime? fromDate, DateTime? toDate, Guid? userId, PaymentStatus? status)
        {
            var payments = await _unitOfWork.PaymentRepository.GetPaymentsAsync(fromDate, toDate, userId, status);

            return payments.Select(p => new PaymentHistoryDto
            {
                PaymentId = p.Id,
                UserId = p.UserSubscription?.UserId ?? Guid.Empty,
                UserEmail = p.UserSubscription?.User?.Email ?? string.Empty,
                SubscriptionPlan = p.UserSubscription?.SubscriptionPlan?.SubscriptionName.ToString() ?? string.Empty,
                Amount = p.Amount,
                Status = p.Status.ToString(),
                CreatedAt = p.CreatedAt
            }).ToList();
        }

        public Task<List<PaymentHistoryDto>> GetPaymentHistoryByUserAsync(Guid userId)
            => GetPaymentHistoryAsync(null, null, userId, null);

        public async Task<DashboardStatisticsDto> GetDashboardStatisticsAsync(int year)
        {
            var revenueRaw = await _unitOfWork.PaymentRepository.GetRevenueByMonthAsync(year);
            var userRaw = await _unitOfWork.UserSubscriptionRepository.GetUserStatisticsByMonthAsync(year);

            var revenueStats = revenueRaw.Select(r => new RevenueStatisticsDetailDto
            {
                Period = r.ToPeriodDto(),
                SubscriptionPlanId = r.SubscriptionPlanId,
                SubscriptionName = r.SubscriptionName,
                Count = r.Count,
                TotalRevenue = r.TotalRevenue
            }).ToList();

            var userStats = userRaw.Select(u => new UserSubscriptionStatisticsDetailDto
            {
                Period = u.ToPeriodDto(),
                ActiveCount = u.ActiveCount,
                ExpiredCount = u.ExpiredCount,
                CanceledCount = u.CanceledCount,
                PendingCount = u.PendingCount,
                TotalUsers = u.TotalUsers,
                TotalMonthsUsed = u.TotalMonthsUsed
            }).ToList();

            return new DashboardStatisticsDto
            {
                RevenueStatistics = revenueStats,
                UserSubscriptionStatistics = userStats
            };
        }
    }
}
