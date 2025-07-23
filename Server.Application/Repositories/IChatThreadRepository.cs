using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IChatThreadRepository : IGenericRepository<ChatThread>
    {
        public Task<ChatThread?> GetExistingChatThreadByIdAsync(Guid userId, Guid consultantId);
        public Task<List<ChatThread?>> GetChatThreadByUserIdAsync(Guid userId);
        public Task<ChatThread?> GetChatThreadByIdAsync(Guid chatThreadId);
    }
}
