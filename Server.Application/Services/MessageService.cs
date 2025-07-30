using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Message;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        private readonly IHubContext<MessageHub> _hubContext;
        private readonly ICloudinaryService _cloudinaryService;

        public MessageService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IMessageRepository messageRepository,
            IHubContext<MessageHub> hubContext,
            ICloudinaryService cloudinaryService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _messageRepository = messageRepository;
            _hubContext = hubContext;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<Result<bool>> SoftDeleteChatThreadAsync(Guid chatThreadId)
        {
            var chatThread = await _unitOfWork.ChatThreadRepository
                .GetChatThreadByIdAsync(chatThreadId);

            if (chatThread == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any chat thread, please try again!",
                    Data = false
                };
            }

            _unitOfWork.ChatThreadRepository.SoftRemove(chatThread);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Remove chat thread successfully" : "Remove chat thread fail",
                Data = true
            };
        }

        public async Task<Result<bool>> SoftDeleteMessageAsync(Guid messageId)
        {
            var message = await _messageRepository.GetMessageByIdAsync(messageId);

            if (message == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any message, please try again!",
                    Data = false
                };
            }

            _messageRepository.SoftRemove(message);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Remove message successfully" : "Remove message fail",
                Data = true
            };
        }

        public async Task<Result<List<ViewChatThreadDTO>>> GetChatThreadsByUserIdAsync(Guid userId)
        {
            var result = _mapper.Map<List<ViewChatThreadDTO>>(
                await _unitOfWork.ChatThreadRepository.GetChatThreadByUserIdAsync(userId));

            return new Result<List<ViewChatThreadDTO>>
            {
                Error = 0,
                Message = "View online chat thread successfully",
                Data = result
            };
        }

        public async Task<Result<ViewChatThreadDTO>> GetChatThreadByIdAsync(Guid chatThreadId)
        {
            var result = _mapper.Map<ViewChatThreadDTO>(
                await _unitOfWork.ChatThreadRepository.GetChatThreadByIdAsync(chatThreadId));

            return new Result<ViewChatThreadDTO>
            {
                Error = 0,
                Message = "View online chat thread successfully",
                Data = result
            };
        }

        public async Task JoinThread(Guid threadId)
        {
            var chatThread = await _unitOfWork.ChatThreadRepository.GetChatThreadByIdAsync(threadId);

            if (chatThread == null || chatThread.IsDeleted)
                throw new InvalidOperationException("Chat thread not found or deleted.");

            // Update thread status to "Active" or "Joined"
            chatThread.Status = "Active";

            _unitOfWork.ChatThreadRepository.Update(chatThread);

            await _unitOfWork.SaveChangeAsync();

            // Notify users in the thread (optional)
            await _hubContext.Clients.Group(threadId.ToString())
                .SendAsync("ThreadJoined", new { ThreadId = threadId, Status = chatThread.Status });
        }

        public async Task LeaveThread(Guid threadId)
        {
            var chatThread = await _unitOfWork.ChatThreadRepository.GetChatThreadByIdAsync(threadId);

            if (chatThread == null || chatThread.IsDeleted)
                throw new InvalidOperationException("Chat thread not found or deleted.");

            // Update thread status to "Inactive" or "Left"
            chatThread.Status = "Inactive";

            _unitOfWork.ChatThreadRepository.Update(chatThread);

            await _unitOfWork.SaveChangeAsync();

            // Notify users in the thread (optional)
            await _hubContext.Clients.Group(threadId.ToString())
                .SendAsync("ThreadLeft", new { ThreadId = threadId, Status = chatThread.Status });
        }

        public async Task<Result<bool>> SendMessageAsync(SendMessageDTO sendMessage)
        {
            var chatThread = await _unitOfWork.ChatThreadRepository
                .GetChatThreadByIdAsync(sendMessage.ChatThreadId);

            if (chatThread == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any chat thread, please try again!",
                    Data = false
                };
            }

            var user = await _unitOfWork.UserRepository.GetByIdAsync(sendMessage.SenderId);

            if (user == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any user, please try again!",
                    Data = false
                };
            }

            var attachments = new List<Media>();

            var message = new Message
            {
                ChatThreadId = chatThread.Id,
                SenderId = user.Id,
                MessageText = sendMessage.MessageText,
                Media = attachments,
            };

            await _messageRepository.AddAsync(message);

            var result = await _unitOfWork.SaveChangeAsync();

            if (result > 0)
            {
                await _hubContext.Clients.User(sendMessage.SenderId.ToString())
                .SendAsync("ReceiveMessage", new
                {
                    MessageId = message.Id,
                    SenderId = message.SenderId,
                    MessageText = message.MessageText,
                    SentAt = message.SentAt
                });

                if (sendMessage.Attachments != null && sendMessage.Attachments.Any())
                {
                    foreach (var file in sendMessage.Attachments)
                    {
                        var response = await _cloudinaryService.UploadMessageAttachment(
                            file.FileName, file, message);

                        if (response != null)
                        {
                            var media = new Media
                            {
                                MessageId = message.Id,
                                FileName = file.FileName,
                                FileUrl = response.FileUrl,
                                FilePublicId = response.PublicFileId,
                                FileType = file.ContentType,
                            };
                            await _unitOfWork.MediaRepository.AddAsync(media);
                            if (await _unitOfWork.SaveChangeAsync() > 0)
                                message.Media.Add(media);
                        }
                    }

                    _messageRepository.Update(message);

                    await _unitOfWork.SaveChangeAsync();
                }
            }

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Message sent successfully!" : "Failed to send message.",
                Data = true
            };
        }

        public async Task<Result<bool>> StartThreadAsync(ChatThreadDTO chatThread)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(chatThread.UserId);

            if (user == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any user, please try again!",
                    Data = false
                };
            }

            var consultant = await _unitOfWork.UserRepository.GetByIdAsync(chatThread.ConsultantId);

            if (user == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any user, please try again!",
                    Data = false
                };
            }

            var existingThread = await _unitOfWork.ChatThreadRepository
                .GetExistingChatThreadByIdAsync(chatThread.UserId, chatThread.ConsultantId);

            if (existingThread != null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Chat thread already exists!",
                    Data = false
                };
            }

            var thread = _mapper.Map<ChatThread>(chatThread);

            thread.Status = "Active";

            await _unitOfWork.ChatThreadRepository.AddAsync(thread);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Chat thread started successfully!" : "Failed to start chat thread.",
                Data = true
            };
        }
    }
}
