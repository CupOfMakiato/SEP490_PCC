using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        public Task<Message?> GetMessageByIdAsync(Guid messageId);
    }
}
