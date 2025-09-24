using Net.payOS;
using Net.payOS.Types;
using Server.Application;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Payment;
using Server.Application.Interfaces;
using Server.Application.Services;
using Server.Domain.Entities;

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
            if (result == null || result.status != "success")
            {
                return new Result<Payment>()
                {
                    Error = 1,
                    Message = "Failed to create payment link"
                };
            }
            var payment = new Payment()
            {
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
                Status = Domain.Enums.PaymentStatus.Pending,
                ExpiresAt = expiresAt,
                RawResponse = System.Text.Json.JsonSerializer.Serialize(result)
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
    }
}
