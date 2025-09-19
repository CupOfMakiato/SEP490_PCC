using Net.payOS;
using Server.Application;
using Server.Application.DTOs.Payment;
using Server.Application.Interfaces;

namespace Server.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PayOS _payOS;

        public PaymentService(IUnitOfWork unitOfWork, PayOS payOS)
        {
            _unitOfWork = unitOfWork;
            _payOS = payOS;
        }
        public Task<string> CreateCheckoutSession(CreateCheckoutSessionRequest request)
        {
            
        }
    }
}
