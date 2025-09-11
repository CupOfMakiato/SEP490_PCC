using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;
        private readonly INotificationSender _notificationSender;


        public NotificationService(
            INotificationRepository notificationRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IClaimsService claimsService,
            INotificationSender notificationSender)
        {
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;
            _notificationSender = notificationSender;
        }

        public async Task<Notification> CreateNotification(Notification notification, object payload = null, string type = "Generic")
        {
            await _notificationRepository.AddAsync(notification);
            await _unitOfWork.SaveChangeAsync();

            await _notificationSender.SendNotificationToServer((Guid)notification.CreatedBy, payload ?? notification.Message, type);

            return notification;
        }


        public async Task<List<Notification>> GetAllNotifications()
        {
            return await _notificationRepository.GetAllNotifications();
        }

        public async Task<Notification> GetNotificationById(Guid id)
        {
            return await _notificationRepository.GetNotificationById(id);
        }

        public async Task<List<Notification>> GetNotificationsByUserId(Guid userId)
        {
            return await _notificationRepository.GetNotificationsByUserId(userId);
        }

        public async Task<Notification> UpdateNotification(Notification notification)
        {
            _notificationRepository.Update(notification);
            await _unitOfWork.SaveChangeAsync();
            return notification;
        }

        public async Task<bool> DeleteNotification(Guid id)
        {
            var notification = await _notificationRepository.GetByIdAsync(id);
            if (notification == null) return false;

            _notificationRepository.SoftRemove(notification);
            await _unitOfWork.SaveChangeAsync();
            return true;
        }

    }
}
