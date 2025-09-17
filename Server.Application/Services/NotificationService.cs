using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.GrowthData;
using Server.Application.DTOs.Journal;
using Server.Application.DTOs.Notification;
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
            await _notificationRepository.Add(notification);
            await _unitOfWork.SaveChangeAsync();

            await _notificationSender.SendNotificationToServer((Guid)notification.CreatedBy, payload ?? notification.Message, type);

            return notification;
        }


        public async Task<List<Notification>> GetAllNotifications()
        {
            return await _notificationRepository.GetAllNotifications();
        }

        public async Task<Result<ViewNotificationDTO>> GetNotificationById(Guid id)
        {
            var noti = await _notificationRepository.GetNotificationById(id);
            var result = _mapper.Map<ViewNotificationDTO>(noti);

            if (noti == null)
            {
                return new Result<ViewNotificationDTO>
                {
                    Error = 1,
                    Message = "Notification not found",
                    Data = null
                };
            }

            return new Result<ViewNotificationDTO>
            {
                Error = 0,
                Message = "View notification by id successfully",
                Data = result
            };
        }

        public async Task<Result<List<ViewNotificationDTO>>> GetNotificationsByUserId(Guid userId)
        {
            var notis = await _unitOfWork.NotificationRepository.GetNotificationsByUserId(userId);
            var result = _mapper.Map<List<ViewNotificationDTO>>(notis);
            if (notis == null)
            {
                return new Result<List<ViewNotificationDTO>>
                {
                    Error = 1,
                    Message = "No notification found for this user",
                    Data = null
                };
            }

            return new Result<List<ViewNotificationDTO>>
            {
                Error = 0,
                Message = "View all notifications for user successfully",
                Data = result
            };
        }

        public async Task<Notification> UpdateNotification(Notification notification)
        {
            _notificationRepository.Update(notification);
            await _unitOfWork.SaveChangeAsync();
            return notification;
        }
        public async Task<Result<ViewNotificationDTO>> MarkNotificationAsRead(Guid id)
        {
            var notification = await _notificationRepository.GetNotificationById(id);
            var result = _mapper.Map<ViewNotificationDTO>(notification);
            if (notification == null) return null;
            notification.IsRead = true;
            _notificationRepository.Update(notification);
            await _unitOfWork.SaveChangeAsync();
            return new Result<ViewNotificationDTO>
            {
                Error = 0,
                Message = "Mark notification as read successfully",
                Data = null
            };
        }

        public async Task<bool> DeleteNotification(Guid id)
        {
            var notification = await _notificationRepository.GetNotificationById(id);
            if (notification == null) return false;

            _notificationRepository.SoftRemove(notification);
            await _unitOfWork.SaveChangeAsync();
            return true;
        }

    }
}
