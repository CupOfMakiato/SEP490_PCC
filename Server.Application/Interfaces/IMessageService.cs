using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.ChatThread;
using Server.Application.DTOs.Message;

namespace Server.Application.Interfaces
{
    public interface IMessageService
    {
        public Task<Result<ViewChatThreadDTO>> GetChatThreadByIdAsync(Guid chatThreadId);
        public Task<Result<List<ViewChatThreadDTO>>> GetChatThreadsByUserIdAsync(Guid userId);
        Task<Result<object>> SendMessageAsync(SendMessageDTO sendMessage);
        Task<Result<object>> StartThreadAsync(CreateChatThreadDTO chatThread);
        //public Task JoinThread(Guid threadId);
        //public Task LeaveThread(Guid threadId);
        public Task<Result<bool>> SoftDeleteMessageAsync(Guid messageId);
        public Task<Result<bool>> SoftDeleteChatThreadAsync(Guid chatThreadId);
    }
}
