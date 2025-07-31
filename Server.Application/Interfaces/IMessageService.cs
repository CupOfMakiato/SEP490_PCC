using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Message;

namespace Server.Application.Interfaces
{
    public interface IMessageService
    {
        public Task<Result<ViewChatThreadDTO>> GetChatThreadByIdAsync(Guid chatThreadId);
        public Task<Result<List<ViewChatThreadDTO>>> GetChatThreadsByUserIdAsync(Guid userId);
        public Task<Result<bool>> SendMessageAsync(SendMessageDTO sendMessage);
        public Task<Result<bool>> StartThreadAsync(ChatThreadDTO chatThread);
        //public Task JoinThread(Guid threadId);
        //public Task LeaveThread(Guid threadId);
        public Task<Result<bool>> SoftDeleteMessageAsync(Guid messageId);
        public Task<Result<bool>> SoftDeleteChatThreadAsync(Guid chatThreadId);
    }
}
